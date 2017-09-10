using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject target;
    public float followDistance = 10;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(0,
            target.transform.position.y,
            target.transform.position.z - followDistance);
    }
}