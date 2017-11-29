using System.Collections.Generic;
using UnityEngine;

public class GroundCreator : MonoBehaviour
{
	[Range (7, 50)]
	public int totalGrounds = 30;
	public string endPointName = "AttachEndPoint";

	public GameObject[] flatGrounds;
	public GameObject[] slopes;
	public GameObject[] emptySpaces;
	public GameObject[] enemyGrounds;

	private List<GameObject> createdGrounds;
	private GameObject prevGround;

	// Use this for initialization
	private void Start ()
	{
		prevGround = null;
		createdGrounds = new List<GameObject> ();
		CreateGrounds ();

		Store.setCheckPoint (new Vector3 (0, 3, 1));
	}

	private void CreateGrounds ()
	{
		for (int i = 0; i < totalGrounds; i++) {
			float randomValue = Random.value;
			GameObject ground;
			Vector3 position = i == 0 ? gameObject.transform.position :
                prevGround.transform.Find (endPointName).position;

			if (randomValue < 0.3) {
				int randomGround = Mathf.FloorToInt (Random.value * (emptySpaces.Length));
				ground = Instantiate (emptySpaces [randomGround], position, Quaternion.identity) as GameObject;
			} else if (randomValue < 0.5) {
				int randomGround = Mathf.FloorToInt (Random.value * (slopes.Length));
				ground = Instantiate (slopes [randomGround], position, Quaternion.identity) as GameObject;
			} else if (randomValue < 0.7) {
				int randomGround = Mathf.FloorToInt (Random.value * (flatGrounds.Length));
				ground = Instantiate (flatGrounds [randomGround], position, Quaternion.identity) as GameObject;
			} else {
				int randomGround = Mathf.FloorToInt (Random.value * (enemyGrounds.Length));
				ground = Instantiate (enemyGrounds [randomGround], position, Quaternion.identity) as GameObject;
			}

			prevGround = ground;
			createdGrounds.Add (ground);
		}
	}
}