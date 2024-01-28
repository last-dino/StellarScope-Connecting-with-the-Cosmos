using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DetectSocket : MonoBehaviour
{
    public List<GameObject> objectsToPlace;      // List of objects to be placed
    public List<Transform> socketLocations;      // List of corresponding socket locations
    public List<GameObject> objectsToActivate;   // List of objects to activate when all objects are placed
    public List<GameObject> objectsToDeactive;

    private List<GameObject> placedObjects = new List<GameObject>();

    void Update()
    {
        CheckObjectPlacement();
    }

    void CheckObjectPlacement()
    {
        // Check if all objects are placed in the corresponding sockets
        if (objectsToPlace.Count == socketLocations.Count && objectsToPlace.Count > 0)
        {
            bool allObjectsPlaced = true;

            for (int i = 0; i < objectsToPlace.Count; i++)
            {
                // Check if the object is in the correct socket
                if (IsObjectInSocket(objectsToPlace[i], socketLocations[i]))
                {
                    if (!placedObjects.Contains(objectsToPlace[i]))
                    {
                        placedObjects.Add(objectsToPlace[i]);
                    }
                }
                else
                {
                    allObjectsPlaced = false;
                }
            }

            // If all objects are placed, activate specified game objects
            if (allObjectsPlaced)
            {
                Debug.Log("added all sockets");
                ActivateGameObjects();
            }
        }
    }

    bool IsObjectInSocket(GameObject obj, Transform socket)
    {
        // Adjust this condition based on your object placement logic
        float distance = Vector3.Distance(obj.transform.position, socket.position);
        return distance < 0.5f; // Example: consider the object placed if it's within a certain distance of the socket
    }

    void ActivateGameObjects()
    {
        // Activate the specified game objects
        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        foreach (var obj in objectsToDeactive)
        {
            obj.SetActive(false);
        }

        // You can add additional logic or actions after activation if needed
    }
}
