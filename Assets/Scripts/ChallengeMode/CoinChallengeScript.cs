using UnityEngine;
using System.Collections;
using System;

public class CoinChallengeScript : MonoBehaviour {
	public int coinValue = 1;

	public void Start() {
		Destroy (gameObject, 20.0f);
		print ("Destroy");
	}

	public void CoinReact () {
		print ("destroy object coin");
		MoneyScript.AddScore(coinValue);
		try {
			Destroy (gameObject);
		} catch(Exception e) {
			Debug.Log ("Coin problem " + e);
		}
	}
}
