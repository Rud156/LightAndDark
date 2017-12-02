using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
	public GameObject[] enemies;

	private List<GameObject> createdEnemies;

	public void Start ()
	{
		createdEnemies = new List<GameObject> ();
	}

	public void CreateEnemies (List<Vector3> enemyPoints)
	{
		for (int i = 0; i < enemyPoints.Count; i++) {
			float randomValue = Random.value;

			if (randomValue < 0.5) {
				int randomIndex = Mathf.FloorToInt (Random.value * enemies.Length);
				GameObject enemy = Instantiate (enemies [randomIndex], enemyPoints [i], Quaternion.identity) as GameObject;
				createdEnemies.Add (enemy);
			}
		}
	}
}
