using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpTextCreator : MonoBehaviour {

    public float letterPause = 0.2f;
    public TextMeshProUGUI textMesh;
    public AudioSource audioSource;

    private string[] textToDisplay =
        {
            "A Simple Survival Game. Reach As Far As You Can.",
            "Baisc Rules Are:",
            "1. <color=yellow>Yellow</color> Can Interact With <b>Black</b>.",
            "2. <b>Black</b> Can Interact With <color=yellow>Yellow</color>.",
            "3. Shield can be activated by pressing <b>ENTER</b> after reaching <b>50%</b> charge. Protects from bullets and enemies for <b>10s</b>.",
            "4. Power Shield can be activated by pressing <b>ENTER</b> after reaching <b>100%</b> charge. Protects from everything and destroys everything for <b>10s</b>.",
            "5. Collect <color=red>Hearts</color> from <color=yellow>Flashing Blocks</color> to regenarate health.",
            "<b>Movement Controls</b>:\n\n\n UP (Jump), LEFT (Forward), RIGHT (Backward), SPACE (Change Color), ENTER (Power Up)"
        };

    void OnEnable() {
        StartCoroutine(StartEnteringText());
    }

    void OnDisable() {
        StopCoroutine(StartEnteringText());
    }
	
    // Update is called once per frame
    void Update() {
		
    }

    IEnumerator StartEnteringText() {
        foreach (var item in textToDisplay) {
            textMesh.text = "";

            for (int i = 0; i < item.Length; i++) {
                if (item[i] == '<') {
                    int closeTagIndex = item.IndexOf('>', i);
                    string subString = item.Substring(i, closeTagIndex - i + 1);
                    print(subString);

                    i += (closeTagIndex - i + 1);
                    textMesh.text += subString;
                }
                textMesh.text += item[i];
                audioSource.Play();
                yield return new WaitForSeconds(letterPause);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
