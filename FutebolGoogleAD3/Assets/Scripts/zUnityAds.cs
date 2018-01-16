using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zUnityAds : MonoBehaviour {

	public static zUnityAds instance;
	private Button btnAds;
	public bool adsBtnAcionado = false;


	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
		{
			Destroy (this.gameObject);
		}

		SceneManager.sceneLoaded += PegaBtn;

	}

	void PegaBtn(Scene cena, LoadSceneMode modo)
	{
		if(zCurrentLevel.instance.level != 0 && zCurrentLevel.instance.level != 1 && zCurrentLevel.instance.level != 2)
		{
			btnAds = GameObject.Find ("ADsToCoin").GetComponent<Button> ();
//			btnAds.onClick.AddListener (AdsBtn);
		}
	}

//	void AdsBtn()
//	{
//				if (Advertisement.IsReady ("rewardedVideo")) {
//					Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = AdsAnalise});
//					adsBtnAcionado = true;
//				}
//	}
//
//		void AdsAnalise(ShowResult result)
//		{
//		if(result == ShowResult.Finished)
//		{
//				zScoreManager.instance.CollectCoins (1000);
//		}
//		}
//
//
//	public void showAds()
//	{
//		Debug.Log (PlayerPrefs.GetInt ("AdsUnity"));
//		if (PlayerPrefs.HasKey ("AdsUnity")) {
//
//			if (PlayerPrefs.GetInt ("AdsUnity") >= 3) {
//
//				if (Advertisement.IsReady ("video")) {
//					Advertisement.Show ("video");
//						
//
//					PlayerPrefs.SetInt ("AdsUnity", 1);
//				}
//				} 
//				else {
//
//					PlayerPrefs.SetInt ("AdsUnity", PlayerPrefs.GetInt ("AdsUnity") + 1);
//				}
//
//
//
//		} 
//		else 
//		{
//			PlayerPrefs.SetInt ("AdsUnity", 1);
//		}
//	}
}
