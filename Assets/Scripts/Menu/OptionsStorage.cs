using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionsStorage
{
    private const string VOLUME_OPTION_NAME = "volume";
    private const string GRAPHICS_OPTION_NAME = "graphics";
    private const string RESOLUTION_OPTION_NAME = "resolution";

    public static void SaveVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat(VOLUME_OPTION_NAME, volumeValue);
    }
    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_OPTION_NAME);
    }


    public static void SaveGraphics(int graphicsValue)
    {
        PlayerPrefs.SetInt(GRAPHICS_OPTION_NAME, graphicsValue);
    }

    public static int GetGraphics()
    {
        return PlayerPrefs.GetInt(GRAPHICS_OPTION_NAME);
    }



    //Resolution dropdown and save&load values.
    public static void SaveResolution(int resolutionValue)
    {
        PlayerPrefs.SetInt(RESOLUTION_OPTION_NAME, resolutionValue);
    }

    public static int GetResolution()
    {
        return PlayerPrefs.GetInt(RESOLUTION_OPTION_NAME);
    }

    public static bool HasResolution()
    {
        return PlayerPrefs.HasKey(RESOLUTION_OPTION_NAME);
    }
}
