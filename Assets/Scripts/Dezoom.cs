using UnityEngine;
using System.Collections;

public class Dezoom : MonoBehaviour
{

	public int araigneedead;
	public Transform target;
	public Transform player;
	private Vector3 distance;

	void Start ()
	{

		araigneedead = 0;
		distance = new Vector3 (0, 2, -2.5f);
	}

	void FixeUpdate ()
	{

        
	}

	public void dezoomCamera ()
	{
		araigneedead = araigneedead + 1;
		Debug.Log ("araigneedead");

		if (araigneedead > 0 && araigneedead < 6) {
			transform.position = target.transform.position + distance;
		}
	}
}