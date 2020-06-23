using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ascent : MonoBehaviour
{
    public GameObject plume;
    public float finalAltitude;
    public GameObject endPanel; 

    private float ascMaxThrust = 15000;
    private float ascDryMass = 2445;
    private float ascPropMass = 2376;
    private Rigidbody rb;
    private bool isTakingOff = false;
    private float startingAlt;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTakingOff)
        {
            if (transform.position.y >= finalAltitude && !endPanel.activeSelf)
            {
                endPanel.SetActive(true);
            }
            rb.AddForce(new Vector3(0, ascMaxThrust, 0), ForceMode.Force);
        }
    }

    public void AscentStart()
    {
        startingAlt = transform.position.y;
        rb=gameObject.AddComponent<Rigidbody>();
        rb.mass = ascDryMass + ascPropMass;
        rb.isKinematic = false;
        rb.detectCollisions = true;
        isTakingOff = true;
        plume.GetComponent<ParticleSystem>().Play();
        plume.GetComponent<AudioSource>().Play();
    }
}
