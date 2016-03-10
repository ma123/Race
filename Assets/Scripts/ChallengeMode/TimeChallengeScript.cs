using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TimeChallengeScript : MonoBehaviour {
	public static float challengeTime = 0;
	private static Text moneyText;

	// Use this for initialization
	void Start () {
		challengeTime = 0;
		moneyText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		challengeTime = Time.deltaTime;
		moneyText.text = challengeTime.ToString();
	}
}
