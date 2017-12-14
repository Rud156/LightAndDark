using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreator : MonoBehaviour {
    public GameObject health;
    public float generateAbove = 1;
    [Range(0, 1)]
    public float breathingSpace = 0.3f;

    public int minGenerationAmount = 10;
    public int maxGenerationAmount = 30;

    public Material lightMaterial;
    public Material darkMaterial;


    private bool willGenerate;
    private int generationHealthAmount;
    private GameObject parentObject;
    private ObjectColorFlicker flickr;

    private Store store;

    void Start() {
        willGenerate = Random.value < 0.2;
        if (willGenerate)
            generationHealthAmount = Random.Range(minGenerationAmount, maxGenerationAmount);

        parentObject = gameObject.transform.parent.gameObject;
        flickr = parentObject.GetComponent<ObjectColorFlicker>();

        if (willGenerate) {
            flickr.enabled = true;

            Color startColor = lightMaterial.color;
            Color endColor = darkMaterial.color;

            flickr.SetColors(startColor, endColor);
        } else {
            flickr.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (!willGenerate)
            return;

        Rigidbody target = other.GetComponent <Rigidbody>();
        if (!target || !other.CompareTag("Player")) {
            return;
        }
		
        GameObject healthHeart = Instantiate(health, 
                                     gameObject.transform.position + Vector3.up * (generateAbove + breathingSpace), 
                                     health.transform.rotation) as GameObject;
        healthHeart.GetComponent<CollectHealth>().setHealthAmount(generationHealthAmount);

        flickr.enabled = false;
        if (parentObject.layer == 13)
            flickr.SetMaterial(lightMaterial);
        else
            flickr.SetMaterial(darkMaterial);

        gameObject.SetActive(false);
    }
}
