using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 distancePerso;
	public float AngleX;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler (AngleX, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (target) {	
			// transform.rotation = Quaternion.Euler (AngleX, 0, 0); à activer pour pouvoir tester de changer l'angle de la caméra pendant le jeu 
			Vector3 destination = new Vector3 (target.position.x, target.position.y + distancePerso.y, target.position.z + distancePerso.z);
			transform.position = destination;
		}
	
	}


}
