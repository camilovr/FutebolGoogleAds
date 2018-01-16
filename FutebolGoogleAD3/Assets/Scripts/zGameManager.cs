using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zGameManager : MonoBehaviour {

	public static zGameManager instance;

	//Ball
	[SerializeField]
	public GameObject[] zBall;
	public int ballNum = 2;
	public bool ballDied;
	public int ballsScene=0;
	public Transform pos;

	public bool win;

	public int shoot = 0;

	//public int currentLevel;
	public bool gameStarted;

	private bool adsUmaVez = false;


	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
		SceneManager.sceneLoaded += Load;
		pos = GameObject.Find ("zStartPos").GetComponent<Transform> ();
	}

	void Load(Scene scene, LoadSceneMode mode){
		if (zCurrentLevel.instance.level != 0 && zCurrentLevel.instance.level != 1 && zCurrentLevel.instance.level != 2) {
			pos = GameObject.Find ("zStartPos").GetComponent<Transform> ();
			StartGame ();
		}

	}

	void Start () {
		//PlayerPrefs.DeleteAll ();
		StartGame ();
		//zScoreManager.instance.GameStartScoreM ();
	}
	
	// Update is called once per frame
	void Update () {
		zScoreManager.instance.UpdateScore ();
		zUIManager.instance.UpdateUI ();



		if (ballNum <= 0 && win==false)
		{
			GameOver ();
		}
		if(win==true)
		{
			WinGame ();
		}
		if (win == false) 
		{
			BirthBall ();
		}
	}

	void BirthBall (){
		if (zCurrentLevel.instance.level >= 3) {
			if (ballNum > 0 && ballsScene == 0 && Camera.main.transform.position.x <= 0.05f) {
				Instantiate (zBall[zCurrentLevel.instance.ballSelected], new Vector2 (pos.position.x, pos.position.y), Quaternion.identity);
				ballsScene += 1;
				shoot = 0;
			}
		} else {
			if (ballNum > 0 && ballsScene == 0) {
				Instantiate (zBall[zCurrentLevel.instance.ballSelected], new Vector2(pos.position.x,pos.position.y),Quaternion.identity);
				ballsScene += 1;
				shoot = 0;
			}
		}
	}

	void GameOver(){
		zUIManager.instance.GameOverUI ();
		gameStarted = false;

		if (adsUmaVez == false) 
		{

		zGoogleMobileAds.instance.ShowInter ();
			adsUmaVez = true;
		}
	}

	void WinGame(){
		zUIManager.instance.WinGameUI ();
		gameStarted = false;
	}

	void StartGame(){
		gameStarted = true;
		ballNum = 2;
		ballsScene = 0;
		win = false;
		zUIManager.instance.StartUI ();
		adsUmaVez = false;
	}

}
