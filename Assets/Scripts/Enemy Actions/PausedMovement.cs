using System.Collections;
using UnityEngine;

public class PausedMovement : MonoBehaviour
{
    public enum Direction
    {
        yAxis,
        zAxis
    };

    public Direction direction;
    public float movementSpeed = 100;
    public float maxDirection = 5;
    public float pauseTime = 3;
    public bool playOnPositive = true;

    public ParticleSystem particles;

    private Rigidbody rigidBody;
    private Vector3 centerPosition;
    private Transform objectPosition;

    private bool velocitySet = false;
    private bool startForward = false;
    private bool enumatorRun = false;

    private void Start()
    {
        objectPosition = gameObject.transform;
        centerPosition = gameObject.transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (direction == Direction.yAxis)
        {
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

            if (objectPosition.position.y >= centerPosition.y + maxDirection)
                SetDirectionPositive();
            else if (objectPosition.position.y <= centerPosition.y - maxDirection)
                SetDirectionNegative();
        }
        else
        {
            if (!velocitySet)
            {
                var xVelocity = rigidBody.velocity.x;
                var yVelocity = rigidBody.velocity.y;

                if (startForward)
                    rigidBody.velocity = new Vector3(xVelocity, yVelocity, 1) * movementSpeed * Time.deltaTime;
                else
                    rigidBody.velocity = new Vector3(xVelocity, yVelocity, -1) * movementSpeed * Time.deltaTime;

                velocitySet = true;
            }

            if (objectPosition.position.z >= centerPosition.z + maxDirection)
                SetDirectionPositive();
            else if (objectPosition.position.z <= centerPosition.z - maxDirection)
                SetDirectionNegative();
        }
    }

    private void SetDirectionPositive()
    {
        startForward = false;
        if (playOnPositive && !enumatorRun)
            StartCoroutine(PlayParticleSystem());
        else
        {
            velocitySet = false;
            enumatorRun = false;
        }
    }

    private void SetDirectionNegative()
    {
        startForward = true;
        if (!playOnPositive && !enumatorRun)
            StartCoroutine(PlayParticleSystem());
        else
        {
            velocitySet = false;
            enumatorRun = false;
        }
    }

    private IEnumerator PlayParticleSystem()
    {
        rigidBody.velocity = Vector3.zero;

        if (!particles.isPlaying)
            particles.Play();
        yield return new WaitForSeconds(pauseTime);
        if (particles.isPlaying)
            particles.Stop();

        velocitySet = false;
        enumatorRun = true;
    }
}