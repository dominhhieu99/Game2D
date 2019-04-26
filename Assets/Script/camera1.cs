using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera1 : MonoBehaviour {
	public float ScrollSpeed = 0.1f;


	float Offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Offset += Time.deltaTime * ScrollSpeed;

		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (Offset, 0.01f);
	}
}
