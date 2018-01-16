using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zScoreManager : MonoBehaviour {

	public static zScoreManager instance;
	public int coins;

	void Awake(){
		if(instance==null){
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	void Start(){
		zScoreManager.instance.GameStartScoreM ();
	}


	public void GameStartScoreM(){
		if (PlayerPrefs.HasKey ("coinsSave")) {
			coins = PlayerPrefs.GetInt ("coinsSave");
		} else {
			coins = 100;
			PlayerPrefs.SetInt ("coinsSave",coins);
		}
	}

	public void UpdateScore(){
		coins = PlayerPrefs.GetInt ("coinsSave");
	}

	public void CollectCoins(int coin){
		coins += coin;
		SaveCoins (coins);

	}

	public void UseCoins (int coin){
		coins -= coin;
		SaveCoins (coins);
	}

	public void SaveCoins(int coin){
		PlayerPrefs.SetInt ("coinsSave",coin);
	}

}
