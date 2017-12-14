using UnityEngine;

public class ObjectColorFlicker : MonoBehaviour {
    public float duration = 3f;

    private Renderer materialRenderer;
    private Color startColor;
    private Color endColor;

    // Use this for initialization
    private void Start() {
        materialRenderer = gameObject.GetComponent<Renderer>();
    }

    public void SetColors(Color startColor, Color endColor) {
        this.startColor = startColor;
        this.endColor = endColor;
    }

    // Update is called once per frame
    private void Update() {
        materialRenderer.material.color = Color.Lerp(startColor, endColor,
            Mathf.PingPong(Time.time / duration, 1));
    }

    public void SetMaterial(Material material) {
        materialRenderer.material = material;
    }
}