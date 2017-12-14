using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour {
    
    private float healthAmount;

    public void setHealthAmount(float amount) {
        healthAmount = amount;
    }

    void OnTriggerEnter(Collider other) {
        print("Collided");
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        print("Collected Health");
        other.GetComponent<Store>().IncreasePlayerHealth(healthAmount);
        Destroy(gameObject);
    }
}
