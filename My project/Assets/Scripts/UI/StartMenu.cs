using System;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button PlayButton, SettingsButton, BackButton;
    public GameObject Menu, Settings;

    private void Start()
    {
        Settings.SetActive(false);
    }
    
    private void Update()
      {
          SettingsButton.onClick.AddListener(GameSettings);
          PlayButton.onClick.AddListener(GameStart);
      } 
    //Panel Modifiers
    private void GameStart()
    {
        Menu.SetActive(false);
    }

    private void GameSettings()
    {
        Menu.SetActive(false);
        Settings.SetActive(true);
    }

   
    public void StartMenuActive()
    {
             Menu.SetActive(true);
             Settings.SetActive(false); 
    }
}
