using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowCoinPanelScript : MonoBehaviour {
	private static int money = 0;
	private static Text moneyText;

	// Use this for initialization
	void Start () {
		money = PlayerPrefs.GetInt("money",0);
		moneyText = gameObject.GetComponent<Text>();
		RefreshScoreText ();
	}
	
	private static void RefreshScoreText() {
		moneyText.text = money.ToString();
	}
}
