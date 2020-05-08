using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ScenesControl : MonoBehaviour
{

    public Animator animator;
    private string sceneToLoad;

    public void LoadGoddardScene()
    {
        // SceneManager.LoadScene("Launch");
    }
    
    public void LoadCombustionScene()
    {
        FadeToScene("Combustion");
    }

    public void LoadFailsScene() 
    {
        FadeToScene("FailsNFCScan");
    }

    public void LoadFailsVideoScene()
    {
        FadeToScene("NFCPlayVideo");
    }

    public void LoadEndScene()
    {
        FadeToScene("Introduction");
    }

    public void ReturnToMenu()
    {
        FadeToScene("MainMenu");
    }

    public void FadeToScene(string scene) {
        sceneToLoad = scene;
        PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(sceneToLoad);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string lastSceneName = PlayerPrefs.GetString("lastLoadedScene");
            FadeToScene(lastSceneName);
        }
    }
}