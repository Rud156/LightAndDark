using UnityEngine;

public class DestroyAtSpeed : MonoBehaviour
{
    public float minSpeed = 2;
    public float destoryAfterTime = 2f;

    private Rigidbody target;
    private bool destroyed;

    // Use this for initialization
    private void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        destroyed = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!destroyed)
        {
            var speed = Mathf.Sqrt(Mathf.Pow(target.velocity.x, 2) + Mathf.Pow(target.velocity.y, 2));
            if(speed <= minSpeed)
            {
                destroyed = true;
                Destroy(gameObject, destoryAfterTime);
            }
        }
    }
}