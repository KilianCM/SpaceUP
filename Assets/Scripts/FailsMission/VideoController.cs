using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public Canvas LoadingCanvas;
    public Canvas EndCanvas;
    public QuizzController QuizzController;

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
        VideoPlayer.loopPointReached += EndReached;
    }

    void Update()
    {
        currentTime = VideoPlayer.time;
        if(currentTime == 0)
		{
            rotationEuler += Vector3.forward * 110 * Time.deltaTime; //increment 90 degrees every second
            astronautLoader.transform.rotation = Quaternion.Euler(rotationEuler);
        }
        else
		{
            LoadingCanvas.gameObject.SetActive(false);
		}
    }

    void EndReached(VideoPlayer vp)
    {
        Text[] texts = EndCanvas.GetComponentsInChildren<Text>();
        texts[2].text = QuizzController.score + "/4";
        EndCanvas.gameObject.SetActive(true);
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