using UnityEngine;
using System.Collections;

public class zoneAraigneeAppear : MonoBehaviour {

	private araignee parent;
    //Camera
    private bool IsSwitch = false;
    public Camera mainCamera;
    public Camera Camera01;
	// pour feedback quand touché
	static public Canvas canvasGO;

    // Use this for initialization
    void Start () {
		parent = transform.parent.GetComponent<araignee>();

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
            Camera01.enabled = true;
			canvasGO.worldCamera = Camera01;
            parent.checkOmbres();
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == ("Player") && Camera01) {	
			parent.joueurEstDansZone = false;
			coll.GetComponent<move2>().Regarde=false;
            Camera01.enabled = false;
        }
	}
}
