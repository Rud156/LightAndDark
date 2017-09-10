using UnityEngine;

public class ObjectColorFlicker : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float duration = 3f;

    private Renderer materialRenderer;

    // Use this for initialization
    private void Start()
    {
        materialRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        materialRenderer.material.color = Color.Lerp(startColor, endColor,
            Mathf.PingPong(Time.time / duration, 1));
    }
}