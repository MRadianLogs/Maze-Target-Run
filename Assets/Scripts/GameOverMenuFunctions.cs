using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuFunctions : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private Text baseScoreText;
    [SerializeField] private Text timeLeftText;
    [SerializeField] private Text totalScoreText;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        DisplayStats();
    }

    public void replay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void quit()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    public void DisplayStats()
    {
        baseScoreText.text = gameManager.GetPlayerScore().ToString();
        timeLeftText.text = gameManager.GetTimeLeftAfterLevel().ToString();
        totalScoreText.text = (gameManager.GetPlayerScore() + gameManager.GetTimeLeftAfterLevel()).ToString();
    }
}
