using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    public float lHeight = -0.186f;
    public float initSpeed = 10;

    private float descMaxThrust = 45000;
    private float ascMaxThrust = 15000;
    private float descDryMass = 2034;
    private float descPropMass = 8248;
    private float ascDryMass = 2445;
    private float ascPropMass = 2376;
    private bool landed = false;
    private Vector3 gravity = new Vector3(0, -1.62f, 0);
    private Rigidbody rb;
    private float startAlt;

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
    }

    // Update is called once per frame
    void FixedUpdate()//use of FixedUpdate to sync with gravity computing
    {
        rb.mass = descDryMass + descPropMass + ascDryMass + ascPropMass;
        if (!landed)
        {
            float descentForce = rb.mass * rb.velocity.y;
            float currentAlt = transform.position.y - lHeight;
            float distributedCounterForce = -(descentForce * (1-(currentAlt / startAlt)));
            Debug.Log(distributedCounterForce+" / "+descentForce);
            float counterThrottle = 1/(descMaxThrust / distributedCounterForce);
            //Debug.Log(counterThrottle);
            float twr = descMaxThrust / (rb.mass * (Physics.gravity.y*-1));
            float hover_throttle = 1 / twr;
            float throttle = hover_throttle *(1+ counterThrottle);
            Debug.Log(throttle);
            rb.AddForce(new Vector3(0,throttle* descMaxThrust, 0),ForceMode.Force);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        landed = true;
    }
}
