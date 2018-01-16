using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zBombLife : MonoBehaviour {

	private GameObject motherBomb;



	void Start () {
		motherBomb = GameObject.Find ("TntBarrel");
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (LifeCycle());
	}
	IEnumerator LifeCycle(){
		yield return new WaitForSeconds (0.5f);
		Destroy (motherBomb.gameObject);
		Destroy (this.gameObject);
	}
}
