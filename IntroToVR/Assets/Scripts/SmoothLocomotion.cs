using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class SmoothLocomotion : MonoBehaviour
{
    public ActionBasedController leftController;  // Reference to left controller
    public ActionBasedController rightController; // Reference to right controller
    public float moveSpeed = 2.0f;  // Movement speed
    public InputActionProperty moveAction;  // Reference to the movement action

    public bool isMoving { get; private set; }  // Tracks if the player is moving

    void Update()
    {
        // Get input from the movement action
        Vector2 inputAxis = moveAction.action.ReadValue<Vector2>();

        // Set isMoving to true if input exists, otherwise false
        isMoving = inputAxis != Vector2.zero;

        // Move the player if there's input
        if (isMoving)
        {
            MovePlayer(inputAxis);
        }
    }

    // Function to handle player movement
    private void MovePlayer(Vector2 input)
    {
        // Get the direction based on the camera's forward and right vectors
        Transform cameraTransform = Camera.main.transform;
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Prevent movement in the y-axis (up/down)
        forward.y = 0;
        right.y = 0;

        // Normalize to prevent faster diagonal movement
        forward.Normalize();
        right.Normalize();

        // Calculate the desired move direction
        Vector3 moveDirection = forward * input.y + right * input.x;

        // Move the player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
