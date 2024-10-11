using UnityEngine;
using UnityEngine.UI;

public class FunSoundController : MonoBehaviour
{
    // Audio sources for each button
    public AudioSource[] buttonSounds; // Assign AudioSource components for FunButtonOne to Six in the Inspector

    // Sliders that will control the pitch
    public Slider funSliderOne;  // Assign FunSliderOne in the Inspector
    public Slider funSliderTwo;  // Assign FunSliderTwo in the Inspector

    // Method to play sound with pitch from slider
    public void PlaySoundWithPitch(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonSounds.Length)
        {
            // Calculate pitch based on sliders (for example, average of both sliders)
            float pitchValue = (funSliderOne.value + funSliderTwo.value) / 2.0f;
            
            // Set the pitch of the sound
            buttonSounds[buttonIndex].pitch = pitchValue;

            // Play the sound
            buttonSounds[buttonIndex].Play();
        }
    }
}
