using UnityEngine;
using System.Collections;

public class MainMenuReactionScript : MonoBehaviour {
	public GameObject[] panels;
	private int currentPanelIndex;

	void Start () {
		currentPanelIndex = 0;
		//PlayerPrefs.DeleteAll ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			ChangePanel(1);
		}
	}

	public void ChangePanel(int panelIndex) {
		panels [currentPanelIndex].SetActive (false);
		currentPanelIndex = panelIndex;
		panels [currentPanelIndex].SetActive (true);
	}

	public void ClickedLevelSelector() {
		print ("clicked load SelectWorldScene");
		Application.LoadLevel ("SelectWorldScene");
	}
	
	public void ClickedShop() {
		print ("clicked load Shop");
		Application.LoadLevel ("ShopScene");
	}
	
	public void ClickedChallenge() {
		print ("clicked load Challenge");
		Application.LoadLevel ("ChallengeScene");
	}
	
	public void ClickedExit() {
		print ("clicked exit");
		Application.Quit ();
	}
}
