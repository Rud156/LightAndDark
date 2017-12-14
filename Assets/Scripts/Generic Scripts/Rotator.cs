using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public enum Direction {
        xAxis,
        yAxis,
        zAxis}
    ;

    public float rotationSpeed = 50f;
    public Direction direction;
	
    // Update is called once per frame
    void Update() {
        switch (direction) {
            case Direction.xAxis:
                gameObject.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);     
                break;
            case Direction.yAxis:
                gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);     
                break;
            case Direction.zAxis:
                gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);     
                break;
        }
        
    }
}
