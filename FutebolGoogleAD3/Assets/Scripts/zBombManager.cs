﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zBombManager : MonoBehaviour {

	[SerializeField]
	private GameObject zBombFx;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Ball")) {
			Instantiate (zBombFx,new Vector2(this.transform.position.x,this.transform.position.y),Quaternion.identity);
		}
	}
}
