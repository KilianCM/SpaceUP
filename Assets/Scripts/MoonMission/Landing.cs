using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Landing : MonoBehaviour
{
    public float lHeight = -0.186f;
    public float initSpeed = 10;
    public ParticleSystem plume;
    public AudioSource audioS;
    public Button takeOffBtn;
    public AudioClip pschhhhtSound;
    public Light engineLight;

    private float descMaxThrust = 45000;
    private float ascMaxThrust = 15000;
    private float descDryMass = 2034;
    private float descPropMass = 8248;
    private float ascDryMass = 2445;
    private float ascPropMass = 2376;
    private bool landed = false;
    private bool isTakingOff = false;
    private Vector3 gravity = new Vector3(0, -1.62f, 0);
    private Rigidbody rb;
    private float startAlt;
    private ParticleSystem.MainModule plumeMain;
    private float focalLengthSpeed = 1f;

    void Awake()
    {
        Physics.gravity = gravity;
    }

    // Start is called before the first frame update
    void Start()
    {
        startAlt = transform.position.y - lHeight;
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, initSpeed, 0);
        plumeMain = plume.main;
        plume.Play();
    }

    // Update is called once per frame
    void FixedUpdate()//use of FixedUpdate to sync with gravity computing
    {
        if (!landed)
        {
            float currentAlt = transform.position.y - lHeight;
            float remainingDescPropMass = descPropMass * (currentAlt / startAlt);
            rb.mass = descDryMass + remainingDescPropMass + ascDryMass + ascPropMass;
            float descentForce = rb.mass * rb.velocity.y;
            float distributedCounterForce = -(descentForce * (1-(currentAlt / startAlt)));
            float counterThrottle = 1/(descMaxThrust / distributedCounterForce);
            float twr = descMaxThrust / (rb.mass * (Physics.gravity.y*-1));
            float hover_throttle = 1 / twr;
            float throttle = hover_throttle *(1+ counterThrottle);
            rb.AddForce(new Vector3(0,throttle* descMaxThrust, 0),ForceMode.Force);
            plumeMain.startSpeed = new ParticleSystem.MinMaxCurve(50 * throttle);

        }
    }

    IEnumerator disablePhysicsCoroutine()
    {
        yield return new WaitForSeconds(3);
        takeOffBtn.gameObject.SetActive(true);
        Destroy(rb);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!landed) {
            GameObject.FindGameObjectsWithTag("MainCamera")[0].transform.parent = null;
            engineLight.enabled = false;
            landed = true;
            plume.Stop();
            audioS.clip = pschhhhtSound;
            audioS.Play();
            StartCoroutine(disablePhysicsCoroutine());
        }
    }
}
