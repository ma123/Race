using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using System.Collections;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class ReactionChallengeScript : MonoBehaviour {
	public GameObject winPanel;
	public Text pickupCoinText;
	private GameObject soundsAndMusic;
	private int pickupCoin;
	private InterstitialAd interstitial;

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
			Debug.Log ("Sound exception in panel");
		}

		pickupCoin = MoneyScript.GetMoneyCounter ();  // ziskanie zozbieranych poctu minci 
		pickupCoinText.text = pickupCoin.ToString ();  // priradenie do panelu text

		GameObject btnInteractableBack = GameObject.Find ("BackToGameBtn");
		if (offBackBtn) {
			print ("dead");
			btnInteractableBack.GetComponent<Button> ().interactable = false;
			MoneyScript.SetMoneyCounter (0);
		}

		ShowInterstitial ();
	}

	public void Restart() {
		print ("restartLevel");
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
	}

	public void BackToLevelSelector() {
		print ("backMainMenu");
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("MainMenuScene");
	}

	public void BackToGame() {
		print ("backToGame");
		Time.timeScale = 1; // spustenie hry
		winPanel.SetActive(false);
		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript> ().GetMusicBackgroundObject().Play (); // znovu spustenie hudby pozadia
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel");
		}
	}

	private void RequestInterstitial() {
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-1882232042439946/7715391512";  
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
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

		#region Interstitial callback handlers
		public void HandleInterstitialLoaded(object sender, EventArgs args) {
		print("HandleInterstitialLoaded event received.");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args) {
		print("HandleInterstitialOpened event received");
		}

		void HandleInterstitialClosing(object sender, EventArgs args) {
		print("HandleInterstitialClosing event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args) {
		print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args) {
		print("HandleInterstitialLeftApplication event received");
		}
		#endregion
}
