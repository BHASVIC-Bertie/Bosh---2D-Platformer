using System;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button PlayButton, SettingsButton, BackButton;
    public GameObject Menu, Settings, Controls;
    public bool isPaused;
    private void Start()
    {
        Time.timeScale = 0f;
        Menu.SetActive(true);
        Settings.SetActive(false);
        Controls.SetActive(false);
;
    }
    
    private void Update()
      {
          SettingsButton.onClick.AddListener(GameSettingsActive);
          PlayButton.onClick.AddListener(GameStart);
      }
    //Panel Modifiers
//starts the game - allows for movement and removes the UI panels
    private void GameStart()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Menu.SetActive(false);
        Settings.SetActive(false);
        Controls.SetActive(false);
    }
//opens settings
    private void GameSettingsActive()
    {
        Menu.SetActive(false);
        Settings.SetActive(true);
    }
//opens the start menu
    public void StartMenuActive()
    {
             Menu.SetActive(true);
             Settings.SetActive(false); 
             Controls.SetActive(false);
    }
}
