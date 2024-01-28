using UnityEngine;
using System.Collections;

public class SlideDoor : MonoBehaviour
{
    public GameObject door;
    public float moveSpeed = 1f; // Speed at which the object moves
    public float moveDuration = 3f; // Duration of movement in second
    private bool isMoving = false;

    public enum MovementOption
    {
        Open,
        Close
    }

    public MovementOption movementOption = MovementOption.Open;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move the object
            MoveObjectDirection();
        }
    }

    void OnEnable()
    {
        // Start moving the object when the button is pressed
        StartMove();
    }

    void StartMove()
    {
        if (!isMoving)
        {
            // Start the movement
            isMoving = true;

            // Stop the movement after the specified duration
            Invoke("StopMove", moveDuration);
        }
    }

    void StopMove()
    {
        // Stop the movement
        isMoving = false;
    }

    void MoveObjectDirection()
    {
        Vector3 moveDirection = Vector3.right * moveSpeed * Time.deltaTime;

        // Modify moveDirection based on the selected movement option
        switch (movementOption)
        {
            case MovementOption.Open:
                moveDirection *= -1f;
                break;
            case MovementOption.Close:
                // No modification needed for Option2 (leave it as is)
                break;
        }

        // Move the object
        door.transform.Translate(moveDirection);
    }
}