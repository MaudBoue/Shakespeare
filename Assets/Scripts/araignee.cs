using UnityEngine;
using System.Collections;

public class araignee : MonoBehaviour {

	private Animator anim;

	// pour passage de forme floue à araignee
	public bool joueurEstDansZone;
	private float jauge;
	private float tempsAppear = 100;
	private float coefMonteJauge = 0.8f;
	private Transform jaugeSprite;

	// pour confrontation
	private bool estApparu = false;
	private bool regarde;
	private move2 perso;
	private float coefMonteJauge2 = 0.5f;
	public patternOmbres patternO;
	private SpriteRenderer brilleRend;

    // lettres qui apparaissent
    public GameObject lettres;

	//pour lock
	public GameObject Lock;

	// toiles qui disparaissent quand tuée
	public GameObject[] toilesQuiBloquent;

	//pour sons
	public bool fintransfoOk = false;
	private soundManager soundManagerGO;
	public AudioClip transfoAraignee;
	public AudioClip finTransfo; 
	public AudioClip off;
	public AudioClip finAraignee;
	private bool joueSon;

	// pour pause
	private gameManagerNew gameManagerGO;

	// pour anim de fin
	public bool animFinFinie;

	// Use this for initialization
	void Start () {
		gameManagerGO = FindObjectOfType<gameManagerNew>();
		perso = FindObjectOfType<move2> ();
		anim = GetComponent<Animator> ();
		jaugeSprite = transform.FindChild ("Jauge");
		jaugeSprite.localScale = new Vector3 (0,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
		brilleRend = jaugeSprite.FindChild ("brille").GetComponent<SpriteRenderer>();
		brilleRend.enabled = false;
		soundManagerGO = FindObjectOfType<soundManager> ();
		
		patternO = GetComponent<patternOmbres> ();
        //patternO.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
	
		// Quand forme floue
		if (!estApparu && !gameManagerGO.isPause) {

			if (joueSon && jauge <= 0){
				joueSon=false;
				soundManagerGO.PlaySingleSound(off,true,1);
			}

			if (joueurEstDansZone) {
				jauge += coefMonteJauge*1.5f;
				anim.SetFloat("evolution",jauge);
				//son
				if (!joueSon){
					joueSon=true;
					soundManagerGO.PlaySingleSound(transfoAraignee,false,1);
				}
				if (jauge >= tempsAppear) transformationEnAraignee();
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}

			if (!joueurEstDansZone && jauge > 0) {
				jauge -= coefMonteJauge / 2;
				anim.SetFloat("evolution",jauge);
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
				if (joueSon){
					joueSon=false;
					soundManagerGO.PlaySingleSound(off,true,1);
				}
			}


		}

		//Quand Araignée
		if (estApparu && !gameManagerGO.isPause) {
			regarde = perso.Regarde;
			if (regarde && joueurEstDansZone ) {
				jauge += coefMonteJauge2;
				if (jauge >= tempsAppear) aEuAraigne();
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
				if (brilleRend.enabled == false) brilleRend.enabled=true;
			}
			else {
				if (brilleRend.enabled == true) brilleRend.enabled=false;
			}
			if (jauge > 0 && (!regarde || !joueurEstDansZone)) {
			jauge -= coefMonteJauge2 / 2;
			jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}

			// pour apparition / disparition ombres
			/*if ( patternO.enable == true && !regarde && !joueurEstDansZone){
			
			}*/

			if (animFinFinie){
				destroyAraignee();
			}
		}

	}


	// victoire contre araigée si collision
	/*void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == ("Player") && estApparu) {
			aEuAraigne();
		}
	}*/


	private void transformationEnAraignee(){
		Debug.Log ("Apparu");
		estApparu = true;
		anim.SetBool ("apparu", true);
		jauge = 0;
		soundManagerGO.PlaySingleSound(finTransfo,false,1);
		ombresApparaissent ();
	}

	private void ombresApparaissent(){
		patternO.enabled = true;
		patternO.init ();
	}

	private void aEuAraigne(){
		Debug.Log ("araignee Eue");
		perso.desactiveLock ();
		soundManagerGO.stopSound (0);
		soundManagerGO.PlaySingleSound(finAraignee,false,1);
		anim.Play("araigneeVaincue");
	}
	

	private void destroyAraignee () {
		GetComponentInChildren<zoneAraigneeAppear> ().Camera01.enabled = false;
		GameObject.FindObjectOfType<Dezoom>().dezoomCamera();
		lettres.SetActive (true);
		perso.ExitZoneAraignee ();
		foreach (GameObject toile in toilesQuiBloquent){
			toile.SetActive(false);
			//GameObject.Destroy(toile);
		}
		GameObject.Destroy (this.gameObject);
	}
	
	
	// pour optimisation : apparition / disparition ombres
    public void checkOmbres() { }
		/*if (estApparu && patternO.enabled == false) {
			ombresApparaissent();
		}*/

    }
