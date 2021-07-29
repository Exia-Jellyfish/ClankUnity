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
        InitializeResolution();
    }

    private void InitializeResolution()
    {
        optionMenu = Instantiate(optionMenuPrefab, GameObject.Find("Canvas").transform);
        if (OptionsStorage.HasResolution())
        {
            optionMenu.GetComponent<OptionsMenu>().FirstResolutionSetup();
            optionMenu.GetComponent<OptionsMenu>().SetResolution(OptionsStorage.GetResolution());
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
