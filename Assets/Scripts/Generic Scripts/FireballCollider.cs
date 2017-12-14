using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollider : MonoBehaviour {
	public GameObject explosion;
	public float explosionForce = 50;

	private float objectScale;

	// Use this for initialization
	void Start() {
		objectScale = gameObject.transform.localScale.x;
	}

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag("Player"))
			return;

		Store store = other.GetComponent <Store>();

		store.DecreasePlayerHealth(objectScale * store.decreaseMultiplier);
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		Rigidbody target = other.GetComponent <Rigidbody>();

		float sign = Mathf.Sign(gameObject.transform.position.z - other.transform.position.z);

		target.AddForce(Vector3.back * sign * explosionForce, ForceMode.VelocityChange);
		Destroy(gameObject);
	}
}
