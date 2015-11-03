using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	public int coinValue = 1;
	public void CoinReact () {
		print ("destroy object coin");
		MoneyScript.AddScore(coinValue);
		Destroy (gameObject);
	}
}
