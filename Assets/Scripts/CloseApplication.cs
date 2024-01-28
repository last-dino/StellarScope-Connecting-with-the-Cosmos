using UnityEngine;
using UnityEngine.UI;

public class CloseApplication : MonoBehaviour
{
    public Button closeButton;

    void Start()
    {
        // Attach the method to the button's click event
        closeButton.onClick.AddListener(CloseApp);
    }

    void CloseApp()
    {
        // Close the application
        Application.Quit();

        // Note: Application.Quit() might not work in the Unity Editor or some other environments
        // It is usually meant for standalone builds (Windows, Mac, Linux)
        // For editor testing, use UnityEditor.EditorApplication.isPlaying = false;
    }
}