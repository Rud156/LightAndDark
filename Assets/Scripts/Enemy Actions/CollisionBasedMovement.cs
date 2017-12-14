using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBasedMovement : MonoBehaviour
{
	public string colliderTagName = "TurnPoints";
	public float movementSpeed = 100;

	private Rigidbody target;
	private bool moveForward = false;

	// Use this for initialization
	void Start ()
	{
		target = gameObject.GetComponent <Rigidbody> ();
	}

	void FixedUpdate ()
	{
		if (moveForward)
			target.velocity = Vector3.forward * movementSpeed * Time.deltaTime;
		else
			target.velocity = Vector3.back * movementSpeed * Time.deltaTime;
			
	}

	void OnTriggerEnter (Collider other)
	{
		if (!other.CompareTag (colliderTagName))
			return;
		
		moveForward = !moveForward;
	}
}
