using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zFXballDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DeadFX());
	}
	

	IEnumerator DeadFX(){
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);

	}
}
