using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused;
    
    void Start()
    {
        StartCoroutine(CheckForPause());
    }
    void Pause()
    {
        if (Input.GetButton("Cancel") && !isPaused)
        {
            print("PAUSE");
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    void unPause()
    {
        if (Input.GetKey("escape") && isPaused)
        {
            print("UNPAUSE");
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
    
    void Update()
    {
        Pause();

    }
    
    // checks every 0.1 seconds
    IEnumerator CheckForPause()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); 
            unPause();
        }
        
    }
}
