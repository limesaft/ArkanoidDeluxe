using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public void LoadState(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void QuitTheGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();  
    }
    
    public void LoadNextPlayLevel()
    {
        BrickHitScript.breakableCount = 0;
        SceneManager.LoadScene(Application.loadedLevel + 1, LoadSceneMode.Single);
    }
    
    public void BrickDestroyed(int breakableCount)
    {
        if (breakableCount < 1) 
        {
            LoadNextPlayLevel();
        }
    }
}
