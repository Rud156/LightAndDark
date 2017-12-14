using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {

    public float pulseTime = 1f;

    private Light flickerLight;

    // Use this for initialization
    void Start() {
        flickerLight = gameObject.GetComponent<Light>();
        flickerLight.enabled = false;
        StartCoroutine(Go());
    }

    IEnumerator Go() {
        while (true) {
            flickerLight.enabled = true;
            yield return new WaitForSeconds(pulseTime);

            flickerLight.enabled = false;
            yield return new WaitForSeconds(pulseTime);
        }
    }
}
