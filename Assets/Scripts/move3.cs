using UnityEngine;
using System.Collections;

public class move3 : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10,10);
	private Vector3 movement;
	private float rot = 0;

	private Vector3 rotVect;
	
	private Rigidbody rigid;

	public bool bloque = false;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
		
			movement = new Vector3 (0, rigid.velocity.y, speed.y * inputY);
		if (!bloque) {
			rot += inputX * speed.x;
		}	

	}
	
	void FixedUpdate(){
		if (!bloque) {
		rigid.velocity = Quaternion.Euler(0,rot,0) * movement;	
		rigid.rotation = Quaternion.Euler (0, rot, 0);}	
	}
	

	public void setRotateToAraignee(Transform araignee){
		Vector3 direction = araignee.position - transform.position ;	
		bloque = true;
		transform.rotation = Quaternion.LookRotation(direction);
		rot = 0;
		float inversRot = Quaternion.Angle (Quaternion.Euler (0, rot, 0), Quaternion.LookRotation (direction));
		if (araignee.position.x - transform.position.x > 0) {
			rot = inversRot;
		}
		else {rot = - inversRot;}
		bloque = false;

	}
	

}
