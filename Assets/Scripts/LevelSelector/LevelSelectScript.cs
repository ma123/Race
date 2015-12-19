using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelSelectScript : MonoBehaviour {
	private int worldIndex;   
	private int levelIndex;  
	public int selectedBackround = 1;
	
	public GameObject levelLoadingPanel;
	private int loadProgress;

	void Start (){
		PlayerPrefs.SetInt ("background", selectedBackround);
		//loop thorugh all the worlds
		for (int i = 1; i <= LockLevelScript.worlds; i++) {
			if (Application.loadedLevelName == "World" + i) {
				worldIndex = i;
				CheckLockedLevels (); 
			}
		}

		//levelLoadingPanel.SetActive (false);
	}
	
	public void  Update (){
		// po stlaceni esc poprípade back na telefone navrat do SelectWorld sceny
  		if (Input.GetKeyDown(KeyCode.Escape) ){
   			Application.LoadLevel("SelectWorldScene");
  		}
 	}

	public void ReturnToSelectWorld() {
		Application.LoadLevel("SelectWorldScene");
	}
	
	//vybranie levelu podla argumentu worldLevel ktory je zadany v editore napr. 1.1, 2.6
	public void Selectlevel(string worldLevel){
		print ("Level loaded " + worldLevel);
		StartCoroutine (DisplayLevelLoadingScreen(worldLevel));
	}


	
	//zistenie ktory level je odomknuty a zobrazenie bez zamku
	void  CheckLockedLevels (){
		for(int j = 1; j < LockLevelScript.levels; j++){ // podla poctu levelov
			levelIndex = (j+1);
			if((PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString()))==1){
				GameObject.Find("Level"+(j+1)+"Lock").SetActive(false); // vypnutie tlacitka zo zamkom nad skutocnym tlacitkom
				Debug.Log ("Unlocked");
			}
		}
	}

	// asynchronne nacitanie sceny
	IEnumerator DisplayLevelLoadingScreen(string worldLevel) {
		AsyncOperation async = Application.LoadLevelAsync ("Level"+worldLevel);
		levelLoadingPanel.SetActive (true);
		Scrollbar progressBar = levelLoadingPanel.GetComponentInChildren<Scrollbar> ();

		while(!async.isDone) {
			loadProgress = (int)(async.progress * 100) + 10;
			progressBar.size = loadProgress / 100f;
			yield return null;
		}
	}
}



