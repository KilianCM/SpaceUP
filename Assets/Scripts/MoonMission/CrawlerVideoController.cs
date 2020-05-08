using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CrawlerVideoController : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public ScenesControl ScenesControl;

    private double currentTime;

    void Start()
    {
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(PlayVideo());
        VideoPlayer.loopPointReached += EndReached;
    }

    void Update()
    {
        currentTime = VideoPlayer.time;
    }

    void EndReached(VideoPlayer vp)
    {
        ScenesControl.LoadStep2MoonMission();
    }

    IEnumerator PlayVideo()
    {
        VideoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!VideoPlayer.isPrepared)
        {
            yield return waitTime;
            break;
        }
        VideoPlayer.Play();
    }
}