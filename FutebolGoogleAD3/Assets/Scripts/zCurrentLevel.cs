using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zCurrentLevel : MonoBehaviour {

	public int level= -1;
	[SerializeField]
	private GameObject UIManagerGO, GameManagerGO;

	public static zCurrentLevel instance;

	public int ballSelected;

	private float orthoSize=5;
	[SerializeField]
	private float aspect=1.66f;


	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
		SceneManager.sceneLoaded += CheckLevel;
		ballSelected = PlayerPrefs.GetInt ("BallSelected");
	}

	void CheckLevel(Scene scene, LoadSceneMode mode){
		level = SceneManager.GetActiveScene ().buildIndex;
		if (level != 1 && level!=2 && level!=0) {
			Instantiate (UIManagerGO);
			Instantiate (GameManagerGO);
			Camera.main.projectionMatrix = Matrix4x4.Ortho (-orthoSize*aspect, orthoSize*aspect,-orthoSize,orthoSize,Camera.main.nearClipPlane,Camera.main.farClipPlane);
		}
	}
}
