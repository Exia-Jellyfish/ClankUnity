using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;


    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, false);
    }


    public float SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        return volume;
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
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
}
