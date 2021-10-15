using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    float mouseSensitivity;

    public GameObject optionsMenuUI;

    public AudioMixer audioMixer;

    public AudioSource buttonClick;

    public void Fullscreen()
    {
        //sound
        buttonClick.Play();

        Screen.fullScreen = !Screen.fullScreen;
    }

    public void MouseSensitivity(float newSpeed)
    {
        mouseSensitivity = newSpeed;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void ApplyButton()
    {
        //sound
        buttonClick.Play();

        optionsMenuUI.SetActive(false);
    }
}
