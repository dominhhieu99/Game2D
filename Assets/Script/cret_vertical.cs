using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cret_vertical : MonoBehaviour
{

	private Rigidbody2D rig;
	private bool checkBottom;
	public float moveForceY;

	// Use this for initialization
	void Start ()
	{
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveForceY = 0;
		if (checkBottom) {
			moveForceY = -4f;
		} else {
			moveForceY = 4f;
		}
		rig.velocity = new Vector2 (0, transform.localScale.y) * moveForceY;
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Botton") {
			checkBottom = true;
		}
		if (coll.gameObject.tag == "Stone") {
			checkBottom = false ;
		}
		if (coll.gameObject.tag == "Stone2") {
			checkBottom = false ;
		}
	}
}
