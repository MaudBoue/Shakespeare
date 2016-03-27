using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public move2 persoFixe;
	public move3 persoRot;
	public cameraFollow cameraFixe;
	public cameraFollowRotate cameraRotate;
	public GameObject cameraGO;
	private bool isProche = false;
	private zoneAraignee[] collideAraignees;

	// Use this for initialization
	void Start () {
		collideAraignees = GameObject.FindObjectsOfType<zoneAraignee>();
		/*activeChangementAraignee(false);
		setCameraLoin1();*/
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Q)) {
			//if (Application.loadedLevel == 1)	Application.LoadLevel("pres");
			//else Application.LoadLevel("loin");
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown (KeyCode.Escape)){
			Application.Quit();
		}

		if (Input.GetKeyDown (KeyCode.A)) { // mode vue de haut
			/*persoFixe.enabled = !persoFixe.enabled;
			persoRot.enabled = !persoRot.enabled;
			cameraFixe.enabled = !cameraFixe.enabled;
			cameraRotate.enabled = !cameraRotate.enabled;
			bool isDroit = cameraFixe.enabled;
			if (isDroit) {cameraGO.transform.rotation = new Quaternion(0.3f,0,0,0.9f);}*/
			activeChangementAraignee(false);
			setCameraLoin1();
			Debug.Log ("camera vue de haut");
		}

		if (Input.GetKeyDown (KeyCode.Z)) { // mode vue de près
			activeChangementAraignee(false);
			setCameraProche1();
			Debug.Log ("camera vue de près");
		}

		if (Input.GetKeyDown (KeyCode.E)) { //mode entre les deux bizarre ^^
			setCameraLoin1();
			activeChangementAraignee (true);
			Debug.Log ("camera vqui change");
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

	private void activeChangementAraignee(bool value){
		foreach (zoneAraignee zone in collideAraignees) {
			zone.gameObject.SetActive(value);
		}
	}

	// pour mode mixte
	public void setCameraClose(){
		isProche = true;
		setCameraProche1 ();
		}	

	public void setCameraLoin(){
		isProche = false;
		StartCoroutine (cameraLoinLater() );}

	IEnumerator cameraLoinLater (){
		yield return new WaitForSeconds(0.5f);
		if (!isProche) {
			setCameraLoin1();
		}
	}

}

	