using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public string nextSceneName; // Set the next scene name in the Inspector
    public Image transitionImage; // Reference to an Image component for the transition effect
    public float transitionTime = 1.0f; // Set the transition time in seconds

    private void Start()
    {
        // Ensure the transition image is fully transparent at the beginning
        if (transitionImage != null)
        {
            Color imageColor = transitionImage.color;
            imageColor.a = 0f;
            transitionImage.color = imageColor;
        }
    }

    public void StartSceneTransition()
    {
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        // Fade out the transition image
        if (transitionImage != null)
        {
            StartCoroutine(FadeImage(0f, 1f, transitionTime / 2, transitionImage));
            yield return new WaitForSeconds(transitionTime / 2);
        }

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);

        // Fade in the transition image
        if (transitionImage != null)
        {
            yield return new WaitForSeconds(0.1f); // Adjust this delay if needed
            StartCoroutine(FadeImage(1f, 0f, transitionTime / 2, transitionImage));
        }
    }

    IEnumerator FadeImage(float startAlpha, float targetAlpha, float duration, Image image)
    {
        float startTime = Time.time;
        Color imageColor = image.color;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            imageColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            image.color = imageColor;
            yield return null;
        }

        imageColor.a = targetAlpha;
        image.color = imageColor;
    }
}
