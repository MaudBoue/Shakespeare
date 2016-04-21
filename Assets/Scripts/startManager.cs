using UnityEngine;
using System.Collections;

public class startManager : MonoBehaviour {

	public bool startScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.B)){
			if (startScreen){
			Application.LoadLevel("Testlabyrinthe13");
			}
			else {
			Application.LoadLevel("startScreen");
			}
		}

	}
}
