using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Transform objectToMove; // Assign the object to move in the Inspector
    public Vector3 newPosition = new Vector3(0f, 2f, 0f); // New position for the object
    public Quaternion newRotation = Quaternion.Euler(0f, 180f, 0f);

    void Start()
    {
        if (objectToMove == null)
        {
            Debug.LogError("Object to move not assigned!");
        }
    }

    public void MoveAndResetObject()
    {
        if (objectToMove != null)
        {
            // Change the object's location to (0, 1, 0)
            objectToMove.position = newPosition;

            // Reset the object's rotation to identity rotation
            objectToMove.rotation = newRotation;
        }
        else
        {
            Debug.LogError("Object to move not assigned!");
        }
    }
}