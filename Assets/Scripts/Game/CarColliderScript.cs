using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class CarColliderScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;

	void Start() {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			AudioSource.PlayClipAtPoint(pickupCoinClips, transform.position);
			coin.SendMessage ("CoinReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("InkBottle")) {
			GameObject inkBottle = coll.GetComponent<Collider2D>().gameObject;
			//AudioSource.PlayClipAtPoint(pickupCoinClips, transform.position);
			inkBottle.SendMessage ("InkBottleReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Gum")) {
			GameObject gum = coll.GetComponent<Collider2D>().gameObject;
			//AudioSource.PlayClipAtPoint(pickupCoinClips, transform.position);
			gum.SendMessage ("GumReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Goal")) {
			GameObject goal = coll.GetComponent<Collider2D>().gameObject;
			//AudioSource.PlayClipAtPoint(pickupCoinClips, transform.position);
			goal.SendMessage ("GoalReact");
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("DownCollider")) {
			print ("down collider");
			AudioSource.PlayClipAtPoint(explosionClips, transform.position);
			reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
		}

		if(coll.GetComponent<Collider2D>().CompareTag("TopCollider")) {
			print ("top collider");
			AudioSource.PlayClipAtPoint(explosionClips, transform.position);
			reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
		}
	}
}
