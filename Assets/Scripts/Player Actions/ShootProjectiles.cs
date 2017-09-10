using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject projectile;
    public float projectileVelocity = 7f;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var projObject = Instantiate(projectile, gameObject.transform.position, Quaternion.identity)
                as GameObject;
            projObject.GetComponent<Rigidbody>().velocity = Vector3.forward * projectileVelocity;
        }
    }
}