using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
	public GameObject explosion;
	public string enemyTagName = "Enemies";

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter (Collision collision)
	{
		if (!collision.gameObject.CompareTag (enemyTagName))
			return;

		Instantiate (explosion, collision.gameObject.transform.position, explosion.transform.rotation);
		Destroy (collision.gameObject);
	}
}
