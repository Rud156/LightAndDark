using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerMeteor : MonoBehaviour {

    public GameObject destroyEffect;

    // Use this for initialization
    void Start() {
		
    }
	
    // Update is called once per frame
    void Update() {
        if (gameObject.transform.position.y < -20)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (target && other.CompareTag("Player"))
            other.GetComponent<Store>().DecreasePlayerHealth(gameObject.transform.localScale.x * 20);

        Instantiate(destroyEffect, gameObject.transform.position, destroyEffect.transform.rotation);
        Destroy(gameObject);
    }
}
