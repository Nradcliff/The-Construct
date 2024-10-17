using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("lvl 1");
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void MainReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
