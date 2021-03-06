﻿using UnityEngine;
using System.Collections;

public class araignee : MonoBehaviour {

	private Animator anim;

	// pour passage de forme floue à araignee
	public bool joueurEstDansZone;
	private float jauge;
	private float tempsAppear = 100;
	private float coefMonteJauge = 0.6f;
	private Transform jaugeSprite;

	// pour confrontation
	public float lifeTime = 100;
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

	//pour Lettres
	public lettresAraigneesHaut lettresHaut;
	private float palier1;
	private float palier2;
	private int currentPhase;

	// Use this for initialization
	void Start () {
		gameManagerGO = FindObjectOfType<gameManagerNew>();
		perso = FindObjectOfType<move2> ();
		anim = GetComponent<Animator> ();
		jaugeSprite = transform.FindChild ("Jauge");
		jaugeSprite.localScale = new Vector3 (0,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
		brilleRend = jaugeSprite.FindChild ("brille").GetComponent<SpriteRenderer>();
		brilleRend.enabled = false;
		if (lettresHaut != null) {
			lettresHaut.gameObject.SetActive(false);
			lettresHaut.transform.parent=this.transform;
			lettresHaut.transform.localPosition = new Vector3 (0,0,-8.26f);
		}
		soundManagerGO = FindObjectOfType<soundManager> ();
		
		patternO = GetComponent<patternOmbres> ();
        //patternO.enabled = false;

		// pour lettres au dessus
		palier1 = lifeTime / 3;
		palier2 = lifeTime * 2 / 3;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
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
				if (jauge >= lifeTime) aEuAraigne();
				jaugeSprite.localScale = new Vector3 (jauge*6/(lifeTime/100),jaugeSprite.localScale.y,jaugeSprite.localScale.z);
				if (brilleRend.enabled == false) brilleRend.enabled=true;
			}
			else {
				if (brilleRend.enabled == true) brilleRend.enabled=false;
			}
			if (jauge > 0 && (!regarde || !joueurEstDansZone)) {
			jauge -= coefMonteJauge2 / 2;
				jaugeSprite.localScale = new Vector3 (jauge*6/(lifeTime/100),jaugeSprite.localScale.y,jaugeSprite.localScale.z);
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
		lettresHaut.gameObject.SetActive(true);
		ombresApparaissent ();
	}

	private void ombresApparaissent(){
		patternO.enabled = true;
		patternO.init ();
	}

	private void aEuAraigne(){
		Debug.Log ("araignee Eue");
		lettresHaut.End ();
		perso.desactiveLock ();
		soundManagerGO.stopSound (0);
		soundManagerGO.PlaySingleSound(finAraignee,false,1);
		anim.Play("araigneeVaincue");
	}
	
	// pour destruction après la fin de l'animation de disparition de l'airaignee

	private void destroyAraignee () {
		zoneAraigneeAppear zone = GetComponentInChildren<zoneAraigneeAppear> ();
		GameObject.FindObjectOfType<Canvas>().worldCamera = zone.mainCamera;
		zone.Camera01.enabled = false;
		GameObject.FindObjectOfType<Dezoom>().dezoomCamera();
		lettres.SetActive (true);
		perso.ExitZoneAraignee ();
		if (toilesQuiBloquent.Length != 0){
			foreach (GameObject toile in toilesQuiBloquent){
				toile.SetActive(false);}
		}
		GameObject.Destroy (this.gameObject);
	}
	
	
	// pour optimisation : apparition / disparition ombres
    public void checkOmbres() { }
		/*if (estApparu && patternO.enabled == false) {
			ombresApparaissent();
		}*/


	// pour optimisation tout ce qui se passe en active/desactive lock etc

	public void startRegard(){
		regarde = true;
	}

	public void stopRegard(){
		regarde = false;
	}

	void activeLock (){
	}

	void desactiveLock(){
	}

    }
