using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CorePhysics : PoolableObject
{
    [SerializeField] private Rigidbody core;
    public GameObject CORE;
    public PoolableObject Impact;
    public AudioSource CollideSound;
 
    void Awake()
    {
        core = GetComponent<Rigidbody>();
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (!CORE.CompareTag("dummy"))
        {
            ContactPoint contact = collision.GetContact(0);

            ObjectPool pool = ObjectPool.CreateInstance(Impact, 5);
            PoolableObject pooledObject = pool.GetObject();

            pooledObject.transform.position = contact.point;
            pooledObject.transform.right = contact.normal;

            if(collision.gameObject.name != "Player")
            {
                CollideSound.Play();
            }
        }
    }
}
