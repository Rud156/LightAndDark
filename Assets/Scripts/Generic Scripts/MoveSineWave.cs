using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSineWave : MonoBehaviour {

    public float moveSpeed = 0.7f;
    public float amplitude = 1.5f;

    private float angle;

    // Use this for initialization
    void Start() {
        angle = 0;
    }
	
    // Update is called once per frame
    void Update() {
        angle += moveSpeed;
        gameObject.transform.Translate(Vector3.up * amplitude * Mathf.Sin(angle) * Time.deltaTime);
    }
}
