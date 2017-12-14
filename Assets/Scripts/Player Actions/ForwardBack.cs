using UnityEngine;

public class ForwardBack : MonoBehaviour {
    public float playerMoveSpeed = 50;

    private Rigidbody target;

    // Use this for initialization
    private void Start() {
        target = gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        var moveZ = -Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
        var xVelocity = target.velocity.x;
        var yVelocity = target.velocity.y;

        target.velocity = new Vector3(xVelocity, yVelocity, moveZ);
    }
}