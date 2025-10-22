using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : StartMenu
{
    public Button ControlsButton;

//opens controls settings 
    private void ControlsActive()
    {
        Controls.SetActive(true);
    }
    
    private void Update()
    {
        ControlsButton.onClick.AddListener(ControlsActive);
        BackButton.onClick.AddListener(StartMenuActive);
    }
}
