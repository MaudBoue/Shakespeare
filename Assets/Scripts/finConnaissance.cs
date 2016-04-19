using UnityEngine;
using System.Collections;

public class finConnaissance : MonoBehaviour {

	private Animator anim;
	public bool animFinie;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (animFinie) {
			Application.LoadLevel("EndScreenConnaissances");
		}
	}

	void OnTriggerEnter (Collider coll){
		if (coll.gameObject.tag == ("Player")){
			anim.enabled = true;
			anim.Play("fin");
		}
	}
}
