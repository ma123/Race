using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class ReactionFromPanelScript : MonoBehaviour {
	public GameObject winPanel;

	void Start() {
		Time.timeScale = 1; // spustenie hry
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			WinnPanelReaction(1); // parameter pre pauzu

			/*Time.timeScale = 0; // pauznutie hry
			
			winPanel.SetActive(true);
			GameObject btnInteractable = GameObject.Find("NextLvlBtn");
			print (btnInteractable);
			btnInteractable.GetComponent<Button>().interactable = false;*/
		}
	}

	public void WinnPanelReaction(int reaction) {
		Time.timeScale = 0; // pauznutie hry
		winPanel.SetActive(true);
		GameObject btnInteractable = GameObject.Find("NextLvlBtn");
		GameObject btnInteractableBack = GameObject.Find("BackToGameBtn");

		switch(reaction) {
			case 1: 
				//esc
			print("esc");
				btnInteractable.GetComponent<Button>().interactable = false;
			break;

			case 2:
				//dead
			print("dead");
				btnInteractable.GetComponent<Button>().interactable = false;
				btnInteractableBack.GetComponent<Button>().interactable = false;
			break;

		    case 3:
				//winn
			print("winn");
				//btnInteractable.GetComponent<Button>().interactable = true;
				btnInteractableBack.GetComponent<Button>().interactable = false;
			break;
		default:
			Debug.Log ("Nieco sa zmrvilo");
			break;
		}
	}

	public void NextLevel() {
		print ("nextLevel");
		string currentLevel = Application.loadedLevelName;
		print (currentLevel);
	}
	
	public void Restart() {
		print ("restartLevel");
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void BackToLevelSelector() {
		print ("backLevelSelector");
		Application.LoadLevel ("World1");
	}

	public void BackToGame() {
		print ("backToGame");
		Time.timeScale = 1; // spustenie hry
		winPanel.SetActive(false);
	}
}
