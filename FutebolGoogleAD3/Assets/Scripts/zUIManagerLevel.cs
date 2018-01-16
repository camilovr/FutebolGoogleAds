using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zUIManagerLevel : MonoBehaviour {

	[SerializeField]
	private Text coinsLevelScene;



	void Start () {
		coinsLevelScene.text = PlayerPrefs.GetInt ("coinsSave").ToString ();
	}
	

}
