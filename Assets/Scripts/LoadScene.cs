using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName;

    // Call this method from your button's OnClick event
    public void SceneLoad()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set!");
        }
    }
}

