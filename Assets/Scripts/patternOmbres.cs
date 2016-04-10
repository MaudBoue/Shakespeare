using UnityEngine;
using System.Collections;

public class patternOmbres : MonoBehaviour {
	
	public float[] temps;
	public GameObject[] Ombres;

	private int currentOmbre;
	private float timeNextOmbre;

	public Transform parent;

	public GameObject vagueDuDebut;

	private bool isActive = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time >= timeNextOmbre && isActive) {
			timeNextOmbre = Time.time + temps[currentOmbre];
			GameObject Shadow = Instantiate(Ombres[currentOmbre]);
			Shadow.transform.parent = parent;
			Shadow.transform.localPosition = new Vector3(0,1.34f,0);
			if (Shadow.GetComponent<ombreCoteBougePates>() != null){
				Shadow.GetComponent<ombreCoteBougePates>().init(parent);
			}
			currentOmbre +=1;
			if (currentOmbre >= Ombres.Length) {
				currentOmbre = 0;
			}
		}



	}

	public void deactive(){
		isActive = false;
	}

	public void init() {
		currentOmbre = 0;
		// instantiate wave
		/*GameObject Shadow = Instantiate(vagueDuDebut);
		Shadow.transform.parent = parent;
		Shadow.transform.localPosition = new Vector3(0,1.34f,0);

		*/timeNextOmbre = Time.time + 1;
		isActive = true;
	}
}
