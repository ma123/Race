using UnityEngine;
using System.Collections;
using System;

public class CoinScript : MonoBehaviour {
	public byte coinValue = 1;

	public void CoinReact () {
		MoneyScript.AddScore(coinValue);
		try {
			Destroy (gameObject);
		} catch(Exception e) {
			Debug.Log ("Coin problem " + e);
		}
	}
}
