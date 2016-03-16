﻿using UnityEngine;
using System.Collections;
using System;

public class CoinChallengeScript : MonoBehaviour {
	public byte coinValue = 1;

	public void Start() {
		Destroy (gameObject, 20.0f);
	}

	public void CoinReact () {
		MoneyScript.AddScore(coinValue);
		try {
			Destroy (gameObject);
		} catch(Exception e) {
			Debug.Log ("Coin problem " + e);
		}
	}
}
