using UnityEngine;
using System.Collections;

public class lettresAraignee : MonoBehaviour {

	private Transform[] lettres;
	private int i;
	public float DeltaLettres ;
	private float timeNextLettre;

	// Use this for initialization
	void Start () {
		lettres = transform.GetComponentsInChildren<Transform> ();
		Debug.Log (lettres.Length);
		i = 0;
		foreach (Transform lettre in lettres){
			lettre.gameObject.SetActive(false);
		}

		timeNextLettre = Time.time + DeltaLettres;		
	}
	
	// Update is called once per frame
	void Update () {
		if (i < lettres.Length && Time.time >= timeNextLettre ) {
			appear ();
		}
	}

	private void appear(){
		lettres [i].gameObject.SetActive (true);
		timeNextLettre = Time.time + DeltaLettres;
		i += 1;
		//if (i > lettres.Length)
	}
}
