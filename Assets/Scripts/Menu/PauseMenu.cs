using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool InGameOptions = false;

    public GameObject pauseMenuUI;
    public GameObject optionMenuPrefab;
    private GameObject optionMenu;
    private GameObject crosshair;

    private void Start()
    {
        optionMenu = Instantiate(optionMenuPrefab, GameObject.Find("Canvas").transform);
        crosshair = GameObject.Find("Crosshair");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (!GameIsPaused && InGameOptions == false)
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        optionMenu.SetActive(false);
        InGameOptions = false;
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(true);
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        crosshair.SetActive(false);
    }

    public void OptionsMenu()
    {
        InGameOptions = true;
        optionMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
