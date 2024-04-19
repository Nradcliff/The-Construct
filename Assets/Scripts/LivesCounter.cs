using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour, IDataPersistance
{
  public Image[] lives;
  public int currentLife;

  public void loseLife()
  {
        if (currentLife == 0)
        {
            return;
        }
        currentLife--;
        lives[currentLife].enabled = false;

        if(currentLife == 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
  }

  public void LoadData(GameData data)
  {
      this.currentLife = data.currentLife;
  }

  public void SaveData(ref GameData data)
  {
      data.currentLife = this.currentLife;
  }
   
}
