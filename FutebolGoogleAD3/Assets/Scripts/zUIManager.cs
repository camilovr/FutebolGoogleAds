using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zUIManager : MonoBehaviour {


	public static zUIManager instance;
	[SerializeField]
	private Text pointsUI,ballsUI;
	[SerializeField]
	private GameObject losePanel,winPanel,pausePanel;
	[SerializeField]
	private Button pauseBtn,pauseBtnBack;
	[SerializeField]
	private Button againBtn,levelMenuBtn;//lose

	private Button againBtnWIN,levelMenuWIN,nextLevelWIN,againBtnLevel; //win

	public int coinsBefore, coinsAfter, coinsResume;

	void Awake(){
		if(instance==null){
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
		SceneManager.sceneLoaded += Load;

		GetData ();
		//OnOffPanel ();
	}

	void Load(Scene scene, LoadSceneMode mode){

		GetData ();
	}
	void GetData(){
		if (zCurrentLevel.instance.level != 1 && zCurrentLevel.instance.level!=2) {

			pointsUI = GameObject.Find ("UIpoints").GetComponent<Text> ();
			ballsUI = GameObject.Find ("UIballs").GetComponent<Text> ();

			losePanel = GameObject.Find ("LosePanel");
			winPanel = GameObject.Find ("WinPanel");
			pausePanel = GameObject.Find ("PausePanel");

			pauseBtn = GameObject.Find ("PauseButton").GetComponent<Button> ();
			pauseBtnBack = GameObject.Find ("Avancar").GetComponent<Button> ();
			//lose
			againBtn = GameObject.Find ("Again").GetComponent<Button> ();
			levelMenuBtn = GameObject.Find ("levelBtnMenu").GetComponent<Button> ();
			//win
			againBtnWIN = GameObject.Find ("AgainWin").GetComponent<Button> ();
			levelMenuWIN = GameObject.Find ("levelBtnMenuWin").GetComponent<Button> ();
			nextLevelWIN = GameObject.Find ("NextLevel").GetComponent<Button> ();
			againBtnLevel= GameObject.Find ("RestartButton").GetComponent<Button> ();
			//onClick

			pauseBtn.onClick.AddListener (Pause);
			pauseBtnBack.onClick.AddListener (PauseBack);
			//onClick lose
			againBtn.onClick.AddListener (PlayAgain);
			levelMenuBtn.onClick.AddListener (LevelMenu);
			//onClick win
			againBtnWIN.onClick.AddListener (PlayAgain);
			levelMenuWIN.onClick.AddListener (LevelMenu);
			nextLevelWIN.onClick.AddListener (NextLevel);
			//jogar novamente
			againBtnLevel.onClick.AddListener (PlayAgain);
			//coins
			coinsBefore = PlayerPrefs.GetInt ("coinsSave");
		}
	}

	public void StartUI(){
		OnOffPanel ();
	}

	public void UpdateUI(){
		pointsUI.text=zScoreManager.instance.coins.ToString();
		ballsUI.text = zGameManager.instance.ballNum.ToString ();
		coinsAfter = zScoreManager.instance.coins;
	}

	public void GameOverUI(){
		losePanel.SetActive (true);
	}

	public void WinGameUI(){
		winPanel.SetActive (true);
	}

	void OnOffPanel(){
		StartCoroutine (Temp());
	}

	void Pause(){
		pausePanel.SetActive (true);
		pausePanel.GetComponent<Animator> ().Play ("zAnim_PausePanel");
		Time.timeScale = 0;
	}
	void PauseBack(){
		
		pausePanel.GetComponent<Animator> ().Play ("zAnim_PauseBack");
		Time.timeScale = 1;
		StartCoroutine (WaitPause());
	}
	IEnumerator WaitPause(){
		yield return new WaitForSeconds (0.8f);
		pausePanel.SetActive (false);
	}

	IEnumerator Temp(){
		yield return new WaitForSeconds (0.001f);
		losePanel.SetActive (false);
		winPanel.SetActive (false);
		pausePanel.SetActive (false);
	}

	void PlayAgain(){
		if (zGameManager.instance.win == false ) {
			SceneManager.LoadScene (zCurrentLevel.instance.level);

		}
		else if (zGameManager.instance.win == false ){
			SceneManager.LoadScene (zCurrentLevel.instance.level);
			coinsResume = coinsAfter - coinsBefore;
			zScoreManager.instance.UseCoins (coinsResume);
			coinsResume = 0;
		} else {
			SceneManager.LoadScene (zCurrentLevel.instance.level);
			coinsResume = 0;
		}

//		if(zGoogleMobileAds.this.interstitial==null){
//			zGoogleMobileAds.instance.RequestInter();
//		} else{
//			zGoogleMobileAds.instance.DestroyInter ();
//		}

	}

	void LevelMenu(){
		if (zGameManager.instance.win == false ) {
			
			SceneManager.LoadScene (1);
		}
		else if (zGameManager.instance.win == false ){
			coinsResume = coinsAfter - coinsBefore;
			zScoreManager.instance.UseCoins (coinsResume);
			coinsResume = 0;
			SceneManager.LoadScene (1);
		} else {
			coinsResume = 0;
			SceneManager.LoadScene (1);
		}
	}

	void NextLevel(){
		if (zGameManager.instance.win == true) {
			int temp = zCurrentLevel.instance.level + 1;
			SceneManager.LoadScene (temp);
		}
	}

	void ShowReward(){
	
	}
}
