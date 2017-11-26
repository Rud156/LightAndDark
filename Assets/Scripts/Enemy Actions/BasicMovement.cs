using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 100;
    public float maxDirection = 5;

    public enum Direction
    {
        yAxis,
        zAxis
    }

    public Direction directon;

    private Transform objectPosition;
    private Vector3 centerPosition;
    private Rigidbody rigidBody;

    private bool velocitySet = false;
    private bool startForward = false;

    // Use this for initialization
    private void Start()
    {
        objectPosition = gameObject.transform;
        centerPosition = objectPosition.position;
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (directon == Direction.yAxis) { 
            if (!velocitySet)
            {
                var xVelocity = rigidBody.velocity.x;
                var zVelocity = rigidBody.velocity.z;

                if (startForward)
                    rigidBody.velocity = new Vector3(xVelocity, 1, zVelocity) * movementSpeed * Time.deltaTime;
                else
                    rigidBody.velocity = new Vector3(xVelocity, -1, zVelocity) * movementSpeed * Time.deltaTime;

                velocitySet = true;
            }

            if (objectPosition.position.y > centerPosition.y + maxDirection)
            {
                startForward = false;
                velocitySet = false;
            }
            else if (objectPosition.position.y < centerPosition.y - maxDirection)
            {
                startForward = true;
                velocitySet = false;
            }
        }
        else
        {

            if(!velocitySet)
            {
                var xVelocity = rigidBody.velocity.x;
                var yVelocity = rigidBody.velocity.y;

                if (startForward)
                    rigidBody.velocity = new Vector3(xVelocity, yVelocity, 1) * movementSpeed * Time.deltaTime;
                else
                    rigidBody.velocity = new Vector3(xVelocity, yVelocity, -1) * movementSpeed * Time.deltaTime;

                velocitySet = true;
            }

            if (objectPosition.position.z > centerPosition.z + maxDirection)
            {
                startForward = false;
                velocitySet = false;
            }
            else if (objectPosition.position.z < centerPosition.z - maxDirection)
            {
                startForward = true;
                velocitySet = false;
            }
        }
    }
}