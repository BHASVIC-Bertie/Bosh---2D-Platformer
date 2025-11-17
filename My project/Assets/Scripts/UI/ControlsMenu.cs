using UnityEngine;
using UnityEngine.UI;
public class ControlsMenu : StartMenu
{
    //opens the settings menu
    public void SettingsActive()
    {
        Controls.SetActive(false);
        Settings.SetActive(true);
    }
    private void Update()
    {
        BackButton.onClick.AddListener(SettingsActive);
    }
}
