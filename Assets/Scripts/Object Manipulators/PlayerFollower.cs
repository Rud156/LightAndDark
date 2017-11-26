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
        var targetYPosition = target.transform.position.y;
        var currentYPosition = gameObject.transform.position.y;
        var lerpedYPosition = Mathf.Lerp(currentYPosition, targetYPosition, 0.2f * Time.deltaTime);

        gameObject.transform.position = new Vector3(
            target.transform.position.x,
            lerpedYPosition,
            target.transform.position.z - 10
            );
    }
}