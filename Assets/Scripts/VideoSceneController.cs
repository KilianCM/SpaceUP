using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoSceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ScenesControl scenesControl;
    private double currentTime;

    void Start()
    {
        // Start in landscape mode
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(PlayVideo());
        videoPlayer.loopPointReached += EndReached;
    }

    void Update()
    {
        currentTime = videoPlayer.time;
    }

    void EndReached(VideoPlayer vp)
    {
        scenesControl.ReturnToMenu();
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitTime;
            break;
        }

        videoPlayer.Play();
    }
}