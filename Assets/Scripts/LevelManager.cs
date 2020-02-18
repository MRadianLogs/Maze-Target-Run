using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject player = null;

    [SerializeField] private int numTargetsLeft = 0;
    [SerializeField] private float timeLeft = 15f;
    [SerializeField] private Text timeLeftText = null;
    [SerializeField] private Text playerPointsText = null;
    [SerializeField] private Text targetsLeftText = null;

    private void Awake()
    {
        //Set player settings from gameManager.
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SetPlayerMouseSensitivity(gameManager.GetPlayerMouseSensitivty());
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //player = GameObject.FindGameObjectWithTag("Player");
        timeLeftText.text = timeLeft.ToString();
        targetsLeftText.text = numTargetsLeft.ToString();
        StartCoroutine(TickTime());
    }

    IEnumerator TickTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft -= 1;
            timeLeftText.text = timeLeft.ToString();
            if (timeLeft == 0)
            {
                //End Game. Change scene to game over scene.
                Debug.Log("Times up!");
                SetAfterLevelData();
                SceneManager.LoadScene(2);
            }
        }
    }

    public void DecrementTargetCount()
    {
        numTargetsLeft -= 1;
        targetsLeftText.text = numTargetsLeft.ToString();
        if (numTargetsLeft == 0)
        {
            //End game. Change scene to game over scene.
            Debug.Log("All targets gone!");
            SetAfterLevelData();
            SceneManager.LoadScene(2);
        }
    }

    public void IncrementPlayerPoints(int pointsValue)
    {
        player.GetComponent<PlayerBehavior>().incrementPoints(pointsValue);
        DisplayPlayerPoints();
    }
    private void DisplayPlayerPoints()
    {
        playerPointsText.text = player.GetComponent<PlayerBehavior>().PlayerPoints().ToString();
    }

    public void SetPlayerMouseSensitivity(float newPlayerMouseSensitivity)
    {
        player.GetComponent<ShooterPlayerViewController>().SetMouseSensitivity(newPlayerMouseSensitivity);
    }

    private void SetAfterLevelData()
    {
        gameManager.SetPlayerScore(player.GetComponent<PlayerBehavior>().PlayerPoints());
        gameManager.SetTimeLeftAfterLevel(timeLeft);
    }
}
