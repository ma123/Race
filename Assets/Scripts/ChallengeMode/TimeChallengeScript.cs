using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TimeChallengeScript : MonoBehaviour {
	public static float timer = 0;
	private Text moneyText;

	// Use this for initialization
	void Start () {
		moneyText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		moneyText.text = System.Math.Round(timer,0).ToString();
	}

	public static float GetTime() {
		return timer;
	}
}
