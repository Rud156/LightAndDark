using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashText : MonoBehaviour {

    public float flickrRate = 0.7f;

    private TextMeshProUGUI textMPro;

    // Use this for initialization
    void Start() {
        textMPro = gameObject.GetComponent<TextMeshProUGUI>();
    }
	
    // Update is called once per frame
    void Update() {
        textMPro.color = new Color(textMPro.color.r, textMPro.color.g, textMPro.color.b, Mathf.PingPong(Time.time / flickrRate, 1));
    }
}
