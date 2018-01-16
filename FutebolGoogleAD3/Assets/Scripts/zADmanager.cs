using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using admob;

public class zADmanager : MonoBehaviour {

	public static zADmanager Instance{ set; get;}

	public string bannerID;
	public string interstitialID;


//	private void Start () {
//
//		Instance = this;
//		DontDestroyOnLoad (gameObject);
//
//		#if UNITY_EDITOR
//		#elif UNITY_ANDROID
//		Admob.Instance ().initAdmob (bannerID,interstitialID);
//		//Admob.Instance().setTesting(true);
//		Admob.Instance ().loadInterstitial ();
//		#endif 
//	}
//
//	public void ShowBanner(){
//		#if UNITY_EDITOR
//		Debug.Log("Unable to play ADs from Editor");
//		#elif UNITY_ANDROID
//		Admob.Instance ().showBannerRelative (AdSize.Banner,AdPosition.BOTTOM_CENTER,5);
//		#endif 
//	}
//
//	public void ShowInterstitial(){
//		#if UNITY_EDITOR
//		Debug.Log("Unable to show Interstitial from Editor");
//		#elif UNITY_ANDROID
//		if (Admob.Instance ().isInterstitialReady ()) {
//			Admob.Instance ().showInterstitial ();
//		}
//		#endif 
//	}
//
//
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
