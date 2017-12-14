using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
	public Material lightMaterial;
	public Material darkMaterial;

	public GameObject mainCamera;
	public GameObject directionalLight;

	private Color lightColor;
	private Color darkColor;

	private Renderer gameobjectRenderer;
	private int playerColor;

	// Use this for initialization
	void Start ()
	{
		gameobjectRenderer = gameObject.GetComponent <Renderer> ();
		lightColor = lightMaterial.color;
		darkColor = darkMaterial.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Camera cameraComponent = mainCamera.GetComponent <Camera> ();
			Light lightComponent = directionalLight.GetComponent <Light> ();

			if (playerColor == 13) {
				playerColor = 14;
				gameobjectRenderer.material = darkMaterial;
				gameObject.layer = 14;

				cameraComponent.backgroundColor = darkColor;
				lightComponent.color = darkColor;
			} else {
				playerColor = 13;
				gameobjectRenderer.material = lightMaterial;
				gameObject.layer = 13;

				cameraComponent.backgroundColor = lightColor;
				lightComponent.color = lightColor;
			}

			gameObject.GetComponent <Store> ().SetPlayerColor (playerColor);
		}
	}
}
