using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour {

//	[SerializeField] private Transform posStart;
//
//	[SerializeField] private Image setaImg;
//	public GameObject setaGo;
//
//	public float zRotate;
//	public bool freeRot = false;
//	public bool freeShoot = false;


	// Use this for initialization
	void Start () {
		
//		PosicionaBola ();


	}
	
	// Update is called once per frame
	void Update () {

//		RotacaoSeta ();
//		InputRotacao();
//		RotationLimits ();
//		PosicionaSeta ();
	}

//	void PosicionaSeta (){
//		setaImg.rectTransform.position = transform.position;
//	}
//
//	void PosicionaBola (){
//		this.gameObject.transform.position = posStart.position;
//	}
//
//	void RotacaoSeta(){
//		setaImg.rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
//	}
//	void InputRotacao(){
////		if (Input.GetKey (KeyCode.UpArrow)) {
////			zRotate += 2.5f;
////		}
////		if (Input.GetKey (KeyCode.DownArrow)) {
////			zRotate -= 2.5f;
////		}
//		if(freeRot==true){
//			
//			float moveY=Input.GetAxis("Mouse Y");
//
//			if(zRotate<90){
//				if(moveY>0){
//					zRotate +=2.5f;
//				}
//			}
//			if (zRotate > 0) {
//				if(moveY<0){
//					zRotate -=2.5f;
//				}
//			}
//
//
//		}
//	}
//	void RotationLimits(){
//		if(zRotate>=90){
//			zRotate = 90;
//		}
//		if(zRotate<=0){
//			zRotate = 0;
//		}
//	}
//
//	void OnMouseDown(){
//		freeRot = true;
//		setaGo.SetActive (true);
//	}
//	void OnMouseUp(){
//		freeRot = false;
//		freeShoot = true;
//		setaGo.SetActive (false);
//		zAudioManager.instance.PlayFXsounds (1);
//	}
}
