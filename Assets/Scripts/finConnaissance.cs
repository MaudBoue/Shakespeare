using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class finConnaissance : MonoBehaviour {

	//private Animator anim;
	public bool animFinie;
	private bool finLancee;

	public Image blanc;
	private Camera mainCamera;
	private float alphaBlanc = 1;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindObjectOfType<Dezoom>().gameObject.GetComponent<Camera>();
		//anim = GetComponent<Animator> ();
		//anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


	if (finLancee) {
			alphaBlanc -= 0.25f*Time.deltaTime;
			blanc.color = new Color (1,1,1,1-alphaBlanc);
		}
		if (alphaBlanc <= 0) {
			Application.LoadLevel("EndScreenConnaissances");
		}
		}

	void OnTriggerEnter (Collider coll){
		if (coll.gameObject.tag == ("Player")){
			//anim.enabled = true;
			//anim.Play("fin");
			finLancee = true;
			blanc.gameObject.SetActive(true);

		}
	}
}
