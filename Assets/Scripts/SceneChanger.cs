using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load (make sure it's added to the build settings)

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}