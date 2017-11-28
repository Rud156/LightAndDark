using UnityEngine;

public class Store : MonoBehaviour
{
	public static Vector3 checkPoint;

	public static void setCheckPoint (Vector3 newCheckPoint)
	{
		checkPoint = newCheckPoint;
	}
}