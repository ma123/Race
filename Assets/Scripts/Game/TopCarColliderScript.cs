using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class TopCarColliderScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll != null) {
			print ("kolizia na streche");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
		}	
	}

	/*void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			AudioSource.PlayClipAtPoint(pickupCoinClips, transform.position);
			coin.SendMessage ("CoinReact");
		}
	}*/
}
