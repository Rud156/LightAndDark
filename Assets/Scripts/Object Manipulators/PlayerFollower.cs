using UnityEngine;

public class PlayerFollower : MonoBehaviour {
    public GameObject target;
    public float followXDistance = -1.75f;
    public float followZDistance = 0.5f;
    public float followHeight = 1;

    [Range(0, 1)]
    public float lerpSpeed = 0.9f;

    private void LateUpdate() {
        var targetYPosition = target.transform.position.y + followHeight;
        var currentYPosition = gameObject.transform.position.y;
        var lerpedYPosition = Mathf.Lerp(currentYPosition, targetYPosition, lerpSpeed * Time.deltaTime);

        var targetZPosition = target.transform.position.z + followZDistance - 1;
        var currentZPosition = gameObject.transform.position.z;
        var lerpedZPosition = Mathf.Lerp(currentZPosition, targetZPosition, lerpSpeed * Time.deltaTime);

        gameObject.transform.position = new Vector3(
            target.transform.position.x + followXDistance,
            lerpedYPosition,
            lerpedZPosition
        );
    }
}