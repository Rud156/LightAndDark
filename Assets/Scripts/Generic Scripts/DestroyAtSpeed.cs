using UnityEngine;

public class DestroyAtSpeed : MonoBehaviour
{
    public float minYSpeed = 2;
    public float destoryAfterTime = 2f;

    private Rigidbody target;
    private bool notDestroyed;

    // Use this for initialization
    private void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        notDestroyed = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target.velocity.y < Mathf.Abs(minYSpeed) && notDestroyed)
        {
            notDestroyed = false;
            Destroy(gameObject, destoryAfterTime);
        }
    }
}