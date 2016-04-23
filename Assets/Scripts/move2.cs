using UnityEngine;
using System.Collections;

public class move2 : MonoBehaviour {
	
	public Vector2 speedLaby ;
	public Vector2 speedFight ;
	private Vector2 speed;
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

	//pour feedback du lock
	public bool joueurPresDaraignee;
	public GameObject Lock; 
	public GameObject lockModele;

	//pour sons
	private soundManager soundManagerGO;
	public AudioClip lockOn;
	public AudioClip lockOff;
	public AudioClip lockDansVide;
	
	// Use this for initialization
	void Start () {
		speed = speedLaby;
		rigid = GetComponent<Rigidbody> ();
		Perso = animPerso.gameObject.GetComponent<Transform> ();
		soundManagerGO = FindObjectOfType<soundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		movement = new Vector3(inputX * speed.x,rigid.velocity.y,speed.y * inputY - fakeForce);
	

		// lock
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (joueurPresDaraignee) activeLock();
			else lockDansLeVide();
		}

		// pour changement d'anim
		if (rigid.velocity == Vector3.zero) {
			animPerso.Play("Idle");
		}
		if (rigid.velocity != Vector3.zero) {
			animPerso.Play("Walk");
		}

		//rotation
		if (!Regarde) {
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") >= 0.01f) {
				rot = Quaternion.FromToRotation (new Vector3 (0, 0, 1), new Vector3 (rigid.velocity.x, 1, rigid.velocity.z)).eulerAngles.y;
				Perso.rotation = Quaternion.Euler (0, rot, 0);
			}
		}
		if (Regarde) {
			rot = Quaternion.FromToRotation (new Vector3 (0, 0, 1), new Vector3 ( Lock.transform.position.x-transform.position.x,1,Lock.transform.position.z-transform.position.z/* distance lock */)).eulerAngles.y;
			Perso.rotation = Quaternion.Euler (0, rot, 0);
		}


	}
	
	void FixedUpdate(){
		//pour recul fluide
		if (fakeForce != 0) {
			fakeForce = Mathf.Lerp(fakeForce,0,timeForce);
		}
		rigid.velocity = movement;	
	}
	
	
	//pour feedback quandTouché
	void OnCollisionEnter (Collision coll){
	if (coll.gameObject.tag == "Ombre") {
			feedbackTouche.SetBool("play",true);
			fakeForce = puissanceForce;
			desactiveLock ();
			soundManagerGO.PlaySingleSound(lockOff);
			StartCoroutine(desactiveAnimLater());
		}
	}

	void OnTriggerEnter (Collider coll){
		if (coll.gameObject.tag == "Ombre") {
			feedbackTouche.SetBool("play",true);
			fakeForce = puissanceForce;
			desactiveLock();
			soundManagerGO.PlaySingleSound(lockOff);
			StartCoroutine(desactiveAnimLater());
		}
	}

	IEnumerator desactiveAnimLater(){
		yield return new WaitForSeconds(0.1f);
		feedbackTouche.SetBool ("play", false);
	}

	// pour Lock
	void activeLock () {
		soundManagerGO.PlaySingleSound (lockOn,false);
		Regarde = true;
		Lock.SetActive(true);
	}

	public void desactiveLock () {
		Regarde = false;
		Lock.SetActive(false);
	}

	void lockDansLeVide () {
		soundManagerGO.PlaySingleSound (lockDansVide,false);
		Lock = Instantiate (lockModele);
		Lock.transform.position = new Vector3 (transform.position.x,Lock.transform.position.y,transform.position.z+3);
	}

	// entre et sort de zone d'araignee 

	public void dansZoneAraignee ( GameObject lockCurrentAraignee){
		Lock = lockCurrentAraignee;
		joueurPresDaraignee = true;
		speed = speedFight;
	}
	
	public void ExitZoneAraignee () {
		joueurPresDaraignee = false;
		desactiveLock();
		speed = speedLaby;
		soundManagerGO.stopSound (0);
	}
	
}
