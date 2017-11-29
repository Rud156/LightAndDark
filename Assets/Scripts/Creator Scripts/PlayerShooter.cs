using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
	public GameObject fireballBullet;
	public float zVelocity = 10;
	public float yVelocity = 1f;
	public float breathingSpace = 0.3f;


	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			var position = gameObject.transform.position;

			GameObject bullet = Instantiate (fireballBullet, 
				                    new Vector3 (position.x, position.y, position.z + breathingSpace), 
				                    Quaternion.identity) as GameObject;
			Rigidbody target = bullet.GetComponent <Rigidbody> ();
			target.velocity = new Vector3 (0, yVelocity, zVelocity);
		}	
	}
}
