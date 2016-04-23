using UnityEngine;
using System.Collections;

public class lettresAraigneesHaut : MonoBehaviour {

	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void palier1Atteint(int i) {
		anim.SetInteger("phase", i);
	}

	public void End(){
		Debug.Log ("end lettres");
		anim.SetBool("end", true);
	}
}
