using UnityEngine;
using System.Collections;

public class gameManager2 : MonoBehaviour {
	
	public move2 persoFixe;
	public move3 persoRot;
	public cameraFollow cameraFixe;
	public cameraFollowRotate cameraRotate;
	public GameObject cameraGO;
		
	// Use this for initialization
	void Start () {
		/*activeChangementAraignee(false);
		setCameraLoin1();*/
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)){
			Application.Quit();
		}
		
		if (Input.GetKeyDown (KeyCode.A)) { // mode vue de haut
			setCameraLoin1();
			Debug.Log ("camera vue de haut");
		}
		
		if (Input.GetKeyDown (KeyCode.Z)) { // mode vue de près
			setCameraProche1();
			Debug.Log ("camera vue de près");
		}

		
	}
	
	private void setCameraProche1(){
		persoFixe.enabled = false;
		persoRot.enabled = true;
		cameraFixe.enabled = false;
		cameraRotate.enabled = true;
	}
	
	private void setCameraLoin1(){
		persoFixe.enabled = true;
		persoRot.enabled = false; 
		cameraFixe.enabled = true;
		cameraRotate.enabled = false;
		cameraGO.transform.rotation = new Quaternion (0.3f, 0, 0, 0.9f);
	}
	

}

