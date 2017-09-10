using UnityEngine;

public class PausedMovement : MonoBehaviour
{
    public float movementSpeed;
    public float pauseTime;
    public ParticleSystem particles;
    public bool playParticlesAtEnd;
    public Vector3 startPoint;
    public Vector3 endPoint;

    public enum Direction
    {
        yAxis,
        zAxis
    }

    public Direction direction;

    private Transform objectPosition;
    private bool stopMoving;
    private bool functionInvoked;
    private bool moveForward;

    // Use this for initialization
    private void Start()
    {
        objectPosition = gameObject.transform;
        stopMoving = false;
        functionInvoked = false;
        objectPosition.position = startPoint;
        moveForward = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        switch (direction)
        {
            case Direction.yAxis:
                if (!stopMoving)
                {
                    if (moveForward)
                        objectPosition.Translate(Vector3.up * movementSpeed * Time.deltaTime);
                    else
                        objectPosition.Translate(Vector3.down * movementSpeed * Time.deltaTime);
                }

                if ((objectPosition.position.y > endPoint.y || objectPosition.position.y < startPoint.y) &&
                    !functionInvoked)
                {
                    stopMoving = true;
                    functionInvoked = true;
                    Invoke("ToggleMovement", pauseTime);

                    if (playParticlesAtEnd && objectPosition.position.y > endPoint.y)
                        particles.Play();
                    else if (!playParticlesAtEnd && objectPosition.position.y < startPoint.y)
                        particles.Play();
                }

                break;

            case Direction.zAxis:
                if (!stopMoving)
                {
                    if (moveForward)
                        objectPosition.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                    else
                        objectPosition.Translate(Vector3.back * movementSpeed * Time.deltaTime);
                }

                if ((objectPosition.position.z > endPoint.z || objectPosition.position.z < startPoint.z) &&
                    !functionInvoked)
                {
                    stopMoving = true;
                    functionInvoked = true;
                    Invoke("ToggleMovement", pauseTime);

                    if (playParticlesAtEnd && objectPosition.position.z > endPoint.z)
                        particles.Play();
                    else if (!playParticlesAtEnd && objectPosition.position.z < startPoint.z)
                        particles.Play();
                }
                break;

            default:
                break;
        }
    }

    private void ToggleMovement()
    {
        stopMoving = false;
        functionInvoked = false;
        moveForward = !moveForward;
        particles.Stop();
    }
}