using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ScenesControl : MonoBehaviour
{
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
        SceneManager.LoadScene("Launch");
    }
}