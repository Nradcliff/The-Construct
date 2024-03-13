using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform player;
    public Transform core;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
           player.transform.position = core.transform.position;
           Destroy(GameObject.Find("AimPoint").GetComponent<CoreThrow>().CoreList[0], 0.05f);
        }
    }
}
