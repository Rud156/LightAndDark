using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
	public GameObject target;
	public float followXDistance = -1.75f;
	public float followZDistance = 0.5f;
	public float followHeight = 1;

	[Range (0, 1)]
	public float lerpSpeed = 0.9f;

	private void FixedUpdate ()
	{
		var targetYPosition = target.transform.position.y + followHeight;
		var currentYPosition = gameObject.transform.position.y;
		var lerpedYPosition = Mathf.Lerp (currentYPosition, targetYPosition, 0.9f * Time.deltaTime);

		gameObject.transform.position = new Vector3 (
			target.transform.position.x + followXDistance,
			lerpedYPosition,
			target.transform.position.z + followZDistance - 1
		);
	}
}