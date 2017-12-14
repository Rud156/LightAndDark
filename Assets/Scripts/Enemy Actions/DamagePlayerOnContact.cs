using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnContact : MonoBehaviour {

    public float damageRate = 3;

    private bool damageStarted = false;
    private Store store;

    // Use this for initialization
    void Start() {
		
    }
	
    // Update is called once per frame
    void Update() {
        if (damageStarted) {
            store.DecreasePlayerHealth(damageRate * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player"))
            return;
		
        if (gameObject.CompareTag("LightGround") && other.gameObject.layer == 13)
            return;
        if (gameObject.CompareTag("DarkGround") && other.gameObject.layer == 14)
            return;

        store = other.GetComponent <Store>();
        damageStarted = true;
    }

    void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Player"))
            return;
		
        damageStarted = false;
    }
}
