using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;



    Resolution[] resolutions;

    void Start()
    {
        FirstResolutionSetup();
        LoadResolution(OptionsStorage.GetResolution());
        LoadVolume(OptionsStorage.GetVolume());
        LoadGraphics(OptionsStorage.GetGraphics());
    }

    public void FirstResolutionSetup()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int currentResolutionIndex)
    {
        Resolution resolution = resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, false);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void BackButton()
    {
        if (MainMenu.cameFromMain == true)
        {
            transform.root.Find("MainMenu").gameObject.SetActive(true);
            MainMenu.cameFromMain = false;
        }
        else
        {
            transform.root.Find("PauseMenu").gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }


    public void OutOfInGameOptions()
    {
        PauseMenu.InGameOptions = false;
    }
    public void SaveButton()
    {
        OptionsStorage.SaveVolume(volumeSlider.value);
        OptionsStorage.SaveGraphics(graphicsDropdown.value);
        OptionsStorage.SaveResolution(resolutionDropdown.value);
    }



    //Loading volume
    private void LoadVolume(float volumeValue)
    {
        volumeSlider.value = volumeValue;
        audioMixer.SetFloat("volume", volumeValue);
    }

    //Saving and loading graphics prefs
    private void LoadGraphics(int graphicsValue)
    {
        graphicsDropdown.value = graphicsValue;
    }

    
    //Loading resolution

    private void LoadResolution(int resolutionIndex)
    {
        resolutionDropdown.value = resolutionIndex;
    }
}
