using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{

	private ParticleSystem particles;

	// Use this for initialization
	void Start ()
	{
		particles = gameObject.GetComponent <ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!particles.isPlaying)
			Destroy (gameObject);
	}
}
