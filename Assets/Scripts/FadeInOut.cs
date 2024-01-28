using System.Collections;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public Renderer quadRenderer;
    public float fadeDuration = 2f;
    public float fadeDelay = 0f;
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    private bool isFading = false;

    void Start()
    {
        StartCoroutine(FadeInThenOut());
    }

    IEnumerator FadeInThenOut()
    {
        yield return new WaitForSeconds(fadeDelay);

        if (!isFading)
        {
            isFading = true;

            // Fade In
            yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

            // Activate objects when transparency is 255
            ActivateObjects();
            DeactivateObjects();

            // Fade Out
            yield return StartCoroutine(Fade(1f, 0f, fadeDuration));

            // Reset isFading after both fades are complete
            isFading = false;
        }
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float startTime = Time.time;
        float elapsed = 0f;

        Color startColor = quadRenderer.material.color;
        Color endColor = startColor;
        endColor.a = endAlpha;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            quadRenderer.material.color = Color.Lerp(startColor, endColor, t);

            elapsed = Time.time - startTime;
            yield return null;
        }

        // Ensure the final color is set
        quadRenderer.material.color = endColor;
    }

    void ActivateObjects()
    {
        if (objectsToActivate != null && objectsToActivate.Length > 0)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }

    void DeactivateObjects()
    {
        if (objectsToDeactivate != null && objectsToDeactivate.Length > 0)
        {
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
        }
    }
}