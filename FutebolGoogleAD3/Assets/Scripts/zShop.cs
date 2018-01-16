using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zShop : MonoBehaviour {


	public void GoShop () {
		SceneManager.LoadScene (2);
	}

	public void Exit(){
		Application.Quit ();
	}

	public void ShowADs ()
	{
		SceneManager.LoadScene (7);
	}


}
