using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

using VoxelBusters;
using VoxelBusters.NativePlugins;

public class selfiePartage : MonoBehaviour
{


   	int orientation = 0;
	WebCamTexture cam;
	public RawImage display;

	public void TakePicture(){
		GameObject button = GameObject.Find("Pictur");
		button.SetActive(false);
		StartCoroutine (CaptureScreenShoot());
	}


	

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

	
    public void RateMyApp()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            NPBinding.Utility.OpenStoreLink ("com.RoixoGames.TwinSuns");
        }
    }
 
    IEnumerator CaptureScreenShoot ()
    {
        yield return new WaitForEndOfFrame ();
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture ();
        ShareSheet (texture);
        Object.Destroy (texture);
	GameObject button = GameObject.Find("Pictur");
	button.SetActive(true);
           
    }
 
    private void ShareSheet (Texture2D texture)
    {
        ShareSheet _shareSheet = new ShareSheet ();
        _shareSheet.Text = "Space Up C'est trosp de la bal !! ";
        _shareSheet.AttachImage (texture);
        _shareSheet.URL = "Sur le site de la Turbine";
        NPBinding.Sharing.ShowView (_shareSheet, FinishSharing);
    }
 
    private void FinishSharing (eShareResult _result)
    {
        Debug.Log (_result);
    }


}







   	
		
