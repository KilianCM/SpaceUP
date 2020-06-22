using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    public float lHeight = -0.186f;
    public float initSpeed = 10;
    public float maxThrust = 45040;

    private bool landed = false;
    private Vector3 gravity = new Vector3(0, -1.62f, 0);
    private Rigidbody rg;

    void Awake()
    {
        Physics.gravity = gravity;
    }

    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        rg.velocity = new Vector3(0, initSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!landed)
        {
            float twr = maxThrust / (rg.mass * (Physics.gravity.y*-1));
            Debug.Log(twr);
            float hover_throttle = 1 / twr;
            Debug.Log(hover_throttle);
            float throttle = hover_throttle * 0.99f;

            rg.AddForce(new Vector3(0,throttle*maxThrust,0));
        }
    }
}
