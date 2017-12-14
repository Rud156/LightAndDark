using UnityEngine;

public class Jump : MonoBehaviour {
    public float jumpVelocity = 10;

    [Range(0, 1)]
    public float hitDistance = 0.7f;

    private Rigidbody target;

    // Use this for initialization
    private void Start() {
        target = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() {
        RaycastHit hit;
        Ray downRay = new Ray(gameObject.transform.position, -Vector3.up);
        if (Physics.Raycast(downRay, out hit)) {
            if (hit.distance <= hitDistance && Input.GetKeyDown(KeyCode.UpArrow)) {
                var zVelocity = target.velocity.z;
                target.velocity = new Vector3(0, jumpVelocity, zVelocity);
            }
        }
    }
}