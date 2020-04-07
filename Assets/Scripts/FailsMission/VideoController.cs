using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ScenesControl scenesControl;
    public Canvas loadingCanvas;

    private double currentTime;
    private GameObject astronautLoader;
    private Vector3 rotationEuler;

    void Start()
    {
        astronautLoader = GameObject.FindGameObjectWithTag("Loader");

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
        if(currentTime == 0)
		{
            rotationEuler += Vector3.forward * 110 * Time.deltaTime; //increment 90 degrees every second
            astronautLoader.transform.rotation = Quaternion.Euler(rotationEuler);
        }
        else
		{
            loadingCanvas.gameObject.SetActive(false);
		}
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