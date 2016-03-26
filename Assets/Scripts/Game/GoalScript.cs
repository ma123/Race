using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;

public class GoalScript : MonoBehaviour {
	private GameObject soundsAndMusic;
	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;
	public GameObject statsPanel;
	public GameObject levelCompletePanel;
	public GameObject star0;
	public GameObject star1;
	public GameObject star2;
	public Sprite fullStar;
	public Sprite emptyStar;
	public Text pickupCoinText;
	public float levelCoinToFull;
	private int moneyCount;
	//private InterstitialAd interstitial;
	//private bool showIntersticial = true;

	void Start () {
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
		currentLevel = SceneManager.GetActiveScene().name;
		//RequestInterstitial ();
	}

	public void GoalReact () {
		PlayerPrefs.SetInt ("money", MoneyScript.GetMoney());
		ShowLevelCompletePanel ();
		Destroy (gameObject);
	}

	public void ShowLevelCompletePanel() {
		Time.timeScale = 0; // pauznutie hry
		statsPanel.SetActive(false);
		levelCompletePanel.SetActive(true);

		moneyCount = MoneyScript.GetMoneyCounter (); // ziskany pocet minci
		float percent = (100 * (float)moneyCount) / levelCoinToFull; // ziskame pocet percent na kolko sme presli
		pickupCoinText.text = moneyCount.ToString ();

		if (percent <= 30.0f) {
			star0.GetComponent<Image> ().overrideSprite = emptyStar;
			star1.GetComponent<Image> ().overrideSprite = emptyStar;
			star2.GetComponent<Image> ().overrideSprite = emptyStar;
			UnlockLevels (0);
		} else {
			if ((percent > 30.0f) && (percent <= 50.0f)) {
				star0.GetComponent<Image> ().overrideSprite = fullStar;
				star1.GetComponent<Image> ().overrideSprite = emptyStar;
				star2.GetComponent<Image> ().overrideSprite = emptyStar;
				UnlockLevels (1);
			} else {
				if ((percent > 50.0f) && (percent <= 90.0f)) {
					star0.GetComponent<Image> ().overrideSprite = fullStar;
					star1.GetComponent<Image> ().overrideSprite = fullStar;
					star2.GetComponent<Image> ().overrideSprite = emptyStar;
					UnlockLevels (2);
				} else {
					if (percent > 90.0f) {  // pokial mame 90 percent tak vsetky hviezdy sa zobrazia ak mame viac ako 100 percent cize chybne nastaveny level tak tiez sa vsetky zobrazia
						star0.GetComponent<Image> ().overrideSprite = fullStar;
						star1.GetComponent<Image> ().overrideSprite = fullStar;
						star2.GetComponent<Image> ().overrideSprite = fullStar;
						UnlockLevels (3);
					}
				}
			}
		}
		MoneyScript.SetMoneyCounter (0);

		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().GetMusicBackgroundObject().Pause(); // pauznutie background hudby
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel" + e);
		}

		/*if(showIntersticial) { // ak je true zobrazi reklamu
			ShowInterstitial ();
		}*/
	}

	protected void UnlockLevels (int stars){
		for(int i = 1; i <= LockLevelScript.worlds; i++){
			for(int j = 1; j <= LockLevelScript.levels; j++){
				if(currentLevel == "Level"+ i.ToString() +"." +j.ToString()) {
					if (j == LockLevelScript.levels) { // posledny level vo svete
						worldIndex = i + 1;
						levelIndex = 1;
						PlayerPrefs.SetInt ("level" + worldIndex.ToString () + ":" + levelIndex.ToString (), 1); // otvorenie prveho levelu v dalsom svete
						PlayerPrefs.SetInt ("world" + worldIndex.ToString (), 1); // otvorenie dalsieho sveta dlazdica

						if (PlayerPrefs.GetInt ("level" + i.ToString () + ":" + j.ToString () + "stars", 0) < stars) {
							PlayerPrefs.SetInt ("level" + i.ToString () + ":" + j.ToString () + "stars", stars);
						}
					} else {
						worldIndex = i;
						levelIndex = (j + 1);
						PlayerPrefs.SetInt ("level" + worldIndex.ToString () + ":" + levelIndex.ToString (), 1);
						if (PlayerPrefs.GetInt ("level" + i.ToString () + ":" + j.ToString () + "stars", 0) < stars) {
							PlayerPrefs.SetInt ("level" + i.ToString () + ":" + j.ToString () + "stars", stars);
						}
					}
				}
			}
		}
	}

	/*private void RequestInterstitial() {
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-1882232042439946/9404594317";  
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
		showIntersticial = false;
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest() {
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
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
	#endregion*/
}