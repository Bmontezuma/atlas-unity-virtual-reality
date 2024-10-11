using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class GestureListenerTwo : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

    private InputDevice device;

    // References to UI Images that will display the gesture reactions
    public Image waveImage;          // Image for wave gesture
    public Image thumbsUpImage;      // Image for thumbs up gesture
    public Image pointImage;         // Image for point gesture

    // Sprites to show for each gesture
    public Sprite waveSprite;        // Sprite for wave gesture
    public Sprite thumbsUpSprite;    // Sprite for thumbs up gesture
    public Sprite pointSprite;       // Sprite for point gesture

    void Start()
    {
        InitializeController();
        HideAllImages();  // Initially hide all images
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

        // Check for wave gesture input
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isTriggerPressed) && isTriggerPressed)
        {
            ShowWaveImage();
        }
        // Check for thumbs up gesture input
        else if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPrimaryButtonPressed) && isPrimaryButtonPressed)
        {
            ShowThumbsUpImage();
        }
        // Check for point gesture input
        else if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isSecondaryButtonPressed) && isSecondaryButtonPressed)
        {
            ShowPointImage();
        }
        else
        {
            HideAllImages();
        }
    }

    void ShowWaveImage()
    {
        waveImage.sprite = waveSprite;
        waveImage.gameObject.SetActive(true);
        thumbsUpImage.gameObject.SetActive(false);
        pointImage.gameObject.SetActive(false);
    }

    void ShowThumbsUpImage()
    {
        thumbsUpImage.sprite = thumbsUpSprite;
        thumbsUpImage.gameObject.SetActive(true);
        waveImage.gameObject.SetActive(false);
        pointImage.gameObject.SetActive(false);
    }

    void ShowPointImage()
    {
        pointImage.sprite = pointSprite;
        pointImage.gameObject.SetActive(true);
        waveImage.gameObject.SetActive(false);
        thumbsUpImage.gameObject.SetActive(false);
    }

    void HideAllImages()
    {
        waveImage.gameObject.SetActive(false);
        thumbsUpImage.gameObject.SetActive(false);
        pointImage.gameObject.SetActive(false);
    }
}
