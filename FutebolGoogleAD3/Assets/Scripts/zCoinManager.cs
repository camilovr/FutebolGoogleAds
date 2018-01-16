using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zCoinManager : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Ball")) {
			zScoreManager.instance.CollectCoins (10);
			zAudioManager.instance.PlayFXsounds (0);
			Destroy (this.gameObject);
		}
	}
}
