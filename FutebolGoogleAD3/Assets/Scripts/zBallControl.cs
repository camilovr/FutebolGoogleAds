using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zBallControl : MonoBehaviour {

	//[SerializeField] private Transform posStart;


	public GameObject setaGo;

	public float zRotate;
	public bool freeRot = false;
	public bool freeShoot = false;

	//força
	private Rigidbody2D ball;
	public float force = 0;
	public GameObject seta2;

	//boundaries
	private Transform wallRight,wallLeft;
	//dead ball anim
	[SerializeField]
	private GameObject DeadBallAnim;

	private Collider2D touchCol;

	void Awake(){
		
		setaGo = GameObject.Find ("Seta");
		seta2 = setaGo.transform.GetChild (0).gameObject;
		setaGo.GetComponent<Image>().enabled=false;
		seta2.GetComponent<Image>().enabled=false;
		wallRight = GameObject.Find ("Boundary").GetComponent<Transform> ();
		wallLeft = GameObject.Find ("Boundary2").GetComponent<Transform> ();

	}

	void Start () {

		//posStart = GameObject.Find ("zStartPos").GetComponent<Transform> ();
		//PosicionaBola ();

		ball = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		RotacaoSeta ();
		InputRotacao();
		RotationLimits ();
		PosicionaSeta ();

		ForceControl ();
		ApplyForce ();

		Walls ();

	}
	void PosicionaSeta (){
		setaGo.GetComponent<Image>().rectTransform.position = transform.position;
	}

//	void PosicionaBola (){
//		this.gameObject.transform.position = posStart.position;
//	}

	void RotacaoSeta(){
		setaGo.GetComponent<Image>().rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
	}
	void InputRotacao(){
		//		if (Input.GetKey (KeyCode.UpArrow)) {
		//			zRotate += 2.5f;
		//		}
		//		if (Input.GetKey (KeyCode.DownArrow)) {
		//			zRotate -= 2.5f;
		//		}
		if(freeRot==true){

			float moveY=Input.GetAxis("Mouse Y");

			if(zRotate<90){
				if(moveY>0){
					zRotate +=2.5f;
				}
			}
			if (zRotate > 0) {
				if(moveY<0){
					zRotate -=2.5f;
				}
			}


		}
	}
	void RotationLimits(){
		if(zRotate>=90){
			zRotate = 90;
		}
		if(zRotate<=0){
			zRotate = 0;
		}
	}

	void OnMouseDown(){
		if (zGameManager.instance.shoot == 0) {
			freeRot = true;
			setaGo.GetComponent<Image>().enabled=true;
			seta2.GetComponent<Image>().enabled=true;

			touchCol = GameObject.FindGameObjectWithTag ("touch").GetComponent<Collider2D> ();
		}

	}
	void OnMouseUp(){
		freeRot = false;
		setaGo.GetComponent<Image>().enabled=false;
		seta2.GetComponent<Image>().enabled=false;

		if(zGameManager.instance.shoot == 0 && force>0){
			freeShoot = true;
			seta2.GetComponent<Image>().fillAmount=0;
			zAudioManager.instance.PlayFXsounds (1);
			zGameManager.instance.shoot = 1;
			touchCol.enabled = false;
		}

	}

	void ApplyForce(){
		float x=force*Mathf.Cos(zRotate*Mathf.Deg2Rad);
		float y=force*Mathf.Sin(zRotate*Mathf.Deg2Rad);
		//		if (Input.GetKeyUp (KeyCode.Space)) {
		//			ball.AddForce (new Vector2 (x,y));
		//		}
		if (freeShoot==true) {
			ball.AddForce (new Vector2 (x,y));
			freeShoot = false;
		}
	}
	void ForceControl(){
		if(freeRot==true){
			float moveX=Input.GetAxis("Mouse X");

			if(moveX<0){
				seta2.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
				force = seta2.GetComponent<Image>().fillAmount * 1000;
			}
			if(moveX>0){
				seta2.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
				force = seta2.GetComponent<Image>().fillAmount * 1000;
			}
		}
	}
	void DynamicBall(){
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	void Walls(){
		if (this.gameObject.transform.position.x > wallRight.position.x) {
			Destroy (this.gameObject);
			zGameManager.instance.ballsScene -= 1;
			zGameManager.instance.ballNum -= 1;
		}
		if (this.gameObject.transform.position.x < wallLeft.position.x) {
			Destroy (this.gameObject);
			zGameManager.instance.ballsScene -= 1;
			zGameManager.instance.ballNum -= 1;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Dead")) {
			Instantiate (DeadBallAnim,transform.position,Quaternion.identity);
			Destroy (this.gameObject);
			zGameManager.instance.ballsScene -= 1;
			zGameManager.instance.ballNum -= 1;
		}
		if (other.gameObject.CompareTag ("win")) {
			zGameManager.instance.win = true;
			int temp = zCurrentLevel.instance.level-2;
			temp++;
			PlayerPrefs.SetInt ("zLevel_"+temp,1);
		}
	}
}
