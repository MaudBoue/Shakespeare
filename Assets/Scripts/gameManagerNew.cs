using UnityEngine;
using System.Collections;

public class gameManagerNew : MonoBehaviour
{

	public bool isPause;
	public GameObject ecranPause;
	private Canvas canvasGO;

	// Use this for initialization
	void Start ()
	{
		canvasGO = GameObject.FindObjectOfType<Canvas> ();
		canvasGO.worldCamera = GameObject.FindObjectOfType<Dezoom> ().GetComponent<Camera> ();
		isPause = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit();
		}

		/*if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}*/

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!isPause) metPause ();
			else quitter();
		}

		if (isPause && Input.GetKeyDown (KeyCode.Space)) {
			enlevePause();
		}
	}

	void metPause() {
		isPause = true;
		Time.timeScale = 0;
		if (ecranPause) {
			ecranPause.SetActive(true);
		}
	}

	void quitter () {
		enlevePause ();
		Application.LoadLevel("startScreen");
	}

	void enlevePause(){
		isPause = false;
		Time.timeScale = 1;
		if (ecranPause) {
			ecranPause.SetActive(false);
		}
	}
}

