using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollider : MonoBehaviour {
    public GameObject explosion;
    public float explosionForce = 50;

    private AudioSource audioSource;
    private float objectScale;

    // Use this for initialization
    void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
        objectScale = gameObject.transform.localScale.x;
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player"))
            return;

        if (!LevelDataStore.playerBuffActive) {

            Store store = other.GetComponent <Store>();
            store.DecreasePlayerHealth(objectScale * store.decreaseMultiplier);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		
            Rigidbody target = other.GetComponent <Rigidbody>();
            float sign = -Mathf.Sign(gameObject.transform.position.z - other.transform.position.z);
            target.AddForce(Vector3.back * sign * explosionForce, ForceMode.VelocityChange);

            if (audioSource)
                audioSource.Play();
        }

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject, 1);
    }
}
