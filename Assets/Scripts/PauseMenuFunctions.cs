using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuFunctions : MonoBehaviour
{
    private static bool gameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject player;

    void Start()
    {
        gameIsPaused = false;    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);//Brings up menu.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponentInChildren<PlayerGunMechanics>().enabled = false;
        Time.timeScale = 0f; //Stops game.
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);//Hides menu.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponentInChildren<PlayerGunMechanics>().enabled = true;
        Time.timeScale = 1f; //Resumes game.
        gameIsPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
