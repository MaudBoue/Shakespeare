using UnityEngine;
using System.Collections;

public class ombreCoteBougePates : MonoBehaviour
{
	private Animator anim;

	public bool gauche;
	public float[] tempsAnim;
	public string[] boolToChange;

	private float tpsDebut;

	private int numAnim;
	private bool isStarted;
	private bool hasAnimToStop;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	if (numAnim < tempsAnim.Length) {
			if (isStarted && Time.time >= tpsDebut + tempsAnim[numAnim]){
				numAnim += 1;
				anim.SetBool(boolToChange[numAnim-1],true);
				hasAnimToStop = true;
			    Debug.Log("anim"+numAnim);
			}
		}

		if(isStarted && hasAnimToStop) {
			if (Time.time >= tpsDebut + tempsAnim[numAnim-1] + 0.2f) {
				hasAnimToStop = false;
				anim.SetBool(boolToChange[numAnim-1],false);
				if (numAnim >= tempsAnim.Length) {
					Debug.Log("destroy");
					GameObject.Destroy(this.gameObject);
				}
			}
		}

	}

	public void init(Transform araignee) {
		if (gauche) anim = araignee.FindChild ("OmbreGauche").GetComponent<Animator> ();
		else anim = araignee.FindChild ("OmbreDroite").GetComponent<Animator> ();
		numAnim = 0;
		tpsDebut = Time.time;
		isStarted = true;
	}



}

