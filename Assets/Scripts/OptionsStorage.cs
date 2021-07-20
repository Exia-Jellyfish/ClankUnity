using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsStorage : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider = null;

    private void Start()
    {
        LoadValue();
    }


    public void VolumeSlider(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeValue);
        LoadValue();
    }

    void LoadValue()
    {
        float volumeValue = PlayerPrefs.GetFloat("volume");
        volumeSlider.value = volumeValue;
        audioMixer.SetFloat("volume", volumeValue);
    }
}
