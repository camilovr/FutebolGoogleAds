using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zInfoMenu : MonoBehaviour {

	private Animator info;

	private AudioSource music;

	public Sprite musicON, musicOFF;

	private Button btnMusic;


	void Start(){
		info = GameObject.FindGameObjectWithTag ("InfoPanel").GetComponent<Animator> () as Animator;
		music = GameObject.Find ("zAudioManager").GetComponent<AudioSource> () as AudioSource;
		btnMusic = GameObject.Find ("MusicButton").GetComponent<Button> () as Button;
	}




	public void AnimaInfo (){
		
		info.Play ("zAnimaInfo");
	}

	public void AnimaInfoBack (){
		
		info.Play ("zAnimaInfoBack");
	}

	public void OnOffMusic(){
		music.mute = !music.mute;

		if (music.mute == true) {
			btnMusic.image.sprite = musicON;

		} else {
			btnMusic.image.sprite = musicOFF;
		}
	}

	public void Facebook(){

		Application.OpenURL ("https://www.facebook.com/LastLighthouseGames/");
	}

}
