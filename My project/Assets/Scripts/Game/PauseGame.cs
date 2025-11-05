using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGame : StartMenu
{
    public bool isPaused;
    public Button ResumeButton;
    void Start()
    {
        //StartCoroutine(CheckForPause());
    }
    void Pause()
    {
        if (Input.GetButton("Cancel") && !isPaused)
        {
            print("PAUSE");
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    
    void unPause()
    {
            print("UNPAUSE");
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
    }
    void Update()
    {
        Pause();
        ResumeButton.onClick.AddListener(unPause);
        
    }
    
    // checks every 0.1 seconds
    /*IEnumerator CheckForPause()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); 
            unPause();
        }
        
    }*/
}
