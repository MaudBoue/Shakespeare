using UnityEngine;
using System.Collections;

public class move2 : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10,10);
	private Vector3 movement;

	private Rigidbody rigid;
	
	
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		movement = new Vector3(inputX * speed.x,rigid.velocity.y,speed.y * inputY);

		
	}
	
	void FixedUpdate(){
		rigid.velocity = movement;	
	}
	
	
	
	
	
	
}
