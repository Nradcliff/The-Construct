using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int lvl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene() 
    {
        SceneManager.LoadScene("Lvl " + lvl.ToString());
    }
}
