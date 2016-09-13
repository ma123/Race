using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using System.Collections;
using System;
using GoogleMobileAds.Api;

public class ReactionChallengeScript : MonoBehaviour {
	public GameObject winPanel;
	public Text pickupCoinText;
	private GameObject soundsAndMusic;
	private int pickupCoin;
	private float timer;
	public Text mText;
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
			PausePanelReaction(false); // parameter pre pauzu
		}
	}

	public void PausePanelReaction(bool offBackBtn) {
		Time.timeScale = 0; // pauznutie hry
		winPanel.SetActive (true);

		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript> ().GetMusicBackgroundObject ().Pause (); // pauznutie background hudby
		} catch (Exception e) {
			Debug.Log ("Sound exception in panel" + e);
		}

		pickupCoin = MoneyScript.GetMoneyCounter ();  // ziskanie zozbieranych poctu minci 
		pickupCoinText.text = pickupCoin.ToString ();  // priradenie do panelu text

		timer = TimeChallengeScript.GetTime ();
		if(timer > PlayerPrefs.GetFloat("time",0)) {
			PlayerPrefs.SetFloat ("time", timer);	
		}
		 
		mText.text = System.Math.Round(timer,0).ToString ();  // priradenie do panelu text

		GameObject btnInteractableBack = GameObject.Find ("BackToGameBtn");
		if (offBackBtn) {
			btnInteractableBack.GetComponent<Button> ().interactable = false;
			MoneyScript.SetMoneyCounter (0);
		}
			
		adsNumber = PlayerPrefs.GetInt ("ads", 4);
		print (adsNumber);
		print (interstitial);
		if (adsNumber <= 0) {
			ShowInterstitial ();
			PlayerPrefs.SetInt ("ads", 4);
		} else {
			adsNumber -= 1;
			PlayerPrefs.SetInt ("ads", adsNumber);
		}
	}

	public void Restart() {
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
	}

	public void BackToLevelSelector() {
		SceneManager.LoadScene("MainMenuScene");
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
		string adUnitId = "ca-app-pub-1882232042439946/7715391512";  

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Load an interstitial ad.
		AdRequest requestInterstitial = new AdRequest.Builder().Build();
		interstitial.LoadAd(requestInterstitial);
	}

	private void ShowInterstitial() {
			if (interstitial.IsLoaded()) {
				interstitial.Show();
			}
			else {
				Debug.Log("Interstitial is not ready yet.");
			}
	}

	void OnDisable() {
		interstitial.Destroy();
	}
}
