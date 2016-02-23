using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using System.Collections;
using System;

public class ReactionChallengeScript : MonoBehaviour {
	public GameObject winPanel;
	private GameObject soundsAndMusic;

	void Start() {
		Time.timeScale = 1; // spustenie hry
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			PausePanelReaction(false); // parameter pre pauzu
		}
	}

	public void PausePanelReaction(bool offBackBtn) {
		Time.timeScale = 0; // pauznutie hry
		winPanel.SetActive(true);

		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().GetMusicBackgroundObject().Pause(); // pauznutie background hudby
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel");
		}

		GameObject btnInteractableBack = GameObject.Find("BackToGameBtn");
		if(offBackBtn) {
			print ("dead");
			btnInteractableBack.GetComponent<Button> ().interactable = false;
			MoneyScript.SetMoneyCounter (0);
		}
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
}
