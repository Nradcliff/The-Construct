using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IS COLLIDE");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("IS TOUCH");
            player.transform.position = respawnPoint.transform.position;
            player.GetComponent<LivesCounter>().loseLife();
        }
    }


}
