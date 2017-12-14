using System.Collections.Generic;
using UnityEngine;

public class GroundCreator : MonoBehaviour {
    public string endPointName = "AttachEndPoint";
    public string enemyPointName = "EnemyPoint";

    public GameObject[] flatGrounds;
    public GameObject[] slopes;
    public GameObject[] emptySpaces;
    public GameObject[] enemyGrounds;

    private List<GameObject> createdGrounds;
    private List<Vector3> enemyPoints;
    private GameObject prevGround;

    private int totalGrounds;

    // Use this for initialization
    private void Start() {
        prevGround = null;
        createdGrounds = new List<GameObject>();
        enemyPoints = new List<Vector3>();

        totalGrounds = Random.Range(LevelDataStore.currentLevelMinGrounds, LevelDataStore.currentLevelMaxGrounds);
        CreateGrounds();
    }

    private void CreateGrounds() {
        for (int i = 0; i < totalGrounds; i++) {
            float randomValue = Random.value;
            GameObject ground;
            Vector3 position = i == 0 ? gameObject.transform.position :
                prevGround.transform.Find(endPointName).position;

            if (randomValue < 0.3) {
                int randomGround = Mathf.FloorToInt(Random.value * (emptySpaces.Length));
                ground = Instantiate(emptySpaces[randomGround], position, Quaternion.identity) as GameObject;
            } else if (randomValue < 0.5) {
                int randomGround = Mathf.FloorToInt(Random.value * (slopes.Length));
                ground = Instantiate(slopes[randomGround], position, Quaternion.identity) as GameObject;
            } else if (randomValue < 0.7) {
                int randomGround = Mathf.FloorToInt(Random.value * (flatGrounds.Length));
                ground = Instantiate(flatGrounds[randomGround], position, Quaternion.identity) as GameObject;
            } else {
                int randomGround = Mathf.FloorToInt(Random.value * (enemyGrounds.Length));
                ground = Instantiate(enemyGrounds[randomGround], position, Quaternion.identity) as GameObject;
            }

            Transform enemyPoint = ground.transform.Find(enemyPointName);
            if (enemyPoint != null)
                enemyPoints.Add(enemyPoint.position);

            prevGround = ground;
            createdGrounds.Add(ground);
        }

        gameObject.GetComponent <EnemyCreator>().CreateEnemies(enemyPoints);
    }
}