using UnityEngine;

public class CoinJump : MonoBehaviour {
    public float jumpVelocity = 10f;

    private Rigidbody target;

    // Use this for initialization
    private void Start() {
        target = gameObject.GetComponent<Rigidbody>();
        target.velocity = Vector3.up * jumpVelocity;
    }
}