using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float power = 10;
    public float thrust = 5;
    private Vector3 velocity;
    [SerializeField] private int NumOfBounces = 2;
    private int curBounces = 0;


    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if(rb != null && rb != GameObject.Find("Player").GetComponent<Rigidbody>())
        {
            Reflect(rb, collision.contacts[0].normal);
            rb.AddForce(power, thrust, 0, ForceMode.Impulse);
            curBounces++;
        }
    }

    private void Reflect(Rigidbody rb, Vector3 reflectVector)
    {
        velocity = Vector3.Reflect(velocity, reflectVector);
        rb.velocity = velocity;
    }

}
