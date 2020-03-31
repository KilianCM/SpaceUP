using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoSceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ScenesControl scenesControl;

    // Start in landscape mode
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Debug.Log("Playing Video" + videoPlayer.isPlaying);
        StartCoroutine(PlayVideo());
    }

    void Update()
    {

    }

    IEnumerator PlayVideo()
    {
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }
        Debug.Log("Done Playing Video");
        scenesControl.ReturnToMenu();
    }
}