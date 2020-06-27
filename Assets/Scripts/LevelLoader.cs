using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Slider slider;
    public Text progressText;
    public Text loadingInfoText;
    public string[] LoadingInfo;
    public void Start()
    {
        StartCoroutine(LoadAsynchronously("MoonLanding"));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            float percentage = progress * 100f;
            int infoIndex = (int) (percentage-1) / (100/LoadingInfo.Length);
            loadingInfoText.text = LoadingInfo[infoIndex];
            progressText.text = percentage + "%";
            yield return null;//wait a frame
        }
    }
}
