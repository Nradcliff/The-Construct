using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorePhysics : MonoBehaviour
{

    [SerializeField] private Rigidbody Core;
    private Vector3 velocity;
    public float thrust;
    public float power;
    bool done;
    [SerializeField] private int NumOfBounces = 2;
    private int curBounces = 0;
 
    void Start ()
    {
        Core = GetComponent<Rigidbody>();
        velocity = Core.velocity;
    }
 
   void OnCollisionEnter(Collision collision)
    {
        //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //Vector3 dir = collision.contacts[0].normal;

        if(Core != null /*&& curBounces < NumOfBounces*/)
        {
            Reflect(Core, collision.contacts[0].normal);
            Core.AddForce(power, thrust, 0, ForceMode.VelocityChange);
            curBounces++;
        }
    }

    private void Reflect(Rigidbody rb, Vector3 reflectVector)
    {
        velocity = Vector3.Reflect(velocity, reflectVector);
        rb.velocity = velocity;
    }
}
