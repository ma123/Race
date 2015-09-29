﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
	private static int money = 0;
	private static Text moneyText;
	
	void Start() {
		money = PlayerPrefs.GetInt("money",0);
		moneyText = gameObject.GetComponent<Text>();
		RefreshScoreText ();
	}
	
	private static void RefreshScoreText() {
		moneyText.text = money + " €";
	}
	
	public static void AddScore(int gains) {
		money += gains;
		RefreshScoreText ();
	}
	
	public static void RemoveScore(int lost) {
		money -= lost;
		RefreshScoreText ();
	}
	
	public static int GetMoney() {
		return money;
	}
}
