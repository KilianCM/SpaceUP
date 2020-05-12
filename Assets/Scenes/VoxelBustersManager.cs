using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using VoxelBusters;
using VoxelBusters.NativePlugins;


public class VoxelBustersManager : MonoBehaviour
{
    private bool isSharing = false;
 
    public void RateMyApp()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            NPBinding.Utility.OpenStoreLink ("com.RoixoGames.TwinSuns");
        }
    }
 
    public void ShareSocialMedia ()
    {
        isSharing = true;
    }
 
    void LateUpdate ()
    {
        if (isSharing == true)
        {
            isSharing = false;
 
            StartCoroutine (CaptureScreenShoot());
        }
    }
 
    IEnumerator CaptureScreenShoot ()
    {
        yield return new WaitForEndOfFrame ();
 
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture ();
 
        ShareSheet (texture);
 
        Object.Destroy (texture);
           
    }
 
    private void ShareSheet (Texture2D texture)
    {
        ShareSheet _shareSheet = new ShareSheet ();
 
        _shareSheet.Text = "Hello world!!!";
        _shareSheet.AttachImage (texture);
        _shareSheet.URL = "https://twitter.com/RoixoGames";
 
        NPBinding.Sharing.ShowView (_shareSheet, FinishSharing);
    }
 
    private void FinishSharing (eShareResult _result)
    {
        Debug.Log (_result);
    }
}
