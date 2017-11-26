using UnityEngine;

public class CoinJump : MonoBehaviour
{
    public float jumpVelocity = 10f;
    public string objectTag;

    private Rigidbody target;

    // Use this for initialization
    private void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        target.velocity = Vector3.up * jumpVelocity;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
            Destroy(gameObject);
    }
}