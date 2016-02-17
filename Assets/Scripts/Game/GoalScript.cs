using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

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
	public int levelCoinToFull;
	private int moneyCount;

	void Start () {
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
		currentLevel = Application.loadedLevelName; // nacitanie mena aktualneho levela
	}

	public void GoalReact () {
		print ("destroy object Goal");
		PlayerPrefs.SetInt ("money", MoneyScript.GetMoney());
		ShowLevelCompletePanel ();
		Destroy (gameObject);
	}

	public void ShowLevelCompletePanel() {
		Time.timeScale = 0; // pauznutie hry
		statsPanel.SetActive(false);
		levelCompletePanel.SetActive(true);

		moneyCount = MoneyScript.GetMoneyCounter ();
		int coinPart = levelCoinToFull / 3;

		if (moneyCount == 0) {
			star0.GetComponent<Image> ().enabled = false;
			star1.GetComponent<Image> ().enabled = false;
			star2.GetComponent<Image> ().enabled = false;
			UnlockLevels (0);
		} else {
			if (moneyCount <= coinPart) {
				star0.GetComponent<Image> ().enabled = true;
				star1.GetComponent<Image> ().enabled = false;
				star2.GetComponent<Image> ().enabled = false;
				UnlockLevels (1);
			} else {
				if ((moneyCount > coinPart) && (moneyCount <= (2*coinPart))) {
					star0.GetComponent<Image> ().enabled = true;
					star1.GetComponent<Image> ().enabled = true;
					star2.GetComponent<Image> ().enabled = false;
					UnlockLevels (2);
				} else {
					if ((moneyCount > (2* coinPart)) && (moneyCount <= levelCoinToFull)) {
						star0.GetComponent<Image> ().enabled = true;
						star1.GetComponent<Image> ().enabled = true;
						star2.GetComponent<Image> ().enabled = true;
						UnlockLevels (3);
					}
				}
			}
		}
		MoneyScript.SetMoneyCounter (0);

		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().GetMusicBackgroundObject().Pause(); // pauznutie background hudby
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel");
		}
	}

	protected void UnlockLevels (int stars){
		for(int i = 1; i <= LockLevelScript.worlds; i++){
			for(int j = 1; j <= LockLevelScript.levels; j++){
				if(currentLevel == "Level"+ i.ToString() +"." +j.ToString()){
					if (j == LockLevelScript.levels) { // posledny level vo svete
						if (i != LockLevelScript.worlds) { // ak nie sme v poslednom svete 
							worldIndex = i + 1;
							levelIndex = 1;
							PlayerPrefs.SetInt ("level" + worldIndex.ToString () + ":" + levelIndex.ToString (), 1); // otvorenie prveho levelu v dalsom svete
							PlayerPrefs.SetInt ("world" + worldIndex.ToString(), 1); // otvorenie dalsieho sveta dlazdica
						}
					} else {
						worldIndex = i;
						levelIndex = (j + 1);
						PlayerPrefs.SetInt ("level" + worldIndex.ToString () + ":" + levelIndex.ToString (), 1);
					}
						
					if(PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +j.ToString()+"stars")< stars)
						PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +j.ToString()+"stars",stars);
				}
			}
		}
	}
}