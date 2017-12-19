using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour {

    public GameObject destroyEffect;
    public Material lightMaterial;
    public Material darkMaterial;

    public string projectileTagName = "EnemyBullets";


    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(projectileTagName))
            return;

        int layer = other.gameObject.layer;
        GameObject destroy = Instantiate(destroyEffect, other.transform.position, destroyEffect.transform.rotation)
            as GameObject;
        if (layer == 13) {
            destroy.GetComponent<Renderer>().material = lightMaterial;
        } else {
            destroy.GetComponent<Renderer>().material = darkMaterial;
        }
    }
}
