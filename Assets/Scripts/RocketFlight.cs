using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlight : MonoBehaviour {

	public float thrust = 1.0f;
	
	
	public float startGTAlt = 10;//Gravity Turn start Altitude
	public float maxRotation = 0.25f;
	public float turnSpeed = 0.1f;
	public float pivotOffset = 0;//y offset rotation pivot (to check if necessary)
	public ParticleSystem plume;
	public Light engineLight;
	public GameObject cam;

	private Rigidbody rb;
	private AudioSource source;

	private bool launched = false;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		source = gameObject.GetComponent<AudioSource>();
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
		plume.Play();
		source.Play();
		engineLight.enabled = true;
		cam.GetComponent<CameraShake>().ShakeEnable(true);
		launched = true;
	}
}
