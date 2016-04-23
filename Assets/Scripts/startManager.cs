using UnityEngine;
using System.Collections;

public class startManager : MonoBehaviour {

	public bool startScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (startScreen){
			Application.LoadLevel("mainLaby");
			}
			else {
			Application.LoadLevel("startScreen");
			}
		}

	}
}
