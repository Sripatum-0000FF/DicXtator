using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerSwap : MonoBehaviour
{
    public static SceneManagerSwap Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitApp()
    {
        Application.Quit();
    }
}
