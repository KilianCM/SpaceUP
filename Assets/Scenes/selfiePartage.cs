using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class selfiePartage : MonoBehaviour
{


   	int orientation = 0;
	WebCamTexture cam;
	public RawImage display;


    void Start()
    {


		// inverse camera pour obtenir la camera de face (je laisse sous cette forme pour l'instant c'es fais expres		
		if(WebCamTexture.devices.Length > 0)
		{
			orientation +=1;
			orientation %= WebCamTexture.devices.Length;
		}

		WebCamDevice cameraSelection =  WebCamTexture.devices[orientation];
		cam = new WebCamTexture(cameraSelection.name, Screen.width, Screen.height);

		// GetComponent<Renderer>().material.mainTexture = cam;
		display.texture = cam;
		cam.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}







   	
		
