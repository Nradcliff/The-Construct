using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;
    public AudioSource keyPickupSound;
    private ManagerSound ManagerSound;

    void Awake()
    {
        ManagerSound = GameObject.FindGameObjectWithTag("Sound").GetComponent<ManagerSound>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItems(itemType);
            ManagerSound.CallKeyPickUpSound();
            Destroy(gameObject);
        }
    }
}
