using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zAudioManager : MonoBehaviour {

	//musics
	public AudioClip[] clips;
	public AudioSource musicBG;

	// sounds FXs
	public AudioClip[] clipsFX;
	public AudioSource soundsFX;

	public static zAudioManager instance;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!musicBG.isPlaying) {
			musicBG.clip = GetRandom ();
			musicBG.Play ();
		}
	}

	AudioClip GetRandom(){
		return clips[Random.Range(0,clips.Length)];
	}

	public void PlayFXsounds(int index){
		soundsFX.clip = clipsFX [index];
		soundsFX.Play ();
	}
}
