using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : MonoBehaviour {
    public string colliderTagName = "TurnPoints";
    public float movementSpeed = 10;
    public float maxVelocity = 10;
    public float reverseSpeed = 100;

    private Rigidbody target;
    private bool moveForward = false;
    private bool stopMovement = false;

    // Use this for initialization
    void Start() {
        target = gameObject.GetComponent <Rigidbody>();
    }

    void FixedUpdate() {
        if (Mathf.Abs(target.velocity.z) >= maxVelocity || stopMovement)
            return;
		
        if (moveForward)
            target.velocity += Vector3.forward * movementSpeed * Time.deltaTime;
        else
            target.velocity += Vector3.back * movementSpeed * Time.deltaTime;	
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(colliderTagName))
            return;

        stopMovement = true;

        target.velocity = Vector3.zero;
        if (moveForward)
            target.velocity = Vector3.back * reverseSpeed * Time.deltaTime;
        else
            target.velocity = Vector3.forward * reverseSpeed * Time.deltaTime;
        moveForward = !moveForward;

        stopMovement = false;
    }
}
