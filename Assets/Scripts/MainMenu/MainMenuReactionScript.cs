using UnityEngine;
using UnityEngine.SceneManagement;
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
		SceneManager.LoadScene("SelectWorldScene");
		//Application.LoadLevel ("SelectWorldScene");
	}
	
	public void ClickedShop() {
		print ("clicked load Shop");
		SceneManager.LoadScene("ShopScene");
		//Application.LoadLevel ("ShopScene");
	}
	
	public void ClickedChallenge() {
		print ("clicked load Challenge");
		SceneManager.LoadScene("ChallengeScene");
		//Application.LoadLevel ("ChallengeScene");
	}

	public void ClickedSettings() {
		print ("clicked settings");
		ChangePanel(2);
	}

	public void OpenFacebookPage() {
		Application.OpenURL("https://www.facebook.com/atonomgames/?ref=aymt_homepage_panel");
	}
		
	public void OpenGooglePlayPage() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=sk.ag.drawingroad");
	}

	public void ClickedExit() {
		print ("clicked exit");
		Application.Quit ();
	}
}
