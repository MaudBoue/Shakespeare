using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class finIgnorance : MonoBehaviour {

	public bool finDuChemin;
	public Image blanc;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player") {
			if (finDuChemin) Application.LoadLevel("EndScreenIgnorance");
			else blanc.gameObject.SetActive(true);
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Player") {
			if (finDuChemin)
				blanc.gameObject.SetActive (true);
		}
	}

	void OnTriggerStay (Collider coll){
		if (!finDuChemin && coll.gameObject.tag == "Player") {
			if (blanc) {
				blanc.color = new Color (1,1,1,1);}
			}
	}
}
