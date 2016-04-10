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

	//pour confrontation
	private bool estApparu = false;
	private bool regarde;
	private float coefMonteJauge2 = 0.5f;
	public patternOmbres patternO;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		jaugeSprite = transform.FindChild ("Jauge");
		jaugeSprite.localScale = new Vector3 (0,jaugeSprite.localScale.y,jaugeSprite.localScale.z);

		patternO = GetComponent<patternOmbres> ();
		//patternO.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Quand forme floue
		if (!estApparu) {
			if (joueurEstDansZone) {
				jauge += coefMonteJauge*1.5f;
				if (jauge >= tempsAppear) transformationEnAraignee();
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}

			if (!joueurEstDansZone && jauge > 0) {
				jauge -= coefMonteJauge / 2;
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}
		}

		//Quand Araignée
		if (estApparu) {
			regarde = Input.GetKey(KeyCode.V);
			if (regarde && joueurEstDansZone ) {
				jauge += coefMonteJauge2;
				if (jauge >= tempsAppear) aEuAraigne();
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}

			if (jauge > 0 && (!regarde || !joueurEstDansZone)) {
			jauge -= coefMonteJauge2 / 2;
			jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}

			// pour apparition / disparition ombres
			/*if ( patternO.enable == true && !regarde && !joueurEstDansZone){
			
			}*/

		}

	}


	// vistoire contre araigée si collision
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
		ombresApparaissent ();
		//transform.GetComponentInChildren<zoneAraigneeAppear> ().gameObject.SetActive (false);
		//jaugeSprite.gameObject.SetActive (false);
	}

	private void ombresApparaissent(){
		patternO.enabled = true;
		patternO.init ();
	}

	private void aEuAraigne(){
		Debug.Log ("araignee Eue");
		faitApparaitreBoutDeToile ();
		GameObject.Destroy (this.gameObject);
	}
	
	private void faitApparaitreBoutDeToile (){
	}

	// pour apparition / disparition ombres
	public void checkOmbres(){
		/*if (estApparu && patternO.enabled == false) {
			ombresApparaissent();
		}*/
	}
}
