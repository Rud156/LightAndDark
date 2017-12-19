using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour {

    public Material lightMaterial;
    public Material darkMaterial;
    public GameObject meteor;

    public float destroyAfterTime = 10;

    private Store playerStore;
    private bool spawnMeteors;

    void Start() {
        spawnMeteors = true;

        StartCoroutine(DestroySelf());
    }

    public void SetPlayer(GameObject player) {
        Store playerStore = player.GetComponent<Store>();
        this.playerStore = playerStore;
    }

    void FixedUpdate() {
        if (!spawnMeteors)
            return;

        int randomIndex = Mathf.FloorToInt(Random.value * gameObject.transform.childCount);
        Vector3 position = gameObject.transform.GetChild(randomIndex).position;
        if (Random.value < 0.4) {
            GameObject meteorObject = Instantiate(meteor, position, meteor.transform.rotation)
                as GameObject;
            meteorObject.transform.localScale = Vector3.one * Random.Range(0.25f, 0.5f);

            if (playerStore.GetPlayerColor() == 13) {
                if (Random.value < 0.2) {
                    meteorObject.GetComponent<Renderer>().material = lightMaterial;
                    meteorObject.layer = 13;
                } else {
                    meteorObject.GetComponent<Renderer>().material = darkMaterial;
                    meteorObject.layer = 14;
                }
            } else {
                if (Random.value < 0.8) {
                    meteorObject.GetComponent<Renderer>().material = lightMaterial;
                    meteorObject.layer = 13;
                } else {
                    meteorObject.GetComponent<Renderer>().material = darkMaterial;
                    meteorObject.layer = 14;
                }
            }
        }
    }

    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(destroyAfterTime);
        spawnMeteors = false;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
