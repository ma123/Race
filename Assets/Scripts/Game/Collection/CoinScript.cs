using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	public void CoinReact () {
		print ("destroy object coin");
		MoneyScript.AddScore(20);
		Destroy (gameObject);
	}
}
