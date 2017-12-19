using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSetPowerDown : MonoBehaviour {

    public float destroyTime = 10;

    private ParticleSystem particles;
    private Store store;
    private int powerUpType;

    void Start() {
        particles = gameObject.GetComponent<ParticleSystem>();
        if (!particles)
            StartCoroutine(DestroyEffectAfter());
    }

    public void SetPlayerStore(Store store) {
        this.store = store;
    }

    public void SetType(int type) {
        powerUpType = type;
    }
	
    // Update is called once per frame
    void Update() {
        if (!particles)
            return;

        if (!particles.isPlaying) {
            store.UnsetPowerUpType(powerUpType);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyEffectAfter() {
        yield return new WaitForSeconds(destroyTime);
        store.UnsetPowerUpType(powerUpType);
        Destroy(gameObject);
    }
}
