using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class zGoogleMobileAds : MonoBehaviour
{
	public static zGoogleMobileAds instance;

	private Button btnAds;
	public bool adsBtnAcionado = false;


	//private BannerView bannerView;
	private InterstitialAd interstitial;
	//private NativeExpressAdView nativeExpressAdView;
	private RewardBasedVideoAd rewardBasedVideo;
	private float deltaTime = 0.0f;
	private static string outputMessage = string.Empty;

	public static string OutputMessage
	{
		set { outputMessage = value; }
	}

	public void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	public void Start()
	{
//		PegaBtn ();

		#if UNITY_ANDROID
		string appId = "ca-app-pub-2636802702722373~9175543872";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~1458002511";
		#else
		string appId = "unexpected_platform";
		#endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);

		// Get singleton reward based video ad reference.
		this.rewardBasedVideo = RewardBasedVideoAd.Instance;

		// RewardBasedVideoAd is a singleton, so handlers should only be registered once.
		this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
		this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
		this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
		this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
		this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
		this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
		this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
		}

		public void Update()
		{
		// Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
		// value.
		this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;
		}




		public void RequestInter()
			{
			this.RequestInterstitial();
			}

		public void ShowInter()
			{
			this.ShowInterstitial();
			}

		public void DestroyInter(){
			if (this.interstitial!=null){
				this.interstitial.Destroy();
			}
		}




		public void RequestRewardVid()
			{
				this.RequestRewardBasedVideo();
			}

		public void ShowRewardVid()
			{
				this.ShowRewardBasedVideo();
			}



		// Returns an ad request with custom ad targeting.
		private AdRequest CreateAdRequest()
		{
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Female)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
		}



		private void RequestInterstitial()
		{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-2636802702722373/5880007130";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Clean up interstitial ad before creating a new one.
		if (this.interstitial != null)
		{
		this.interstitial.Destroy();
		}

		// Create an interstitial.
		this.interstitial = new InterstitialAd(adUnitId);

		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

		// Load an interstitial ad.
		this.interstitial.LoadAd(this.CreateAdRequest());
		}


		private void RequestRewardBasedVideo()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-2636802702722373/9430038205";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/1712485313";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
		}

		private void ShowInterstitial()
	{
		Debug.Log (PlayerPrefs.GetInt ("AdsCount"));
		if (PlayerPrefs.HasKey ("AdsCount")) {
			if (PlayerPrefs.GetInt ("AdsCount") == 2) {
				DestroyInter ();
				RequestInter ();
			}
			if (PlayerPrefs.GetInt ("AdsCount") >= 3) {
				if (this.interstitial.IsLoaded ()) {
					this.interstitial.Show ();
					PlayerPrefs.SetInt ("AdsCount", 1);
					Debug.Log ("Interstitial..ok");
				} else {
					MonoBehaviour.print ("Interstitial is not ready yet");
				}
			} else {
				PlayerPrefs.SetInt ("AdsCount", PlayerPrefs.GetInt ("AdsCount") + 1);	
			}

		} else {
			PlayerPrefs.SetInt ("AdsCount", 1);
		}
	}
		private void ShowRewardBasedVideo()
		{
		if (this.rewardBasedVideo.IsLoaded())
		{
		this.rewardBasedVideo.Show();
		}
		else
		{
		MonoBehaviour.print("Reward based video ad is not ready yet");
		}
		}

	

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialLoaded event received");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print(
		"HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialOpened event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialLeftApplication event received");
		}

		#endregion



		#region RewardBasedVideo callback handlers

		public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
		}

		public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print(
		"HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
		}

		public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
		}

		public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
		}

		public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
		}

		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
		zScoreManager.instance.CollectCoins (1000);
		zUIManagerLevels.instance.UpdateShop ();
		Debug.Log ("Atualizando moedasssss....");
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print(
		"HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
		}

		public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
		}

		#endregion

							
		}