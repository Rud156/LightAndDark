using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class LDGroundCreator : MonoBehaviour {
    public Renderer groundCreator;
    public GameObject player;
    public Vector3 attachPoint;

    public GameObject mainCamera;
    public GameObject directionalLight;


    public Material lightMaterial;
    public Material darkMaterial;

    public string endPointName = "AttachEndPoint";

    public GameObject[] grounds;
    public GameObject endGround;
    public GameObject nextLevelEffect;

    private List<GameObject> createdGrounds;
    private List<GameObject> lightGrounds;
    private List<GameObject> darkGrounds;
    private List<Vector3> enemyPoints;
    private GameObject prevGround;

    private Renderer playerMaterial;

    private Color lightColor;
    private Color darkColor;
    private string enemyPointName = @"EnemyPoint_?.*";
    private Regex regex;

    private int totalGrounds;

    // Use this for initialization
    void Start() {
        regex = new Regex(enemyPointName, RegexOptions.IgnoreCase);
        playerMaterial = player.GetComponent <Renderer>();

        createdGrounds = new List<GameObject>();
        lightGrounds = new List<GameObject>();
        darkGrounds = new List<GameObject>();
        enemyPoints = new List<Vector3>();

        prevGround = null;

        lightColor = lightMaterial.color;
        darkColor = darkMaterial.color;

        SetupPlayer();
        totalGrounds = Random.Range(LevelDataStore.currentLevelMinGrounds, LevelDataStore.currentLevelMaxGrounds);
        CreateGround();
    }

    private void SetupPlayer() {
        float randomNumber = Random.value;
        Store store = player.GetComponent <Store>();
        if (randomNumber < 0.5) {
            groundCreator.material = lightMaterial;
            playerMaterial.material = darkMaterial;
            groundCreator.gameObject.layer = 13;
            playerMaterial.gameObject.layer = 14;
            lightGrounds.Add(groundCreator.gameObject);

            SetupLights(14);
            store.SetPlayerColor(14);
        } else {
            groundCreator.material = darkMaterial;
            playerMaterial.material = lightMaterial;
            groundCreator.gameObject.layer = 14;
            playerMaterial.gameObject.layer = 13;
            darkGrounds.Add(groundCreator.gameObject);

            SetupLights(13);
            store.SetPlayerColor(13);
        }
        createdGrounds.Add(groundCreator.gameObject);
    }

    private void SetupLights(int color) {
        Camera cameraComponent = mainCamera.GetComponent <Camera>();
        Light lightComponent = directionalLight.GetComponent <Light>();
        if (color == 13) {
            lightComponent.color = lightColor;
            cameraComponent.backgroundColor = lightColor;
        } else {
            lightComponent.color = darkColor;
            cameraComponent.backgroundColor = darkColor;
        }
    }

    private void CreateGround() {
        for (int i = 0; i < totalGrounds; i++) {
            int randomGround = Mathf.FloorToInt(Random.value * grounds.Length);

            Vector3 position = i == 0 ? attachPoint :
				prevGround.transform.Find(endPointName).position;

            GameObject ground = Instantiate(grounds[randomGround], position, Quaternion.identity) as GameObject;
            float randomValue = Random.value;
            int numOfChildren = ground.transform.childCount;
            for (int j = 0; j < numOfChildren; j++) {
                GameObject child = ground.transform.GetChild(j).gameObject;
                Renderer renderer = child.GetComponent <Renderer>();
                if (renderer != null) {
                    if (randomValue < 0.5) {
                        renderer.material = lightMaterial;
                        child.layer = 13;
                        lightGrounds.Add(child);
                    } else {
                        renderer.material = darkMaterial;
                        child.layer = 14;
                        darkGrounds.Add(child);
                    }
                }

                Match m = regex.Match(child.name);
                if (m.Success) {
                    Vector3 enemyPoint = child.transform.position;
                    enemyPoints.Add(enemyPoint);
                }
            }

            prevGround = ground;
            createdGrounds.Add(ground);
        }

        AttachEndPoint(prevGround);
        gameObject.GetComponent <EnemyCreator>().CreateEnemies(enemyPoints);
    }

    private void AttachEndPoint(GameObject prevGround) {
        GameObject end = Instantiate(endGround, prevGround.transform.Find(endPointName).position, Quaternion.identity)
            as GameObject;
        int childCount = end.transform.childCount;
        float randomValue = Random.value;
        for (int i = 0; i < childCount; i++) {
            GameObject child = end.transform.GetChild(i).gameObject;
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null) {
                if (randomValue < 0.5) {
                    renderer.material = lightMaterial;
                    child.layer = 13;
                    lightGrounds.Add(child);
                } else {
                    renderer.material = darkMaterial;
                    child.layer = 14;
                    darkGrounds.Add(child);
                }
            }
        }

        Vector3 attachPoint = end.transform.Find("EffectAttachPoint").position;
        Instantiate(nextLevelEffect, attachPoint, nextLevelEffect.transform.rotation);
    }
}
