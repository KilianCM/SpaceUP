using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlight : MonoBehaviour {

	public float thrust = 1.0f;
	public float startGTAlt = 10;//Gravity Turn start Altitude
	public float maxRotation = 0.25f;
	public float turnSpeed = 0.1f;
	public float pivotOffset = 0;//y offset rotation pivot (to check if necessary)

	private ParticleSystem[] plumes;
	private Light[] lights;
	private Rigidbody rb;
	private AudioSource engineSound;

	private bool launched = false;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		engineSound = gameObject.GetComponent<AudioSource>();
  		plumes = FindObjectsOfType<ParticleSystem>();
		lights = FindObjectsOfType<Light>();
	}

	void FixedUpdate()
	{
		if (launched)
		{
			rb.AddForce(transform.up * thrust);
			if (transform.position.y > startGTAlt && transform.rotation.x < maxRotation)
			{
				Vector3 pivot = transform.position;
				pivot.y += pivotOffset;
				transform.RotateAround(pivot, Vector3.forward, transform.rotation.x + turnSpeed);
			}
		}
	}

	public void Launch()
	{
        foreach(ParticleSystem plume in plumes)
        {
			plume.Play();
        }
		engineSound.Play();
        foreach(Light light in lights)
        {
			light.enabled = true;
        }
		launched = true;
	}
}
