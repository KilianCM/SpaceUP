using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ScenesControl : MonoBehaviour
{

    public Animator animator;
    private string sceneToLoad;

    public void LoadGoddardScene()
    {
        SceneManager.LoadScene("GoddardWorkshop");
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

    public void LoadCrawlerScene()
    {
        FadeToScene("CrawlerVideo");
    }

    public void LoadStep2MoonMission()
    {
        FadeToScene("AR");
    }

    public void LoadStep3MoonMission()
    {
        FadeToScene("MainMenu");
    }

    public void ReturnToMenu()
    {
        FadeToScene("MainMenu");
    }

    public void FadeToScene(string scene) {
        sceneToLoad = scene;
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
            FadeToScene("MainMenu");
        }
    }
}