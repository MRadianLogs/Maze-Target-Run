using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject mainMenuSelection;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Slider mouseSensitivitySlider;
    [SerializeField] private Text mouseSensitivityValueText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text musicVolumeValueText;
    private const string playerMouseSensitivity = "playerMouseSensitivity";
    private const string musicVolume = "musicVolume";

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //Check for player settings.
        if (PlayerPrefs.HasKey(playerMouseSensitivity)) //If there is player settings stored.
        {
            //Load + Set those settings.
            SetMouseSensitivity(PlayerPrefs.GetFloat(playerMouseSensitivity));
            mouseSensitivitySlider.value = PlayerPrefs.GetFloat(playerMouseSensitivity);
        }
        if(PlayerPrefs.HasKey(musicVolume))
        {
            SetVolumeLevel(PlayerPrefs.GetFloat(musicVolume));
            volumeSlider.value = PlayerPrefs.GetFloat(musicVolume);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettingsMenu()
    {
        mainMenuSelection.SetActive(false);
        //Load playerprefs.

        settingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();//Exits the game.
    }

    public void CloseSettingsMenu()
    {
        mainMenuSelection.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SetMouseSensitivity(float newMouseSensitivity)
    {
        gameManager.SetPlayerMouseSensitivity(newMouseSensitivity);
        mouseSensitivityValueText.text = newMouseSensitivity.ToString();
    }

    public void SetMouseSensitivityWSlider()
    {
        float playerSensitivity = mouseSensitivitySlider.value;
        gameManager.SetPlayerMouseSensitivity(playerSensitivity);
        //Update PlayerPrefs.
        PlayerPrefs.SetFloat(playerMouseSensitivity,playerSensitivity);
        mouseSensitivityValueText.text = playerSensitivity.ToString();
    }

    public void SetVolumeLevel(float newVolumeLevel)
    {
        //Change volume!
        gameManager.GetComponent<AudioSource>().volume = (newVolumeLevel/100);
        musicVolumeValueText.text = newVolumeLevel.ToString() + "%";
    }

    public void SetVolumeLevelWSlider()
    {
        float volumeLevel = volumeSlider.value;
        //Update PlayerPrefs.
        PlayerPrefs.SetFloat(musicVolume,volumeLevel);//Change to int?
        gameManager.GetComponent<AudioSource>().volume = (volumeLevel/100);
        musicVolumeValueText.text = volumeLevel.ToString() + "%";
    }
}
