using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;
    public AudioSource keyPickupSound;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItems(itemType);
            keyPickupSound.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}
