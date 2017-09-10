using UnityEngine;

public class ForwardBack : MonoBehaviour
{
    public float playerMoveSpeed = 50;

    private Rigidbody target;

    // Use this for initialization
    private void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var moveZ = Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime;
        target.velocity += new Vector3(0, 0, moveZ);
    }
}