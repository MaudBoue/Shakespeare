using UnityEngine;
using System.Collections;

public class gameManagerNew : MonoBehaviour
{

	private bool isPause;
	public GameObject ecranPause;

	// Use this for initialization
	void Start ()
	{
		isPause = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			metPause ();
		}
	}

	void metPause() {
		isPause = true;
		if (ecranPause) {
			ecranPause.SetActive(true);
		}
	}

	void quitter () {
		Application.LoadLevel("startScreen");
	}

	void enlevePause(){
		isPause = false;
		if (ecranPause) {
			ecranPause.SetActive(false);
		}
	}
}

