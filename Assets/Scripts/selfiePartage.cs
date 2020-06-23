using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VoxelBusters;
using VoxelBusters.NativePlugins;

public class SelfiePartage : MonoBehaviour
{

	// Orientation stockée dans une variable au cas pour pouvoir inverser l'image
   	int orientation = 1;
	// Objet camera de notre téléphone
	WebCamTexture cam; 
	GameObject button;
	// affichage du flux video de la camera sur une l'objet RawImage
	public RawImage display;

	void Start() {
		// Vérifie si il y a bien une camera frontale	
		if(WebCamTexture.devices.Length > 1) {

			WebCamDevice cameraSelection =  WebCamTexture.devices[orientation];
			cam = new WebCamTexture(cameraSelection.name, Screen.width, Screen.height);			

			// si on a bien une camera mais que le script a planté
			if(cam == null){
				Debug.Log("Problème lors du chargement de la caméra. ");
				return;
			}

		} else {
			Debug.Log("Pas de caméra détectée");
			return;
		}

        cam.Play();
		display.texture = cam;
    }


	/* 
	    Fonction déclenchée lors du click sur le Button Pictur de l'utilisateur.
 	    Nous prenons un screen de l'écran avec le logo spaceup et le flux vidéo projeté sur une Raw image.
 	    Nous cacherons donc le bouton déclencheur de l'appareil photo avant le screen écran.
	*/
	public void TakePicture(){
		button = GameObject.Find("Pictur");
		button.SetActive(false);
		StartCoroutine (CaptureScreenShoot());
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
		// text ajouté par default
		_shareSheet.Text = "SpaceUP c'est génial !";
		_shareSheet.AttachImage (texture);
		_shareSheet.URL = "Visitez le site de la Turbine (Cran-Gevrier), on apprend en s'amusant";
		NPBinding.Sharing.ShowView (_shareSheet, FinishSharing);
	}
 
	private void FinishSharing (eShareResult _result){
		Debug.Log (_result);
	}

}   	
		
