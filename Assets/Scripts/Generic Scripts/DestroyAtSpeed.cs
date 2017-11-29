using UnityEngine;

public class DestroyAtSpeed : MonoBehaviour
{
	public float minSpeed = 2;
	public float speedReductionAmount = 0.1f;

	private Rigidbody target;
	private bool layerSet = false;

	// Use this for initialization
	private void Start ()
	{
		target = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	private void FixedUpdate ()
	{
		var speed = target.velocity.z;
		if (speed <= minSpeed)
			Destroy (gameObject);

		if (layerSet)
			target.velocity -= Vector3.forward * speedReductionAmount;
	}

	private void OnCollisionEnter (Collision collision)
	{
		if (!layerSet) {
			gameObject.layer = 8;
			layerSet = true;
		}
	}
}