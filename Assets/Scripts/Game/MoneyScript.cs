using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
	private static int money = 0;
	private static int moneyCounter = 0;
	private static Text moneyText;
	
	void Start() {
		money = PlayerPrefs.GetInt("money",0);
		moneyText = gameObject.GetComponent<Text>();
		RefreshScoreText ();
	}
	
	private static void RefreshScoreText() {
		moneyText.text = money.ToString();
	}
	
	public static void AddScore(int gains) {
		money += gains;
		moneyCounter += gains;
		RefreshScoreText ();
	}
	
	public static void RemoveScore(int lost) {
		money -= lost;
		RefreshScoreText ();
	}
	
	public static int GetMoney() {
		return money;
	}

	public static int GetMoneyCounter() {
		return moneyCounter;
	}

	public static void SetMoneyCounter(int nullCounter) {
		moneyCounter = nullCounter;
	}
}
