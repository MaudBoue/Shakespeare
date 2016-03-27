using UnityEngine;
using System.Collections;

public class zoneAraignee : MonoBehaviour {

	private gameManager GM;
	private move3 perso;
	private Transform parent;

	// Use this for initialization
	void Start () {
		GM = GameObject.FindObjectOfType<gameManager> ();
		perso = GM.persoRot;
		parent = transform.parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
	if (coll.gameObject.tag == ("Player")) {
			perso.setRotateToAraignee(parent);
			GM.setCameraClose();
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == ("Player")) {
			GM.setCameraLoin();
		}
	}
}
