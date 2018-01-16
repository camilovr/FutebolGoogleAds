using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zSave : MonoBehaviour {

	public Text txt;
	public InputField boxTxt;

	public Text txtInt;
	public InputField boxTxtInt;

	public Text txtString;
	public InputField boxTxtString;

	private float testF;
	private int testI;
	private string testS;
	// Use this for initialization
	void Start () {
		txt.text = PlayerPrefs.GetFloat ("Pontos").ToString();
		txtInt.text = PlayerPrefs.GetInt ("Level").ToString();
		txtString.text = PlayerPrefs.GetString ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SaveFloat(){
		testF=float.Parse(boxTxt.text);
		PlayerPrefs.SetFloat ("Pontos", testF);
	}
	public void SaveInt(){
		testI=int.Parse(boxTxtInt.text);
		PlayerPrefs.SetInt ("Level", testI);
	}

	public void SaveString(){
		testS=boxTxtString.text;
		PlayerPrefs.SetString ("Player", testS);
	}




}
