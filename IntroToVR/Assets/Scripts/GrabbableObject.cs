using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class GrabbableObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        // Subscribe to the grab and drop events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    // Called when the object is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed!");
        // You can add additional logic here, like playing a sound or changing color
    }

    // Called when the object is released
    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Object released!");
    }
}
