using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class finIgnorance : MonoBehaviour {

	public bool finDuChemin;
	public Image blanc;
	private Camera mainCamera;
	private float alphaBlanc;
	private Transform joueur;
	private Transform rep;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindObjectOfType<Dezoom>().gameObject.GetComponent<Camera>();
		joueur = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		rep = GetComponentInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player") {
			if (finDuChemin) Application.LoadLevel("EndScreenIgnorance");
			else {GameObject.FindObjectOfType<Canvas>().worldCamera=mainCamera;
				blanc.gameObject.SetActive(true);}
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Player") {
			if (!finDuChemin)
				alphaBlanc = 0;
				blanc.gameObject.SetActive (false);
		}
	}

	void OnTriggerStay (Collider coll){
		if (!finDuChemin && coll.gameObject.tag == "Player") {
			if (blanc) {
				alphaBlanc = Vector3.Distance(rep.position, joueur.position)/18;
				blanc.color = new Color (1,1,1,1-alphaBlanc);}
			if (alphaBlanc <= 0.1f)  Application.LoadLevel("EndScreenIgnorance");
		}
	}
}
