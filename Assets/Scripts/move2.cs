using UnityEngine;
using System.Collections;

public class move2 : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10,10);
	private Vector3 movement;

	private Rigidbody rigid;

	// pour faux AddForce
	public float fakeForce = 0;
	public float timeForce = 0.2f;
	public float puissanceForce = 5;

	//pour feedback quandTouché
	public Animator feedbackTouche;

	//pour combat avec l'araignee
	public bool Regarde;

	//pour anim
	public Animator animPerso;
	private Transform Perso;

	private float rot;
	
	
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		Perso = animPerso.gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		movement = new Vector3(inputX * speed.x,rigid.velocity.y,speed.y * inputY - fakeForce);
	
		//pour recul fluide
		if (fakeForce != 0) {
			fakeForce = Mathf.Lerp(fakeForce,0,timeForce);
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			Regarde = true;
		}

		// pour changement d'anim
		if (rigid.velocity == Vector3.zero) {
			animPerso.Play("Idle");
		}
		if (rigid.velocity != Vector3.zero) {
			animPerso.Play("Walk");
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ) {
			rot = Quaternion.FromToRotation (new Vector3 (0, 0, 1), new Vector3 (rigid.velocity.x, 1, rigid.velocity.z)).eulerAngles.y;
			Perso.rotation = Quaternion.Euler (0, rot, 0);
			Debug.Log (rot);
		}
	}
	
	void FixedUpdate(){
		rigid.velocity = movement;	
	}
	
	
	//pour feedback quandTouché
	void OnCollisionEnter (Collision coll){
	if (coll.gameObject.tag == "Ombre") {
			feedbackTouche.SetBool("play",true);
			fakeForce = puissanceForce;
			Regarde = false;
			StartCoroutine(desactiveAnimLater());
		}
	}

	void OnTriggerEnter (Collider coll){
		if (coll.gameObject.tag == "Ombre") {
			feedbackTouche.SetBool("play",true);
			fakeForce = puissanceForce;
			Regarde = false;
			StartCoroutine(desactiveAnimLater());
		}
	}

	IEnumerator desactiveAnimLater(){
		yield return new WaitForSeconds(0.1f);
		feedbackTouche.SetBool ("play", false);
	}


	
}
