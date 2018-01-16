using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zMenuGO : MonoBehaviour {

	public bool whatchedVideo = true;

	void Start(){
		if (whatchedVideo == true) {
			zGoogleMobileAds.instance.RequestRewardVid ();
			whatchedVideo = false;
		}
	}

	public void MenuGO () {
		SceneManager.LoadScene (1);
	}

	public void ViewADz(){
		zGoogleMobileAds.instance.ShowRewardVid ();
		whatchedVideo = true;
	}
}
