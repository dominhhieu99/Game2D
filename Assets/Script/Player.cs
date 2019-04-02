using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

	public float speed = 50f, maxspeed = 3, jumpPow = 320f;
	public bool grounded = true, faceright = true, doublejump = false, Hidecoin=false;
	private int score=0;
	public Text textscore;
	public Rigidbody2D r2;
	public Animator anim;
	public ParticleSystem effect;

	// Use this for initialization
	void Start () {
		r2 = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		textscore = GameObject.Find ("textscore").GetComponent<Text> ();

	}
	// Update is called once per frame
	void Update () {
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (grounded)
			{ 
				grounded = false;
				doublejump = true;
				r2.AddForce(Vector2.up*jumpPow);

			}
			else
			{
				if (doublejump)
				{
					doublejump = false;
					r2.velocity = new Vector2(r2.velocity.x, 0);
					r2.AddForce(Vector2.up * jumpPow * 0.7f);
				}
			}

		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{ 
				grounded = false;
				doublejump = true;
				r2.AddForce(Vector2.up*jumpPow);

			}
			else
			{
				if (doublejump)
				{
					doublejump = false;
					r2.velocity = new Vector2(r2.velocity.x, 0);
					r2.AddForce(Vector2.up * jumpPow * 0.7f);
				}
			}

		}


	}


	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		r2.AddForce((Vector2.right) * speed * h);

		if (r2.velocity.x > maxspeed)
			r2.velocity = new Vector2(maxspeed, r2.velocity.y);
		if (r2.velocity.x < -maxspeed)
			r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

		if (h>0 && !faceright)
		{
			Flip();
		}

		if (h < 0 && faceright)
		{
			Flip();
		}
	}

	public void Flip()
	{
		faceright = !faceright;
		Vector3 Scale;
		Scale = transform.localScale;
		Scale.x *= -1;
		transform.localScale = Scale;
	}
	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Cret") {
			SceneManager.LoadScene ("GameOver");
		}
		if (target.gameObject.tag == "Home") {
			SceneManager.LoadScene ("Lever2");
		}
		if (target.gameObject.tag == "Home1") {
			SceneManager.LoadScene ("Lever2");
		}
		if (target.gameObject.tag == "nuoc") {
			SceneManager.LoadScene ("GameOver");
		}
		if(target.gameObject.tag ==("Tien"))
		{
			anim.SetBool ("Hidecoin", true);
			score = score + 1;
			textscore.text = "Score : " + score.ToString ();
			Destroy (target.gameObject, 1);
			Instantiate (effect, transform.position, transform.rotation);
		}
	}

	public void BackCT ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (r2.velocity.x);
		// nhan hanh dong tu ban phim


		// kiem tra gia toc
		if (velo < 4f) {
			forceX = -155f;
		}
		//anim.SetBool ("walked", true);
		// hanh dong xaoy mat
		Vector2 scale = transform.localScale;
		scale.x = -1.5f;
		transform.localScale = scale;

		//if (checkdie) {
		//	anim.SetBool ("playdie", true);
		//}
		// cap nhat thong tin vi tri
		r2.AddForce (new Vector2 (forceX, forceY));
	}

	public void GoCT ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (r2.velocity.x);
		// nhan hanh dong tu ban phim
		//float key = Input.GetAxisRaw("Horizontal");
		// xet cac truong hop

		// kiem tra gia toc
		if (velo < 4f) {
			forceX = 155f;
		}
		// hanh dong di chuyen
		//anim.SetBool ("walked", true);
		// hanh dong xaoy mat
		Vector2 scale = transform.localScale;
		scale.x = 1.5f;
		transform.localScale = scale;


		//if (checkdie) {
		//	anim.SetBool ("playdie", true);
		//}
		// cap nhat thong tin vi tri
		r2.AddForce (new Vector2 (forceX, forceY));
	}

	public void JumpCT ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (r2.velocity.x);
		// nhan hanh dong tu ban phim
		float key = Input.GetAxisRaw ("Horizontal");
		// xet cac truong hop
		if (key > 0) { // khi nhan D
			// kiem tra gia toc
			if (velo < 4f) {
				forceX = 15f;
			}
			// hanh dong di chuyen
			//anim.SetBool("walked", true);
			//anim.SetBool ("walked", true);
			// hanh dong xaoy mat
			Vector2 scale = transform.localScale;
			scale.x = 1.5f;
			transform.localScale = scale;
		} else if (key < 0) {
			// kiem tra gia toc
			if (velo < 4f) {
				forceX = -15f;
			}
			//anim.SetBool ("walked", true);
			// hanh dong xaoy mat
			Vector2 scale = transform.localScale;
			scale.x = -1.5f;
			transform.localScale = scale;
		} else {
			//anim.SetBool ("walked", false);
		}

		if (grounded) {// chi nhay khi no dung tren dat
			forceY = 300f;
			grounded = false;
			//anim.SetBool ("jump", true);
		} else {
			//anim.SetBool ("jump", false);

		}

		//if (checkdie) {
		//	anim.SetBool ("playdie", true);
		//}
		// cap nhat thong tin vi tri
		r2.AddForce (new Vector2 (forceX, forceY));
	}
}