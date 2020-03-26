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
        // SceneManager.LoadScene("Launch");
    }

    public void LoadFailsScene() 
    {
        FadeToScene("FailsNFCScan");
    }

    public void LoadEndScene()
    {
        FadeToScene("Launch");
    }

    public void FadeToScene(string scene) {
        sceneToLoad = scene;
        PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
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