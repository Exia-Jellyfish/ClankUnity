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
        LoadVolumeValue();
        LoadGraphicsValue();
        FirstResolutionSetup();
        LoadResolutionValue();
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
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
        PlayerPrefs.SetInt("graphics", graphicsIndex);
    }

    public void BackButton()
    {
        if (MainMenu.cameFromMain == true)
        {
            Debug.Log("78");
            GameObject.Find("Canvas").transform.Find("MainMenu").gameObject.SetActive(true);
            MainMenu.cameFromMain = false;
        }
        else
        {
            Debug.Log("93");
            GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.SetActive(true);
        }
            gameObject.SetActive(false);
    }


    public void OutOfInGameOptions()
    {
        PauseMenu.InGameOptions = false;
    }

    //Saving and loading graphics prefs
    public void SaveGraphicsButton()
    {
        int graphicsValue = graphicsDropdown.value;
        PlayerPrefs.SetInt("graphics", graphicsValue);
        LoadGraphicsValue();
    }

    void LoadGraphicsValue()
    {
        int graphicsValue = PlayerPrefs.GetInt("graphics");
        graphicsDropdown.value = graphicsValue;
    }

    //Saving and loading volume prefs
    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeValue);
        LoadVolumeValue();
    }
    void LoadVolumeValue()
    {
        float volumeValue = PlayerPrefs.GetFloat("volume");
        volumeSlider.value = volumeValue;
        audioMixer.SetFloat("volume", volumeValue);
    }

    //Saving and loading resolution prefs
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
