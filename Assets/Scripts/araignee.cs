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


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		jaugeSprite = transform.FindChild ("Jauge");
		jaugeSprite.localScale = new Vector3 (0,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
	
		// Quand forme floue
		if (!estApparu) {
			if (joueurEstDansZone) {
				jauge += coefMonteJauge;
				if (jauge >= tempsAppear) transformationEnAraignee();
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}

			if (!joueurEstDansZone && jauge > 0) {
				jauge -= coefMonteJauge / 2;
				jaugeSprite.localScale = new Vector3 (jauge*6,jaugeSprite.localScale.y,jaugeSprite.localScale.z);
			}
		}



	}

	private void transformationEnAraignee(){
		Debug.Log ("Apparu");
		estApparu = true;
		anim.SetBool ("apparu", true);
		transform.GetComponentInChildren<zoneAraigneeAppear> ().gameObject.SetActive (false);
		jaugeSprite.gameObject.SetActive (false);
	}
}
