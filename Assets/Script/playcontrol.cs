using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playcontrol : MonoBehaviour
{
	// khai bao 2 thuoc tinh Rigi thong so nhan vat - và animator thuoc tinh trang thai nhan vat
	private Rigidbody2D mybody;
	private Animator anim;
	public Text textscore;
	private int score;
	// tao dieu kien nhay
	public bool grounded;
	public bool checkdie;
	public bool checklevel;
	public ParticleSystem effect;

	////////////////////////////////// khai bao admob	/// //////////////////////////////////
	//int i = 1;
	//admobdemo adm;
	void Start ()
	{
		//adm = new admobdemo ();
		//adm.initAdmob();
		checkdie = false;
	}
	// // ///// //////////////////////////////// end khai bao //////////////////////////////// /////////////////////////////

	// dinh nghia

	void Awake ()
	{
		mybody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	public void BackCT ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (mybody.velocity.x);
		// nhan hanh dong tu ban phim


		// kiem tra gia toc
		if (velo < 4f) {
			forceX = -155f;
		}
		anim.SetBool ("walked", true);
		// hanh dong xaoy mat
		Vector2 scale = transform.localScale;
		scale.x = -1.5f;
		transform.localScale = scale;

		if (checkdie) {
			anim.SetBool ("playdie", true);
		}
		// cap nhat thong tin vi tri
		mybody.AddForce (new Vector2 (forceX, forceY));
	}

	public void GoCT ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (mybody.velocity.x);
		// nhan hanh dong tu ban phim
		//float key = Input.GetAxisRaw("Horizontal");
		// xet cac truong hop
        
		// kiem tra gia toc
		if (velo < 4f) {
			forceX = 155f;
		}
		// hanh dong di chuyen
		anim.SetBool ("walked", true);
		// hanh dong xaoy mat
		Vector2 scale = transform.localScale;
		scale.x = 1.5f;
		transform.localScale = scale;


		if (checkdie) {
			anim.SetBool ("playdie", true);
		}
		// cap nhat thong tin vi tri
		mybody.AddForce (new Vector2 (forceX, forceY));
	}

	public void JumpCT ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (mybody.velocity.x);
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
			anim.SetBool ("walked", true);
			// hanh dong xaoy mat
			Vector2 scale = transform.localScale;
			scale.x = 1.5f;
			transform.localScale = scale;
		} else if (key < 0) {
			// kiem tra gia toc
			if (velo < 4f) {
				forceX = -15f;
			}
			anim.SetBool ("walked", true);
			// hanh dong xaoy mat
			Vector2 scale = transform.localScale;
			scale.x = -1.5f;
			transform.localScale = scale;
		} else {
			anim.SetBool ("walked", false);
		}

		if (grounded) {// chi nhay khi no dung tren dat
			forceY = 300f;
			grounded = false;
			anim.SetBool ("jump", true);
		} else {
			anim.SetBool ("jump", false);

		}

		if (checkdie) {
			anim.SetBool ("playdie", true);
		}
		// cap nhat thong tin vi tri
		mybody.AddForce (new Vector2 (forceX, forceY));
	}

	// Update is called once per frame
	void Update ()
	{
		//////////////////////////////////////////////////////////////////// start interstitial
		/// 
//		if((i>=2) && (checkdie==true))
//		{
//
//			adm.interstitialHung();
//
//
//		}
//		i++;
		////////////////////////////////////////////////////////////end interstitial
		/// 
		
		Control ();
		//JumpCT ();
	}
	// phuong thuc dieu khien
	public void Control ()
	{
		// khia bao 2 gia tri
		float forceX = 0f;
		float forceY = 0f;
		// nhan gia toc hien tai cua nhan vat
		float velo = Mathf.Abs (mybody.velocity.x);
		// nhan hanh dong tu ban phim
		float key = Input.GetAxisRaw ("Horizontal");
		// xet cac truong hop
		if (key > 0) { // khi nhan D
			// kiem tra gia toc
			if (velo < 4f) {
				forceX = 15f;
			}
			// hanh dong di chuyen
			anim.SetBool ("walked", true);
			// hanh dong xaoy mat
			Vector2 scale = transform.localScale;
			scale.x = 1.5f;
			transform.localScale = scale;
		} else if (key < 0) {
			// kiem tra gia toc
			if (velo < 4f) {
				forceX = -15f;
			}
			anim.SetBool ("walked", true);
			// hanh dong xaoy mat
			Vector2 scale = transform.localScale;
			scale.x = -1.5f;
			transform.localScale = scale;
		} else {
			anim.SetBool ("walked", false);
		}
		// xe truong hop nhay
		if (Input.GetKey (KeyCode.Space)) {		//if(Input.GetMouseButtonDown(0))//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//if (GUI.Button(new Rect(Screen.width*0.01f,Screen.height*0.01f,Screen.width*0.1f,Screen.height*0.01f),"Jump"))//if (GUI.Button(new Rect(120, 0, 100, 60), "showInterstitial"))
			if (grounded) {// chi nhay khi no dung tren dat
				forceY = 300f;
				grounded = false;
				anim.SetBool ("jump", true);
			} else {
				anim.SetBool ("jump", false);

			}
		}
		if (checkdie) {
			anim.SetBool ("playdie", true);
		}
		// cap nhat thong tin vi tri
		mybody.AddForce (new Vector2 (forceX, forceY));
	}
	// kiem tra va cham cua 2 target
	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Botton") {
			grounded = true;
		}
		if (target.gameObject.tag == "Cret") {
			checkdie = true;
			SceneManager.LoadScene ("GameOver");
		}
		if (target.gameObject.tag == "Home") {
			SceneManager.LoadScene ("Level2");
		}
		if (target.gameObject.tag == "nuoc") {
			checkdie = true;
			SceneManager.LoadScene ("GameOver");
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Coin")) {
			Animator otheranim = other.gameObject.GetComponent<Animator> () as Animator;
			otheranim.SetBool ("Eat", true);
			score = score + 1;
			textscore.text = "Score : " + score.ToString ();
			Destroy (other.gameObject, 1);
			Instantiate (effect, transform.position, transform.rotation);
			Destroy (other);
		}
		if (other.gameObject.CompareTag ("Box")) {
			Animator otheranim = other.gameObject.GetComponent<Animator> () as Animator;
			otheranim.SetBool ("Eat", true);
			Destroy (other.gameObject, 1);
			Destroy (other);
		}
       
	}
}
