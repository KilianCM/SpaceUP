using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class NFCScanner : MonoBehaviour
{

    public string tagID;
    public Text debugText;
    public bool tagFound = false;
    public ScenesControl scenesControl;
 
    private AndroidJavaObject mActivity;
    private AndroidJavaObject mIntent;
    private string sAction;

    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "No tag...";
    }

    // Update is called once per frame
    void Update()
    {
        tagFound = false;
        if (Application.platform == RuntimePlatform.Android) {
            if (!tagFound) {
                try {
                    // Create new NFC Android object
                    mActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                    mIntent = mActivity.Call<AndroidJavaObject>("getIntent");
                    sAction = mIntent.Call<String>("getAction");
                    if (sAction == "android.nfc.action.NDEF_DISCOVERED") {
                        Debug.Log("Tag of type NDEF");
                    }
                    else if (sAction == "android.nfc.action.TECH_DISCOVERED") {
                        Debug.Log("TAG DISCOVERED");
                        // Get ID of tag
                        AndroidJavaObject mNdefMessage = mIntent.Call<AndroidJavaObject>("getParcelableExtra", "android.nfc.extra.TAG");
                        if (mNdefMessage != null) {
                            byte[] payLoad = mNdefMessage.Call<byte[]>("getId");
                            string text = System.Convert.ToBase64String(payLoad);
                            debugText.text = text;
                            tagID = text;
                            scenesControl.LoadFailsVideoScene();
                            mIntent.Call("removeExtra", "android.nfc.extra.TAG");
                        }
                        else {
                            debugText.text = "No ID found !";
                        }
                        tagFound = true;
                        return;
                    }
                    else if (sAction == "android.nfc.action.TAG_DISCOVERED") {
                        Debug.Log("This type of tag is not supported !");
                    }
                    else {
                        debugText.text = "No tag...";
                        return;
                    }
                }
                catch (Exception ex) {
                    string text = ex.Message;
                    debugText.text = text;
                }
            }
        }
    }
}
