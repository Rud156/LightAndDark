using UnityEngine;

public class CoinJump : MonoBehaviour
{
    public float jumpVelocity = 10f;

    private Rigidbody target;
    private bool oneTouched;

    // Use this for initialization
    private void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        oneTouched = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Check the function after making a character
        // TODO: The Better Jump Function Created Is Also Required
        if (oneTouched)
            Destroy(gameObject);

        Rigidbody otherTarget = other.GetComponent<Rigidbody>();
        if (!otherTarget || !other.CompareTag("Player"))
            return;

        oneTouched = true;
        target.velocity = Vector3.up * jumpVelocity;
    }
}