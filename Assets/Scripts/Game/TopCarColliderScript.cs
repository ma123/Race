using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class TopCarColliderScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	public AudioClip explosionClips;

	void Start() {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll != null) {
			print ("kolizia na streche");
			AudioSource.PlayClipAtPoint(explosionClips, transform.position);
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
			//reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
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
