using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using System.Collections;
using System;
using GoogleMobileAds.Api;

public class ReactionFromPanelScript : MonoBehaviour {
	public GameObject winPanel;
	private GameObject soundsAndMusic;
	private InterstitialAd interstitial;
	private int adsNumber;

	void Start() {
		Time.timeScale = 1; // spustenie hry
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
		RequestInterstitial ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			PausePanelReaction(1); // parameter pre pauzu
		}
	}

	public void PausePanelReaction(int reaction) {
		Time.timeScale = 0; // pauznutie hry
		winPanel.SetActive(true);

		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().GetMusicBackgroundObject().Pause(); // pauznutie background hudby
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel" + e);
		}

		GameObject btnInteractable = GameObject.Find("NextLvlBtn");
		GameObject btnInteractableBack = GameObject.Find("BackToGameBtn");

		switch(reaction) {
			case 1:    //esc
				btnInteractable.GetComponent<Button>().interactable = false;
			break;

			case 2:   //dead
				btnInteractable.GetComponent<Button> ().interactable = false;
				btnInteractableBack.GetComponent<Button> ().interactable = false;
				MoneyScript.SetMoneyCounter (0);
				break;
		default:
			Debug.Log ("Nieco sa zmrvilo");
			break;
		}
			
		adsNumber = PlayerPrefs.GetInt ("ads", 4);
		if (adsNumber <= 0) {
			ShowInterstitial ();
			PlayerPrefs.SetInt ("ads", 4);
		} else {
			adsNumber -= 1;
			PlayerPrefs.SetInt ("ads", adsNumber);
		}
	}

	public void NextLevel() {
		print ("nextLevel");
		string currentLevel = SceneManager.GetActiveScene().name; // ziskam nazov levelu
		int worldNumber = int.Parse (currentLevel[5].ToString()); // ziskam cislo sveta
		string[] splitString = currentLevel.Split ('.');
		int levelNumber = int.Parse (splitString [1]); // ziskam cislo levelu

		if (levelNumber == LockLevelScript.levels) {  // ak sme v poslednom levele 
			if (worldNumber == LockLevelScript.worlds) { // ak sme v poslednom svete 
				SceneManager.LoadScene("MainMenuScene");
			} else {
				SceneManager.LoadScene("Level" + (worldNumber + 1) + "." + "1");
			}
		} else {
			SceneManager.LoadScene(splitString[0]+ "." + (levelNumber+1),LoadSceneMode.Single);
		}
	}
	
	public void Restart() {
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
	}
	
	public void BackToLevelSelector() {
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("World" + sceneName[5],LoadSceneMode.Single);
	}

	public void BackToGame() {
		Time.timeScale = 1; // spustenie hry
		winPanel.SetActive(false);
		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript> ().GetMusicBackgroundObject().Play (); // znovu spustenie hudby pozadia
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel" + e);
		}
	}

	private void RequestInterstitial() {
		string adUnitId = "ca-app-pub-1882232042439946/6451127916";  

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		AdRequest requestInterstitial = new AdRequest.Builder().Build();
		interstitial.LoadAd(requestInterstitial);
	}

	private void ShowInterstitial() {
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
		else {
			print("Interstitial is not ready yet.");
		}
	}

	void OnDisable() {
		interstitial.Destroy();
	}
}
