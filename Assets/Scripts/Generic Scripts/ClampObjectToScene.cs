using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampObjectToScene : MonoBehaviour {

    public float padding = 10;

    void Start() {
		
    }
	
    // Update is called once per frame
    void Update() {
        Vector3 pos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp01(pos.y);
        gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
