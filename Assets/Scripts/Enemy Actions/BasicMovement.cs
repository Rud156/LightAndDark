using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public Vector3 centerPosition = Vector3.zero;
    public float maxDirection = 5;

    public enum Direction
    {
        yAxis,
        zAxis
    }

    public Direction directon;
    public bool startForward = false;

    private Transform objectPosition;

    // Use this for initialization
    private void Start()
    {
        startForward = false;
        objectPosition = gameObject.transform;
        objectPosition.position = centerPosition;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (directon == Direction.yAxis)
        {
            if (startForward)
                objectPosition.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            else
                objectPosition.Translate(Vector3.down * movementSpeed * Time.deltaTime);

            if (objectPosition.position.y > centerPosition.y + maxDirection ||
                objectPosition.position.y < centerPosition.y - maxDirection)
                startForward = !startForward;
        }
        else
        {
            if (startForward)
                objectPosition.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            else
                objectPosition.Translate(Vector3.back * movementSpeed * Time.deltaTime);

            if (objectPosition.position.z > centerPosition.z + maxDirection ||
                objectPosition.position.z < centerPosition.z - maxDirection)
                startForward = !startForward;
        }
    }
}