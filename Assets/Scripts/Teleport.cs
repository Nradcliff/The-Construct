using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform player;
    public Transform core;
    public LayerMask boundryDetect;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(core.transform.position, 1);
        if (Input.GetKeyDown("t"))
        {
            if (hitColliders.Length >= 3)
            {
                return;
            }
            else
            {
            player.transform.position = core.transform.position;
            Destroy(GameObject.Find("AimPoint").GetComponent<CoreThrow>().CoreList[0], 0.05f);
            }
        }
    }  
}
