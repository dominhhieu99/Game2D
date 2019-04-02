using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cret : MonoBehaviour
{
	private Rigidbody2D rig;
	private bool checkStone;
	public float moveForceX;

	// Use this for initialization
	void Start ()
	{
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveForceX = 0;
		if (checkStone) {
			moveForceX = -4f;
		} else {
			moveForceX = 4f;
		}

		rig.velocity = new Vector2 (transform.localScale.x, 0) * moveForceX;
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Stone") {
			checkStone = true;
		}
		if (coll.gameObject.tag == "Stone2") {
			checkStone = false;
		}
	}
}
