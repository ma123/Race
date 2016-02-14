using UnityEngine;
using System.Collections;

public class WorldSelectScript : MonoBehaviour {
	private int worldOpen;
	void Start () {
		worldOpen = PlayerPrefs.GetInt("world", 1);

		for(int j = 2; j <= LockLevelScript.worlds; j++) { // podla poctu levelov
			worldOpen = j;
			if(PlayerPrefs.GetInt("world"+ worldOpen.ToString())== 1) {
				GameObject.Find("LockWorld"+j).SetActive(false); // vypnutie tlacitka zo zamkom nad skutocnym tlacitkom
				Debug.Log ("Unlocked world");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.LoadLevel("MainMenuScene"); 
		}
	}

	public void ReturnToMainMenu() { 
		Application.LoadLevel("MainMenuScene"); 
	}

	public void OpenWorld(string worldName){
		print ("Open world" + worldName);
		Application.LoadLevel(worldName); //nacitanie sveta
	}
}
