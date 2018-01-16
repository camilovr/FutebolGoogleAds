using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zLevelManager : MonoBehaviour {


	[System.Serializable]
	public class zLevel{
		public string levelText;
		public bool avaible;
		public int unlocked;
		public bool txtActive;
	}

	public GameObject button;
	public Transform localBtn;
	public List<zLevel> levelList;

	void ListAdd()
		{
		foreach(zLevel level in levelList)
		{
			GameObject btnNew = Instantiate (button) as GameObject;
			zLevelButton newButton = btnNew.GetComponent<zLevelButton> ();
			newButton.levelTxtBtn.text = level.levelText;

//			newButton.unlockedBtn = level.unlocked;
//			newButton.GetComponent<Button> ().interactable = level.avaible;

			if(PlayerPrefs.GetInt("zLevel_"+newButton.levelTxtBtn.text)==1){
				level.unlocked = 1;
				level.avaible = true;
				level.txtActive = true;
			}
			newButton.unlockedBtn = level.unlocked;
			newButton.GetComponent<Button> ().interactable = level.avaible;
			newButton.GetComponentInChildren<Text> ().enabled= level.txtActive;
			newButton.GetComponent<Button> ().onClick.AddListener (()=>ClickLevel("zLevel_"+newButton.levelTxtBtn.text));

			btnNew.transform.SetParent (localBtn,false);
		}
	}

	void Awake(){
		Destroy (GameObject.Find("zUIManager(Clone)"));
		Destroy (GameObject.Find("zGameManager(Clone)"));
	}

	void ClickLevel(string level){
		SceneManager.LoadScene (level);
	
	}
	void Start () {
		//PlayerPrefs.DeleteAll ();
		ListAdd ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
