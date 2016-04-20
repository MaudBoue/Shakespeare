using UnityEngine;
using System.Collections;

public class lockScript : MonoBehaviour {

	public bool destroyable ;
	public bool destroy = false;

	// Use this for initialization
	void Start () {
		// pour que ceux des araignées ne puissent pas être détruits
	//if (transform.parent.gameObject.name == "resizeLock") {
		if (transform.parent && transform.parent.gameObject.name == "resizeLock"){
			destroyable = false;
		}
	if (destroyable) {
			GetComponent<Animator>().SetBool("dansLeVide",true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (destroy){
			GameObject.Destroy(this.gameObject);
		}
	
	}


		

}
