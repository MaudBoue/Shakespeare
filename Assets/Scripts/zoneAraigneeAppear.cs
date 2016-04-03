using UnityEngine;
using System.Collections;

public class zoneAraigneeAppear : MonoBehaviour {

	private araignee parent;

	// Use this for initialization
	void Start () {
		parent = transform.parent.GetComponent<araignee>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == ("Player")) {
			parent.joueurEstDansZone = true;
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == ("Player")) {	
			parent.joueurEstDansZone = false;
		}
	}
}
