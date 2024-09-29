using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  // Input System for detecting VR gestures
using UnityEngine.UI;

public class GestureListener : MonoBehaviour
{
    public InputActionReference waveAction;        // Action for detecting wave gesture
    public InputActionReference thumbsUpAction;    // Action for detecting thumbs up gesture
    public InputActionReference facePalmAction;    // Action for detecting face palm gesture

    public Image reactionImage;                    // Reference to the UI Image component
    public Sprite waveSprite;                      // Sprite for wave gesture
    public Sprite thumbsUpSprite;                  // Sprite for thumbs up gesture
    public Sprite facePalmSprite;                  // Sprite for face palm gesture

    void OnEnable()
    {
        waveAction.action.performed += OnWavePerformed;
        thumbsUpAction.action.performed += OnThumbsUpPerformed;
        facePalmAction.action.performed += OnFacePalmPerformed;
    }

    void OnDisable()
    {
        waveAction.action.performed -= OnWavePerformed;
        thumbsUpAction.action.performed -= OnThumbsUpPerformed;
        facePalmAction.action.performed -= OnFacePalmPerformed;
    }

    // Method to handle wave gesture
    void OnWavePerformed(InputAction.CallbackContext context)
    {
        reactionImage.sprite = waveSprite;  // Swap to wave image
    }

    // Method to handle thumbs up gesture
    void OnThumbsUpPerformed(InputAction.CallbackContext context)
    {
        reactionImage.sprite = thumbsUpSprite;  // Swap to thumbs up image
    }

    // Method to handle face palm gesture
    void OnFacePalmPerformed(InputAction.CallbackContext context)
    {
        reactionImage.sprite = facePalmSprite;  // Swap to face palm image
    }
}
