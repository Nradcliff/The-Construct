using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreThrow : MonoBehaviour 
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject Core;
    public GameObject projection;
    public Transform CoreSpawn;
    public GameObject[] CoreList;
    public float LaunchForce;
    public int num;
    public AudioSource throwSound;

    Vector3 currentPosition;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("SecondaryCam").GetComponent<Camera>();
        currentPosition = CoreSpawn.transform.position;

        predict();
    }

    public Vector3 calculateForce()
    {
        return transform.right * LaunchForce;
    }
    
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetKey(KeyCode.Mouse1))
        {

            if (currentPosition != transform.position)
            {
                projection.GetComponent<LineRenderer>().enabled = true;
                predict();
            }
        }
        else
        {
           projection.GetComponent<LineRenderer>().enabled = false;
           predict();
        }

        if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.Mouse1))
        {
            Throw();
            throwSound.Play();
        }

        CoreList = GameObject.FindGameObjectsWithTag("Core");
        if (CoreList[num])
        {
            if(num == 1)
            {
                Destroy(CoreList[0]);
            }
        }   
    }

    void Throw()
    {
        GameObject CoreIns = Instantiate(Core, CoreSpawn.position, Quaternion.identity);
        CoreIns.GetComponent<Rigidbody>().velocity = transform.right * LaunchForce;
    }

    void predict(){
        PredictionManager.instance.predict(Core, CoreSpawn.transform.position, calculateForce());
    }
  
}