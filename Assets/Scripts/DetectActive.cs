using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DetectActive : MonoBehaviour
{
    public List<GameObject> objectsToCheck;
    public GameObject objectToActivate;

    void Update()
    {
        // Check if all objects in the list are active
        bool allObjectsActive = objectsToCheck.All(obj => obj.activeSelf);

        // If all objects are active, activate another object
        if (allObjectsActive)
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
