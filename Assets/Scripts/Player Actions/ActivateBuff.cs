using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBuff : MonoBehaviour {

    public GameObject shieldEffect;
    public GameObject powerUpEffect;

    private Store store;

    void Start() {
        store = gameObject.GetComponent<Store>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            if (store.GetChargeAmount() >= 100) {
                GameObject powerUp = Instantiate(powerUpEffect, gameObject.transform.position, gameObject.transform.rotation)
                    as GameObject;
                powerUp.transform.parent = gameObject.transform;

                powerUp.GetComponent<StoreSetPowerDown>().SetPlayerStore(store);
                powerUp.GetComponent<StoreSetPowerDown>().SetType(2);
                store.SetPowerUpType(2);
                store.DecrementChargeAmount(100);

            } else if (store.GetChargeAmount() >= 50) {
                GameObject shield = Instantiate(shieldEffect, gameObject.transform.position, shieldEffect.transform.rotation)
                    as GameObject;
                shield.transform.parent = gameObject.transform;

                shield.GetComponent<StoreSetPowerDown>().SetPlayerStore(store);
                shield.GetComponent<StoreSetPowerDown>().SetType(1);
                store.SetPowerUpType(1);
                store.DecrementChargeAmount(50);
            }
        }
    }
}
