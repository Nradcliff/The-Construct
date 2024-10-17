using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool isDoorOpen = false;
    public bool isDoorOpenHorizontal = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    Vector3 doorOpenHorizontalPos;
    float doorSpeed = 10f;
    public AudioSource doorSound;

    // Start is called before the first frame update
    void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        doorOpenHorizontalPos = new Vector3(transform.position.x + 6f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorOpen || isDoorOpenHorizontal)
        {
            OpenDoor();
        }
        else if (!isDoorOpen || !isDoorOpenHorizontal)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if ((transform.position != doorOpenPos) && isDoorOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorSpeed * Time.deltaTime);
            doorSound.pitch = 1f;
            doorSound.Play();
        }
        else if ((transform.position != doorOpenHorizontalPos) && isDoorOpenHorizontal)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenHorizontalPos, doorSpeed * Time.deltaTime);
            doorSound.pitch = 1f;
            doorSound.Play();
        }
        
    }

    void CloseDoor()
    {
        if (transform.position != doorClosedPos);
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, doorSpeed * Time.deltaTime);
            //doorSound.pitch = -1f;
           // doorSound.timeSamples = doorSound.clip.samples - 1;
            //doorSound.Play();
        }
    }
    
}
