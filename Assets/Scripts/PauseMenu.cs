using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
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
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void OptionsMenu()
    {
        Debug.Log("loading options");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

}
