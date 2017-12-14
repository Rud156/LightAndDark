using UnityEngine.SceneManagement;
using UnityEngine;

public class Fader : MonoBehaviour {
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.7f;

    private int drawDepth = -1000;
    private float alpha = 1;
    private int fadeDirection = -1;

    void OnEnable() {
        SceneManager.sceneLoaded += LevelLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= LevelLoaded;
    }

    void OnGUI() {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction) {
        fadeDirection = direction;
        return fadeSpeed;
    }

    void LevelLoaded(Scene scene, LoadSceneMode mode) {
        BeginFade(-1);
    }
}
