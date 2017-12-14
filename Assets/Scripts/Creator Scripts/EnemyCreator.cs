using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour {
    public Material lightMaterial;
    public Material darkMaterial;
    public GameObject player;

    public float minEnemyProbability = 0.4f;


    public GameObject[] enemies;
    private float enemyProbability;

    private List<GameObject> createdEnemies;

    public void CreateEnemies(List<Vector3> enemyPoints) {
        enemyProbability = Mathf.Clamp01(LevelDataStore.currentLevel / 15);
        enemyProbability = enemyProbability < minEnemyProbability ? minEnemyProbability : enemyProbability;
        createdEnemies = new List<GameObject>();

        for (int i = 0; i < enemyPoints.Count; i++) {
            float randomValue = Random.value;

            if (randomValue < enemyProbability) {
                int randomIndex = Mathf.FloorToInt(Random.value * enemies.Length);

                float enemyScale = Random.Range(0.5f, 1);
                GameObject enemy = Instantiate(
                                       enemies[randomIndex], 
                                       enemyPoints[i] + Vector3.up * (-1 + 0.5f + enemyScale / 2), 
                                       Quaternion.identity
                                   ) as GameObject;
                enemy.transform.localScale = Vector3.one * enemyScale;

                EnemyShooter eS = enemy.GetComponent <EnemyShooter>();
                if (eS != null) {
                    eS.setPlayer(ref player);
                }

                if (Random.value < 0.5) {
                    enemy.GetComponent <Renderer>().material = lightMaterial;
                    enemy.tag = "LightGround";
                } else {
                    enemy.GetComponent <Renderer>().material = darkMaterial;
                    enemy.tag = "DarkGround";
                }

                createdEnemies.Add(enemy);
            }
        }
    }
}
