using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private float playerMouseSensitivity = 100;//Default value only used if game not started from start screen. Issue from game over screen?
    [SerializeField] private float musicVolume = 100; //Default value only used if game not started from start screen. Issue?

    [SerializeField] private float timeLeftAfterLevel = -100f;
    [SerializeField] private float playerScore = -100f;

    private void Awake()
    {
        if(gameManager != null && gameManager != this) //If a game manager already exists,
        {
            Destroy(gameObject); //This one is not needed! Destroy it Frodo!
        }
        else //Make this one the game manager.
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void SetPlayerMouseSensitivity(float newPlayerMouseSensitivity)
    {
        playerMouseSensitivity = newPlayerMouseSensitivity;
    }
    public float GetPlayerMouseSensitivty()
    {
        return playerMouseSensitivity;
    }

    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }
    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public void SetPlayerScore(float newPlayerScore)
    {
        playerScore = newPlayerScore;
    }
    public float GetPlayerScore()
    {
        return playerScore;
    }
    public void SetTimeLeftAfterLevel(float newTimeLeft)
    {
        timeLeftAfterLevel = newTimeLeft;
    }
    public float GetTimeLeftAfterLevel()
    {
        return timeLeftAfterLevel;
    }
}
