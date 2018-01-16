using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoMenuIniciar : MonoBehaviour {

	private Animator barraAnim;
	private bool sobe;


	void Start(){
		
	}

	public void Jogar()
	{
		SceneManager.LoadScene (1);
	}

	public void AnimaMenu()
	{
		barraAnim = GameObject.FindGameObjectWithTag ("SettingsBar").GetComponent<Animator> ();

		if(sobe == false)
		{
			barraAnim.Play ("zRollSettings");
			sobe = true;
		}
		else
		{
			barraAnim.Play ("zRollSettingsDown");
			sobe = false;
		}



	}
}
