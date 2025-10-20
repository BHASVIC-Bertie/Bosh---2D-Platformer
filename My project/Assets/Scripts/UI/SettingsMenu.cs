using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : StartMenu
{
    public Button ControlsButton;
    public GameObject GameControls;

    private void ControlsMenu()
    {
        GameControls.SetActive(false);
        Settings.SetActive(false);
    }
    
    private void Update()
    {
        ControlsButton.onClick.AddListener(ControlsMenu);
        BackButton.onClick.AddListener(StartMenuActive);
    }
}
