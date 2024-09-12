using UnityEngine;

public class FOVReduction : MonoBehaviour
{
    public Camera vrCamera;  // Assign your VR camera here
    public SmoothLocomotion smoothLocomotion;  // Reference to the SmoothLocomotion script
    public float defaultFOV = 90f;  // Default field of view
    public float reducedFOV = 70f;  // Reduced field of view when moving

    void Update()
    {
        // Check if the player is moving
        if (smoothLocomotion.isMoving)
        {
            vrCamera.fieldOfView = Mathf.Lerp(vrCamera.fieldOfView, reducedFOV, Time.deltaTime * 5);
        }
        else
        {
            vrCamera.fieldOfView = Mathf.Lerp(vrCamera.fieldOfView, defaultFOV, Time.deltaTime * 5);
        }
    }
}
