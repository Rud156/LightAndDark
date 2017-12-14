using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDestroy : MonoBehaviour
{
	public string colliderTagName = "TurnPoints";

	void OnTriggerEnter (Collider other)
	{
		if (!other.CompareTag (colliderTagName))
			return;

		Destroy (gameObject);
	}
}
