using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Specify the name of the scene you want to switch to
    public string targetSceneName;

    // This method is called when the attached button is clicked
    public void SwitchScene()
    {
        // Check if the target scene name is not null or empty
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("Target scene name is not specified!");
        }
    }
}
