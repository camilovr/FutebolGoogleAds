using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zCameraFollow : MonoBehaviour {

	[SerializeField]
	private Transform objLeft, objRigh, ball;

	private float t=1;


	void Update () {

		if(zGameManager.instance.gameStarted==true){
			if (transform.position.x != objLeft.position.x) {
				t -= .08f * Time.deltaTime;
				transform.position = new Vector3 (Mathf.SmoothStep(objLeft.position.x,Camera.main.transform.position.x,t),
					this.transform.position.y,this.transform.position.z);
			}
			if (ball == null && zGameManager.instance.ballsScene > 0) {
				ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform> ();
			} else if (zGameManager.instance.ballsScene > 0) {
				Vector3 posCam = transform.position;
				posCam.x = ball.position.x;
				posCam.x = Mathf.Clamp (posCam.x, objLeft.position.x, objRigh.position.x);
				transform.position = posCam;
			}
		}


	}
}
