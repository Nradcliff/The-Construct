using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{
	public GameObject player;
    public Transform respawnPoint;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.CompareTag("Hazard"))
		{
			RigidBodies(hit);
		}
		
	}

	private void RigidBodies(ControllerColliderHit hit)
	{
		// make sure we hit a non kinematic rigidbody
		Rigidbody body = hit.collider.attachedRigidbody;
        Debug.Log("IS TOUCH");
        player.transform.position = respawnPoint.position;
        player.GetComponent<LivesCounter>().loseLife();
		
	}
}