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
        // SceneManager.LoadScene("Launch");
    }

    public void LoadEndScene()
    {
        FadeToScene("Launch");
    }

    public void FadeToScene(string scene) {
        sceneToLoad = scene;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}