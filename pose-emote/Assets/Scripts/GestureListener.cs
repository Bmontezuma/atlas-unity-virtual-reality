using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class GestureListener2D : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

    private InputDevice device;
    
    // Reference to the UI Image that will display the gesture reaction
    public Image gestureReactionImage;  

    // Sprite to show when the wave gesture is detected
    public Sprite waveSprite;  

    private bool isWaving = false;

    void Start()
    {
        InitializeController();
    }

    void InitializeController()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            device = devices[0];
        }
        else
        {
            Debug.LogError("No VR controller found");
        }
    }

    void Update()
    {
        if (!device.isValid)
        {
            InitializeController();
        }

        // Check for gesture input (e.g., a wave gesture, which we'll simulate as a button press for now)
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isTriggerPressed) && isTriggerPressed && !isWaving)
        {
            // Wave gesture detected (replace this with actual gesture logic in the future)
            isWaving = true;
            ShowGestureReaction(waveSprite);  // Show the wave sprite
        }

        if (!isTriggerPressed && isWaving)
        {
            isWaving = false;
            ShowGestureReaction(null);  // Reset the image (or set to default sprite)
        }
    }

    // Function to change the image sprite based on the detected gesture
    void ShowGestureReaction(Sprite sprite)
    {
        if (gestureReactionImage != null)
        {
            gestureReactionImage.sprite = sprite;
        }
        else
        {
            Debug.LogError("Gesture Reaction Image not assigned!");
        }
    }
}