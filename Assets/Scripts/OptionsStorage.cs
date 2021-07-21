using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsStorage : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    private void Start()
    {
        LoadResolutionValue();
    }


    //Resolution dropdown and save&load values.
    public void ResolutionDropdown(int resolution)
    {
        PlayerPrefs.SetInt("resolution", resolution);
    }

    public void SaveResolutionButton()
    {
        int resolutionValue = resolutionDropdown.value;
        PlayerPrefs.SetInt("resolution", resolutionValue);
        LoadResolutionValue();
    }

    void LoadResolutionValue()
    {
        int resolutionValue = PlayerPrefs.GetInt("resolution");
        resolutionDropdown.value = resolutionValue;
    }

}
