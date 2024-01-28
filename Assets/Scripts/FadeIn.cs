using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Material targetMaterial; // Material to adjust transparency
    public float fadeDuration = 2f; // Duration of the fade effect in seconds
    public float delay = 0f; // Delay before starting the fade effect
    public float initialTransparency = 255f; // Initial transparency (0-255)
    public float finalTransparency = 0f; // Final transparency (0-255)

    private void Start()
    {
        Color initialColor = targetMaterial.color;
        initialColor.a = 1f;
        targetMaterial.color = initialColor;
        // Start the fade effect after the specified delay
        Invoke("StartFade", delay);
    }

    private void StartFade()
    {
        // Start the fade coroutine
        StartCoroutine(Fade());
    }

    private System.Collections.IEnumerator Fade()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Calculate the initial and final alpha values (0-1)
        float initialAlpha = initialTransparency / 255f;
        float finalAlpha = finalTransparency / 255f;

        // Set the initial transparency
        SetMaterialTransparency(initialAlpha);

        // Calculate the time step based on the fade duration
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Incrementally adjust the transparency over time
            float lerpFactor = elapsedTime / fadeDuration;
            float currentAlpha = Mathf.Lerp(initialAlpha, finalAlpha, lerpFactor);
            SetMaterialTransparency(currentAlpha);

            // Wait for the next frame
            yield return null;

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Ensure the final transparency is set
        SetMaterialTransparency(finalAlpha);
    }

    private void SetMaterialTransparency(float alpha)
    {
        // Set the transparency of the material's albedo color
        Color color = targetMaterial.color;
        color.a = alpha;
        targetMaterial.color = color;
    }
}