using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuReactionScript : MonoBehaviour {
	public GameObject[] panels;
	private int currentPanelIndex;
	private int loadProgress;

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
		SceneManager.LoadScene("SelectWorldScene");
	}
	
	public void ClickedShop() {
		SceneManager.LoadScene("ShopScene");
	}
	
	public void ClickedChallenge() {
		StartCoroutine (DisplayLevelLoadingScreen());
	}

	// asynchronne nacitanie sceny
	IEnumerator DisplayLevelLoadingScreen() {
		AsyncOperation async = 	SceneManager.LoadSceneAsync("ChallengeScene");//Application.LoadLevelAsync ("Level"+worldLevel);
		panels[3].SetActive (true);
		Scrollbar progressBar = panels[3].GetComponentInChildren<Scrollbar> ();

		while(!async.isDone) {
			loadProgress = (int)(async.progress * 100) + 10;
			progressBar.size = loadProgress / 100f;
			yield return null;
		}
	}

	public void ClickedSettings() {
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
