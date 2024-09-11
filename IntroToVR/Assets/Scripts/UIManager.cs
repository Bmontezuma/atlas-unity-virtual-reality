using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button FunButtonOne;
    public Button FunButtonTwo;
    public Button FunButtonThree;
    public Button FunButtonFour;
    public Button FunButtonFive;
    public Button FunButtonSix;

    public Slider FunSliderOne;
    public Slider FunSliderTwo;

    // Add references to individual AudioClips for each button
    public AudioClip funButtonOneClip;
    public AudioClip funButtonTwoClip;
    public AudioClip funButtonThreeClip;
    public AudioClip funButtonFourClip;
    public AudioClip funButtonFiveClip;
    public AudioClip funButtonSixClip;

    // Camera or a position to play the audio
    public Transform audioPlayPosition; // Assign a Transform in the Inspector for sound playback position

    void Start()
    {
        // Assign OnClick events to buttons with individual sounds
        FunButtonOne.onClick.AddListener(() => OnFunButtonClicked(funButtonOneClip));
        FunButtonTwo.onClick.AddListener(() => OnFunButtonClicked(funButtonTwoClip));
        FunButtonThree.onClick.AddListener(() => OnFunButtonClicked(funButtonThreeClip));
        FunButtonFour.onClick.AddListener(() => OnFunButtonClicked(funButtonFourClip));
        FunButtonFive.onClick.AddListener(() => OnFunButtonClicked(funButtonFiveClip));
        FunButtonSix.onClick.AddListener(() => OnFunButtonClicked(funButtonSixClip));

        // Assign OnValueChanged events to sliders
        FunSliderOne.onValueChanged.AddListener((value) => OnFunSliderChanged(1, value));
        FunSliderTwo.onValueChanged.AddListener((value) => OnFunSliderChanged(2, value));
    }

    // Method to handle button clicks and play the appropriate sound
    void OnFunButtonClicked(AudioClip buttonClip)
    {
        if (buttonClip != null)
        {
            if (audioPlayPosition != null)
            {
                AudioSource.PlayClipAtPoint(buttonClip, audioPlayPosition.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(buttonClip, Camera.main.transform.position);
            }
        }
        else
        {
            Debug.LogWarning("Button clip is null.");
        }

        Debug.Log("Button clicked and sound played.");
    }

    // Method to handle slider changes
    void OnFunSliderChanged(int sliderNumber, float value)
    {
        Debug.Log("FunSlider" + sliderNumber + " value changed to: " + value);
    }
}
