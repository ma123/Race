﻿using UnityEngine;
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
			Time.timeScale = 0; // pauznutie hry

			winPanel.SetActive(true);
			GameObject btnInteractable = GameObject.Find("NextLvlBtn");
			btnInteractable.GetComponent<Button>().interactable = false;
		}
	}

	public void NextLevel() {
		print ("nextLevel");
		//int currentLevel = (PlayerPrefs.GetInt ("currentLevel") + 1);
		//Application.LoadLevel ("Lvl" + currentLevel);
		//PlayerPrefs.SetInt("currentLevel", currentLevel);
	}
	
	public void Restart() {
		print ("restartLevel");
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void BackToLevelSelector() {
		print ("backLevelSelector");
		Application.LoadLevel ("MainMenuScene");
	}

	public void BackToGame() {
		print ("backToGame");
		Time.timeScale = 1; // spustenie hry
		winPanel.SetActive(false);
	}
}
