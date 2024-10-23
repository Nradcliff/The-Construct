using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform player;
    public Transform core;
    public LayerMask boundryDetect;
    public AudioSource TeleportSound;
    private ManagerSound ManagerSound;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        ManagerSound = GameObject.FindGameObjectWithTag("Sound").GetComponent<ManagerSound>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(core.transform.position, 1, boundryDetect);
        if (Input.GetKeyDown("e"))
        {
            if (hitColliders.Length >= 2)
            {
                return;
            }
            else
            {
                player.transform.position = core.transform.position;
                ManagerSound.CallTeleportSound();
                Destroy(GameObject.Find("AimPoint").GetComponent<CoreThrow>().CoreList[0], 0.05f);
            }
        }
    }  
}
