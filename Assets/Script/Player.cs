using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//hp
using UnityEngine.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed = 50f, maxspeed = 3, jumpPow = 320f;
	public bool grounded = true, faceright = true, doublejump = false, Hidecoin=false;
	private int score=0;
	public Text textscore;
	public Rigidbody2D r2;
	public Animator anim;
	public ParticleSystem effect;

	// cách 1
	private List<GameObject> listObjs;
	private GameObject[] arrayObjs;
	int i=0;

	// cách 2

	public int ourHealth;
	public int maxHealth = 5;



	// Use this for initialization
	void Start () {
		r2 = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		ourHealth = maxHealth;
		textscore = GameObject.Find ("textscore").GetComponent<Text> ();

		listObjs = new List<GameObject> ();
		arrayObjs = GameObject.FindGameObjectsWithTag ("blood");
		foreach (GameObject obj in arrayObjs) {
			listObjs.Add (obj);
		}




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
		if (ourHealth <= 0)
		{
			Death();
		}

	}
	public void Death()
	{
		SceneManager.LoadScene ("GameOver");
	}

	public void Damage(int damage)
	{
		ourHealth -= damage;
		gameObject.GetComponent<Animation>().Play("redflash");
	}

	public void Knockback (float Knockpow, Vector2 Knockdir)
	{
		r2.velocity = new Vector2(0, 0);
		r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
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
			score = score - 1;
			textscore.text = "Score : " + score.ToString ();
			if(score<0){
				SceneManager.LoadScene ("GameOver");
			}
			if (i <3) {
				Destroy (listObjs [i]);
				listObjs.RemoveAt (i);
				i++;
			}else{SceneManager.LoadScene ("GameOver");}
				


		}
		if (target.gameObject.tag == "x2") {
			score = score *2;
			textscore.text = "Score : " + score.ToString ();
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

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Tien")) {
			Animator otheranim = other.gameObject.GetComponent<Animator> () as Animator;
			otheranim.SetBool ("Eat", true);
			score = score + 1;
			textscore.text = "Score : " + score.ToString ();
			Destroy (other.gameObject, 1);
			Instantiate (effect, transform.position, transform.rotation);
			Destroy (other);
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