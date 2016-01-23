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
		}
	}

	public void WinnPanelReaction(int reaction) {
		Time.timeScale = 0; // pauznutie hry
		winPanel.SetActive(true);
		GameObject btnInteractable = GameObject.Find("NextLvlBtn");
		GameObject btnInteractableBack = GameObject.Find("BackToGameBtn");

		switch(reaction) {
			case 1:    //esc
			    print("esc");
				btnInteractable.GetComponent<Button>().interactable = false;
			break;

			case 2:   //dead
			    print("dead");
				btnInteractable.GetComponent<Button>().interactable = false;
				btnInteractableBack.GetComponent<Button>().interactable = false;
			break;

		    case 3:  //winn
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
		string currentLevel = Application.loadedLevelName; // ziskam nazov levelu
		int worldNumber = int.Parse (currentLevel[5].ToString()); // ziskam cislo sveta
		string[] splitString = currentLevel.Split ('.');
		int levelNumber = int.Parse (splitString [1]); // ziskam cislo levelu

		if (levelNumber == LockLevelScript.levels) {  // ak sme v poslednom levele 
			if (worldNumber == LockLevelScript.worlds) { // ak sme v poslednom svete 
				Application.LoadLevel ("MainMenuScene");  // tak sa dostaneme do hlavneho menu
			} else {
				Application.LoadLevel ("Level" + (worldNumber + 1) + "." + "1");  // tak otvorime level 1 v dalsom svete
			}
		} else {
			Application.LoadLevel (splitString[0]+ "." + (levelNumber+1));
		}
		print (currentLevel);
	}
	
	public void Restart() {
		print ("restartLevel");
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void BackToLevelSelector() {
		print ("backLevelSelector");
		string currentLevel = Application.loadedLevelName;
		Application.LoadLevel ("World"+ currentLevel[5]); // ziskam svet v ktorom sa nachadzam a vratim sa do vyberu levelov
	}

	public void BackToGame() {
		print ("backToGame");
		Time.timeScale = 1; // spustenie hry
		winPanel.SetActive(false);
	}
}
