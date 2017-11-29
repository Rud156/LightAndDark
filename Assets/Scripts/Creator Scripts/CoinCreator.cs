using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{

	public GameObject[] coins;
	public float heightAbove = 1;
	[Range (0, 1)]
	public float breathingSpace = 0.3f;

	void OnTriggerEnter (Collider other)
	{
		Rigidbody target = other.GetComponent <Rigidbody> ();
		if (!target || !other.CompareTag ("Player")) {
			return;
		}
		
		int randomValue = Mathf.FloorToInt (Random.value * coins.Length);
		Instantiate (coins [randomValue], 
			gameObject.transform.position + Vector3.up * (heightAbove + breathingSpace), 
			coins [randomValue].transform.rotation);
	}
}
