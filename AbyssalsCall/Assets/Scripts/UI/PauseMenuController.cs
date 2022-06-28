using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    //public MenuSceneController menuController;
    public bool GameIsPaused;
    private CursorLockMode lastCursorLockMode;
    private bool cursorWasLocked;
    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
            Resume();
            }
            else
            {
            Pause();
            }
        }

        if(Input.GetKey(KeyCode.F12))
        {
            GameSceneManager.Instance.LoadScene("MapDisplayScene");
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = lastCursorLockMode;
        Cursor.visible = cursorWasLocked;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        lastCursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;
        cursorWasLocked = Cursor.visible;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
