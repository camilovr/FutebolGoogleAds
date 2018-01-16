using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class zBallsShop : MonoBehaviour {

	public static zBallsShop instance;

	public List<zBallz> ballsList = new List<zBallz>();
	public List<GameObject> supportBallsList = new List<GameObject> ();
	public List<GameObject> shopBtnList = new List<GameObject> ();

	public GameObject baseBallItem;
	public Transform content;


	void Awake(){
		if (instance == null) {
			instance = this;
		}
	} 

	void Start () {

		//PlayerPrefs.DeleteAll ();
		FillList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FillList(){
		foreach(zBallz b in ballsList){
			GameObject itensBall = Instantiate (baseBallItem) as GameObject;
			itensBall.transform.SetParent (content,false);
			zBallSupport item = itensBall.GetComponent<zBallSupport> ();

			item.ballID = b.ballsID;
			item.ballPrice.text = b.ballsPrice.ToString();
			item.buyButton.GetComponent<zBuyBall> ().ballsIDs=b.ballsID;

			//shopBtnList
			shopBtnList.Add(item.buyButton);


			//supportBallsList 
			supportBallsList.Add(itensBall);

			if(PlayerPrefs.GetInt("BTN"+item.ballID)==1)
			{
				b.ballsBought = true;
			}

			if(PlayerPrefs.HasKey("BTNS"+item.ballID) && b.ballsBought)
			{
				item.buyButton.GetComponent<zBuyBall> ().btnText.text = PlayerPrefs.GetString ("BTNS"+item.ballID);
			}

			if (b.ballsBought == true) 
			{
				item.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/" + b.ballsSpriteName);
				item.ballPrice.text = "Bought";

				if (PlayerPrefs.HasKey ("BTNS" + item.ballID) == false) {
					item.buyButton.GetComponent<zBuyBall>().btnText.text="Selected";
				}

			} else 
			{
				item.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/" + b.ballsSpriteName+"_cinza");
			}
		}
	}

	public void UpdateSprite(int ball_ID){
		for(int i=0;i<supportBallsList.Count;i++){
			zBallSupport supportBallsScript = supportBallsList [i].GetComponent<zBallSupport> ();

			if(supportBallsScript.ballID == ball_ID){
				for (int j = 0; j < ballsList.Count; j++) {
					if (ballsList [j].ballsID == ball_ID) {
						if (ballsList [j].ballsBought == true) {
							supportBallsScript.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/" + ballsList [j].ballsSpriteName);
							supportBallsScript.ballPrice.text = "Bought";
							SaveBallsInfoShop (supportBallsScript.ballID);
						} else {
							supportBallsScript.ballSprite.sprite = Resources.Load<Sprite> ("Sprites/" + ballsList [j].ballsSpriteName+"_cinza");
						}
					}
				}
			}
		}
	}

	void SaveBallsInfoShop(int idBall){
		for (int i = 0; i < ballsList.Count; i++) {
			zBallSupport ballsSup = supportBallsList [i].GetComponent<zBallSupport> ();

			if (ballsSup.ballID == idBall) {
				PlayerPrefs.SetInt ("BTN"+ballsSup.ballID, ballsSup.buyButton ? 1:0);
			}
		}
	}

	public void SaveBallsButtonState(int idBall, string s){
		for(int i=0;i<ballsList.Count;i++){
			zBallSupport ballsSup = supportBallsList [i].GetComponent<zBallSupport> ();

			if (ballsSup.ballID == idBall) {
				PlayerPrefs.SetString ("BTNS"+ballsSup.ballID, s);
			}
		}
	}
}
