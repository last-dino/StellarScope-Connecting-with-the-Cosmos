using System.Collections;
using UnityEngine;

public class FadeTeleport : MonoBehaviour
{
    public Renderer quadRenderer; // Reference to the Quad's renderer
    public GameObject objectToTeleport; // GameObject to teleport
    public Vector3 teleportPosition; // Specific position to teleport the GameObject
    public Quaternion teleportRotation; // Specific orientation to teleport the GameObject
    public float fadeDuration = 1f; // Duration of fade in/out
    public float delayAfterFade = 0.5f; // Delay after fading before teleporting

    private bool isFading = false;

    void Start()
    {
        if (!isFading)
        {
            StartCoroutine(FadeTPOut());
        }
    }

    IEnumerator FadeTPOut()
    {
        if (!isFading)
        {
            isFading = true;
            // Fade In
            yield return Fade(0f, 1f, fadeDuration, true);
            // Fade Out
            //yield return Fade(1f, 0f, fadeDuration, false);
            isFading = false;
        }
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration, bool doTeleport)
    {
        float elapsed = 0f;

        Color startColor = quadRenderer.material.color;
        Color endColor = startColor;
        endColor.a = endAlpha;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            quadRenderer.material.color = Color.Lerp(startColor, endColor, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is set
        quadRenderer.material.color = endColor;

        if (doTeleport)
        {
            TeleportObject();
        }
        else
        {
            Debug.Log("skipped");
        }
    }

    void TeleportObject()
    {
        if (objectToTeleport != null)
        {
            // Teleport the GameObject to the specified position and orientation
            objectToTeleport.transform.position = teleportPosition;
            objectToTeleport.transform.rotation = teleportRotation;
        }
    }
}