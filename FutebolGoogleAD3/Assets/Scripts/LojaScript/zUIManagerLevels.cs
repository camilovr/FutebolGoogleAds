using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zUIManagerLevels : MonoBehaviour {

	[SerializeField]
	private Text coinsLevel;

	public static zUIManagerLevels instance;

	void Start () {
		zScoreManager.instance.UpdateScore ();
		coinsLevel.text = PlayerPrefs.GetInt ("coinsSave").ToString ();
	}

	public void UpdateShop () {
		//zScoreManager.instance.UpdateScore ();
		coinsLevel.text = PlayerPrefs.GetInt ("coinsSave").ToString ();
	}

}
