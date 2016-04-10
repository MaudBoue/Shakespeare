using UnityEngine;
using System.Collections;

public class Ombre : MonoBehaviour {

	public bool destroy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	if (destroy) {
			GameObject.Destroy(this.gameObject);
		}

	}
}
