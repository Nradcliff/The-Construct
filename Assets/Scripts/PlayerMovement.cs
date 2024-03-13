using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistance
{ 
    public bool disabled = false;
    public float speed;
    public float jump;

    private float move;
    private Rigidbody body;
    private bool isJumping;

    Vector3 Direction;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
      
        move = Input.GetAxis("Horizontal");

        body.velocity = new Vector3(move * speed, body.velocity.y, body.velocity.z);
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            body.AddForce(new Vector3(body.velocity.x, jump));
            isJumping = true;
        }  
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    Vector3 PointPosition(float t) {
        {
            Vector3 currentPointPos = (Vector3)transform.position + (Direction * force * t) + 0.5f * Physics.gravity * (t * t);

            return currentPointPos;
        }
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

}
