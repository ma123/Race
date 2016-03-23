using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WorldSelectScript : MonoBehaviour {
	private int worldOpen;
	void Start () {
		worldOpen = PlayerPrefs.GetInt("world", 1);

		for(int j = 2; j <= LockLevelScript.worlds; j++) { // podla poctu levelov
			worldOpen = j;
			if(PlayerPrefs.GetInt("world"+ worldOpen.ToString())== 1) {
				GameObject.Find("LockWorld"+j).SetActive(false); // vypnutie tlacitka zo zamkom nad skutocnym tlacitkom
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			SceneManager.LoadScene("MainMenuScene");
		}
	}

	public void ReturnToMainMenu() { 
		SceneManager.LoadScene("MainMenuScene");
	}

	public void OpenWorld(string worldName){
		SceneManager.LoadScene(worldName);
	}
}
