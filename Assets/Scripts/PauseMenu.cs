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

    private void Start()
    {
        GameObject parent = GameObject.Find("Canvas");
        optionMenu = Instantiate(optionMenuPrefab, parent.transform);
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
        Cursor.lockState = CursorLockMode.Locked;
        optionMenu.SetActive(false);
        InGameOptions = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void OptionsMenu()
    {
        InGameOptions = true;
        optionMenu.SetActive(true);
        Debug.Log("loading options");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

}
