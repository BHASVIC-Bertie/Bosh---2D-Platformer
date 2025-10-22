using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool isPaused;
    
    void Pause()
    {
        if (Input.GetKey("escape") && !isPaused)
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
        unPause();
    }
}
