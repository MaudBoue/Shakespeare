using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {

	
	public AudioSource[] sourcesbruitage;
	public AudioSource sourceMusique;
	
	public float lowPitchRange = 0.85f;
	public float hightPitchRange = 1.15f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//musique
	public void ChangeMusique(AudioClip Clip){
		sourceMusique.clip = Clip;
		sourceMusique.Play ();
	}

	public void stopMusique (){
		sourceMusique.Stop ();
	}


	//bruitages
	//bool changePitch à laisser en true pour que le son soit légèrement modifié (plus grave ou plus aigu) à chaque fois - false pour avoir toujorus le même son
	//int sourceNum à changer s'il y a plusieurs sons à la fois

	public void PlaySingleSound (AudioClip Clip, bool changePitch=true, int sourceNum = 0,float volume=1){
		if (sourceNum > sourcesbruitage.Length) {
			sourceNum = sourcesbruitage.Length;
		}
		if (changePitch) {
			float randomPitch = Random.Range (lowPitchRange, hightPitchRange);
			sourcesbruitage [sourceNum].pitch = randomPitch;
		} else {
			sourcesbruitage [sourceNum].pitch = 1;
		}
		sourcesbruitage[sourceNum].clip = Clip;
		sourcesbruitage[sourceNum].volume = volume;
		sourcesbruitage[sourceNum].Play ();
	}
	
	public void RandomizeSound ( AudioClip [] Clips, bool changePitch=true , int sourceNum = 0) {
			if (sourceNum > sourcesbruitage.Length) sourceNum = sourcesbruitage.Length;
			int randomIndex = Random.Range (0, Clips.Length);
		if (changePitch) {
			float randomPitch = Random.Range (lowPitchRange, hightPitchRange);
			sourcesbruitage [sourceNum].pitch = randomPitch; 
		}
		sourcesbruitage[sourceNum].clip = Clips [randomIndex];
		sourcesbruitage[sourceNum].Play ();
		
	}

	public void stopSound (int sourceNum = 0){
		sourcesbruitage[sourceNum].Stop ();
	}

}
