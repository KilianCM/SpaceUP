using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selfie : MonoBehaviour
{
	int orientation = 0;

	WebCamTexture cam;



	void Start()
	{

		// inverse camera pour obtenir la camera de face		
		if(WebCamTexture.devices.Length > 0)
		{
			orientation +=1;
			orientation %= WebCamTexture.devices.Length;
		}



		WebCamDevice zozo =  WebCamTexture.devices[ orientation ];


		cam = new WebCamTexture(zozo.name);
		
		    
		// asigned element Guad (support script) camera
		GetComponent<Renderer>().material.mainTexture = cam;




		cam.Play();



         
     



	 }

	 void Update()
	 {

	 }



}


