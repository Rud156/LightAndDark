using UnityEngine;

public class SingleDirection : MonoBehaviour
{
    public enum Direction
    {
        yAxis,
        zAxis
    }

    public Direction direction = Direction.yAxis;
    public bool startForward = true;
    public float movementSpeed = 5;
    public Vector3 startPosition = Vector3.zero;

    private Transform objectPosition;

    // Use this for initialization
    private void Start()
    {
        gameObject.transform.position = startPosition;
        objectPosition = gameObject.transform;
    }

    public void SetForwardDirection(bool value)
    {
        startForward = value;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        switch (direction)
        {
            case Direction.yAxis:
                if (startForward)
                    objectPosition.Translate(Vector3.up * movementSpeed * Time.deltaTime);
                else
                    objectPosition.Translate(Vector3.down * movementSpeed * Time.deltaTime);
                break;

            case Direction.zAxis:
                if (startForward)
                    objectPosition.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                else
                    objectPosition.Translate(Vector3.back * movementSpeed * Time.deltaTime);
                break;

            default:
                break;
        }
    }
}