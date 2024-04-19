using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Starting Level");
    }

    public void LoadGame()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}