using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool cameFromMain;
    public GameObject optionMenuPrefab;
    private GameObject optionMenu;

    private void Start()
    {
        GameObject parent = GameObject.Find("Canvas");
        optionMenu = Instantiate(optionMenuPrefab, parent.transform);
        int resolutionIndex = PlayerPrefs.GetInt("resolution", -1);
        if (resolutionIndex != -1)
        {
            Debug.Log(resolutionIndex);
            optionMenu.GetComponent<OptionsMenu>().FirstResolutionSetup();
            optionMenu.GetComponent<OptionsMenu>().SetResolution(resolutionIndex);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void Options()
    {
        cameFromMain = true;
        optionMenu.SetActive(true);
        Debug.Log("loading options");
    
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
