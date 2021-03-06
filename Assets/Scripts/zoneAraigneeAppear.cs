﻿using UnityEngine;
using System.Collections;

public class zoneAraigneeAppear : MonoBehaviour {

	private araignee parent;
    
	//Camera
    public Camera mainCamera;
    public Camera Camera01;

	// pour feedback quand touché
	static public Canvas canvasGO;

	//pour lock
	static public move2 perso;

    // Use this for initialization
    void Start () {
		perso = FindObjectOfType<move2> ();
		parent = transform.parent.GetComponent<araignee>();
		mainCamera = GameObject.FindObjectOfType<Dezoom> ().GetComponent<Camera> ();
        mainCamera.enabled = true;
        Camera01.enabled = false;
		canvasGO = FindObjectOfType<Canvas> ();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Camera01.enabled == false);
    }

	void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == ("Player") && Camera01) {
			parent.joueurEstDansZone = true;
			perso.dansZoneAraignee(parent.Lock);
            Camera01.enabled = true;
			canvasGO.worldCamera = Camera01;
            //parent.checkOmbres();
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == ("Player") && Camera01) {	
			parent.joueurEstDansZone = false;
			perso.ExitZoneAraignee();
			canvasGO.worldCamera = mainCamera;
            Camera01.enabled = false;
        }
	}
}
