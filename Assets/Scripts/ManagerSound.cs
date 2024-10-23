using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSound : MonoBehaviour
{
    public AudioSource teleportSound;
    public AudioSource keyPickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallTeleportSound()
    {
        teleportSound.Play();
    }


    public void CallKeyPickUpSound()
    {
        keyPickUpSound.Play();
    }
}
