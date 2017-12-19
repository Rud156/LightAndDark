using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyShield : MonoBehaviour {

    public GameObject explosion;
    public string enemyTagName = "Enemies";

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(enemyTagName) && other.gameObject.layer != 12)
            return;

        Instantiate(explosion, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
}
