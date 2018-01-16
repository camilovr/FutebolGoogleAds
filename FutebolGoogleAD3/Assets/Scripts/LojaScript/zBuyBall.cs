using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zBuyBall : MonoBehaviour {

	public int ballsIDs;
	public Text btnText;

	private GameObject txtCoins;

	private Animator outOfMoney;

	public void BuyBallButton () {
		for (int i = 0; i < zBallsShop.instance.ballsList.Count; i++) {
			if (zBallsShop.instance.ballsList [i].ballsID == ballsIDs && !zBallsShop.instance.ballsList [i].ballsBought && PlayerPrefs.GetInt("coinsSave")>=zBallsShop.instance.ballsList[i].ballsPrice) {
				zBallsShop.instance.ballsList [i].ballsBought = true;
				UpdateBuyButton ();
				zScoreManager.instance.UseCoins (zBallsShop.instance.ballsList [i].ballsPrice);
				GameObject.Find ("CoinShop").GetComponent<Text> ().text = PlayerPrefs.GetInt ("coinsSave").ToString();

			} 
			//nao tem dinheiro
			else if (zBallsShop.instance.ballsList [i].ballsID == ballsIDs && !zBallsShop.instance.ballsList [i].ballsBought && PlayerPrefs.GetInt("coinsSave") < zBallsShop.instance.ballsList[i].ballsPrice)
			{
				print ("Falido!!!!");
				outOfMoney = GameObject.FindGameObjectWithTag ("OutOff").GetComponent<Animator>();
				outOfMoney.Play ("zOutOfMoney");
			}
			else if (zBallsShop.instance.ballsList [i].ballsID == ballsIDs && zBallsShop.instance.ballsList [i].ballsBought) 
			{
				UpdateBuyButton ();

			}
		}
		zBallsShop.instance.UpdateSprite (ballsIDs);
	}

	void UpdateBuyButton(){
		btnText.text = "Seleted";

		for (int i = 0; i<zBallsShop.instance.shopBtnList.Count; i++) {
			zBuyBall shopBallScript = zBallsShop.instance.shopBtnList [i].GetComponent<zBuyBall> ();

			for (int j=0;j<zBallsShop.instance.ballsList.Count;j++){

				if (zBallsShop.instance.ballsList[j].ballsID==shopBallScript.ballsIDs){
					zBallsShop.instance.SaveBallsButtonState (shopBallScript.ballsIDs,"Seleted");

					if(zBallsShop.instance.ballsList[j].ballsID==shopBallScript.ballsIDs && zBallsShop.instance.ballsList[j].ballsBought && zBallsShop.instance.ballsList[j].ballsID==ballsIDs)
					{
						zCurrentLevel.instance.ballSelected = shopBallScript.ballsIDs;
						PlayerPrefs.SetInt ("BallSelected", shopBallScript.ballsIDs);
					}

				}
				if(zBallsShop.instance.ballsList[j].ballsID==shopBallScript.ballsIDs && zBallsShop.instance.ballsList[j].ballsBought && zBallsShop.instance.ballsList[j].ballsID!=ballsIDs){
					shopBallScript.btnText.text = "Avaible";
					zBallsShop.instance.SaveBallsButtonState (shopBallScript.ballsIDs,"Avaible");
				}
			}
		}


	}
	public void OutOfMoneyBack(){
		outOfMoney = GameObject.FindGameObjectWithTag ("OutOff").GetComponent<Animator>();
		outOfMoney.Play ("zOutOfMoneyBack");
	}

}
