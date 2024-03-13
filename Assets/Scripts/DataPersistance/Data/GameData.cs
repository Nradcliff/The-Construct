using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class GameData
{
   // public int currentLevel;
    public int currentLife;
    public Vector3 playerPosition;

    public GameData()
    {
        //this.currentLevel = 1;
        this.currentLife = 3;
        playerPosition = GameObject.Find("RespawnPoint").transform.position;
    }
}
