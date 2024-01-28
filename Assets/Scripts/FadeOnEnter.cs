using UnityEngine;
using System.Collections;

public class FadeOnEnter : MonoBehaviour
{
    public Renderer quadRenderer;
    public float fadeDuration = 1f;

    private bool isFading = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            // Check if the material transparency is 255
            if (quadRenderer.material.color.a == 1f)
            {
                // Start fading out
                FadeOut();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isFading)
        {
            // Stop fading if the player exits the area
            isFading = false;
            StopAllCoroutines();
        }
    }

    void FadeOut()
    {
        StartCoroutine(Fade(1f, 0f, fadeDuration));
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        isFading = true;

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

        isFading = false;
    }
}