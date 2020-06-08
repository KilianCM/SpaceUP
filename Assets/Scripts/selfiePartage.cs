using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

using VoxelBusters;
using VoxelBusters.NativePlugins;

public class selfiePartage : MonoBehaviour
{

	// Oirentation es stocker dans une variable au ca ou on souhaterai développer l'optiosn d'inverser l'image
   	int orientation = 1;
	// Objet camera de notre téléphone
	WebCamTexture cam; 
	GameObject button;
	// affichage du flux video de la camera sur une l'objet RawImage
	public RawImage display;


	void Start() {
		// Vérifie si il y à bien une camera de face.	
		if(WebCamTexture.devices.Length > 1) {
			WebCamDevice cameraSelection =  WebCamTexture.devices[orientation];
			cam = new WebCamTexture(cameraSelection.name, Screen.width, Screen.height);
			cam.Play();
			display.texture = cam;

			// si on n'as bien une camera mais que le script à planter
			if(cam == null){
				Debug.Log(" Problème lors du chargement de la caméra. ");
				return;
			}

		}else{
			Debug.Log("Pas de Caméra détecter");
			return;
		}
 
    	}


	/* 
	Fonction déclenchée lors du click sur le Button Pictur de l'utilisateur.
 	Nous prenons un screen de l'écran avec le logo spaceup et le flux vidéo projeter sur une Raw image.
 	Nous cacherons donc le boutton déclencheur de l'appareil photo avant le screenn écran.
	*/
	public void TakePicture(){
		button = GameObject.Find("Pictur");
		button.SetActive(false);
		StartCoroutine (CaptureScreenShoot());
	}

	
	public void RateMyApp(){
		if (Application.platform == RuntimePlatform.Android){
			NPBinding.Utility.OpenStoreLink ("com.RoixoGames.TwinSuns");
		}
	}
 
	IEnumerator CaptureScreenShoot (){
		yield return new WaitForEndOfFrame ();
		Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture ();
		ShareSheet (texture);
		Object.Destroy (texture);
		button.SetActive(true);	   
	}

 

	// Partage de la Photo
	private void ShareSheet (Texture2D texture) {
		ShareSheet _shareSheet = new ShareSheet ();
		// text ajouter par defaults (senser être vendeur du site)
		_shareSheet.Text = "SpaceUp c'est trop cool !";
		_shareSheet.AttachImage (texture);
		_shareSheet.URL = "Venez sur le site de la Turbine (Cran-gevrier)";
		NPBinding.Sharing.ShowView (_shareSheet, FinishSharing);
	}
 
	private void FinishSharing (eShareResult _result){
		Debug.Log (_result);
	}


}








   	
		
