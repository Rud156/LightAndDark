using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
	public GameObject fireball;
	public Material lightMaterial;
	public Material darkMaterial;
	public float shootVelocity = 100;
	public float minDetectDistance = 20;
	[Range (0, 1)]
	public float randomRange = 0.3f;

	public GameObject player;


	public void setPlayer (ref GameObject player)
	{
		this.player = player;
	}

	void FixedUpdate ()
	{
		if (Mathf.Abs (gameObject.transform.position.z - player.transform.position.z) > minDetectDistance)
			return;
		
		float randomValue = Random.value;
		if (randomValue < randomRange) {
			GameObject basicFireball = Instantiate (fireball, gameObject.transform.position, Quaternion.identity);
			basicFireball.transform.localScale = Vector3.one * gameObject.transform.localScale.x / 2;

			if (gameObject.transform.position.z < player.transform.position.z)
				basicFireball.GetComponent <Rigidbody> ().velocity = Vector3.forward * shootVelocity * Time.deltaTime;
			else
				basicFireball.GetComponent <Rigidbody> ().velocity = Vector3.back * shootVelocity * Time.deltaTime;

			if (player.layer == 14) {
				basicFireball.GetComponent <Renderer> ().material = lightMaterial;
				basicFireball.layer = 13;
			} else {
				basicFireball.GetComponent <Renderer> ().material = darkMaterial;
				basicFireball.layer = 14;
			}
		}
	}
}
