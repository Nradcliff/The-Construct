using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreThrow : MonoBehaviour 
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject Core;
    public Transform CoreSpawn;
    public GameObject[] CoreList;
    public float LaunchForce;
    public int num;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }

        CoreList = GameObject.FindGameObjectsWithTag("Core");
        if (CoreList[num])
        {
            if(num == 1)
                Destroy(CoreList[num - 1]);
        }
    }

    void Throw()
    {
        GameObject CoreIns = Instantiate(Core, CoreSpawn.position, Quaternion.identity);
        CoreIns.GetComponent<Rigidbody>().velocity = transform.right * LaunchForce;
    }
  
}