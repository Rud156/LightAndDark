using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorJitter : MonoBehaviour {

    public float jitterRange = 1;

    // Update is called once per frame
    void Update() {
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z + Random.Range(-jitterRange, jitterRange)
        );
    }
}
