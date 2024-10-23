using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
     [SerializeField] DoorBehavior doorBehavior;
    [SerializeField] bool isDoorOpenPlate;
    [SerializeField] bool isDoorOpenHorizontalPlate;

    float plateSizeY;
    Vector3 plateUpPos;
    Vector3 plateDownPos;
    float plateSpeed = 1f;
    float plateDelay = 0.2f;
    bool isPressingPlate = false;
    public AudioSource plateActivatedSound;

    // Start is called before the first frame update
    void Awake()
    {
        plateSizeY = transform.localScale.y / 2;

        plateUpPos = transform.position;
        plateDownPos = new Vector3(transform.position.x, transform.position.y - plateSizeY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressingPlate)
        {
            MovePlateDown();
            
        }
        else if (!isPressingPlate)
        {
            MovePlateUp();
        }
    }

    void MovePlateDown()
    {
        if (transform.position != plateDownPos);
        {
            transform.position = Vector3.MoveTowards(transform.position, plateDownPos, plateSpeed * Time.deltaTime);
            
        }
    }

    void MovePlateUp()
    {
        if (transform.position != plateUpPos);
        {
            transform.position = Vector3.MoveTowards(transform.position, plateUpPos, plateSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressingPlate = !isPressingPlate;
            if (isDoorOpenPlate && !doorBehavior.isDoorOpen)
            {
                doorBehavior.isDoorOpen = !doorBehavior.isDoorOpen;
                plateActivatedSound.Play();
            }
            else if (isDoorOpenHorizontalPlate && !doorBehavior.isDoorOpenHorizontal)
            {
                doorBehavior.isDoorOpenHorizontal = !doorBehavior.isDoorOpenHorizontal;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (isDoorOpenPlate && doorBehavior.isDoorOpen)
            {
                doorBehavior.isDoorOpen = !doorBehavior.isDoorOpen;
            }
            else if (isDoorOpenHorizontalPlate && doorBehavior.isDoorOpenHorizontal)
            {
                doorBehavior.isDoorOpenHorizontal = !doorBehavior.isDoorOpenHorizontal;
            }
            StartCoroutine(PlateUpDelay(plateDelay));
        }
    }

    IEnumerator PlateUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isPressingPlate = false;
    }
}
