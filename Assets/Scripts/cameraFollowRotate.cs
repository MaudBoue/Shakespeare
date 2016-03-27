using UnityEngine;
using System.Collections;

public class cameraFollowRotate : MonoBehaviour {

	public Transform target;
	public Transform perso;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target && perso) {	
			transform.position = target.position;
			direction = new Vector3(perso.position.x, perso.position.y, perso.position.z) - target.position ;
			transform.rotation = Quaternion.LookRotation(direction);
		}

	
	
	}
}
