using UnityEngine;
using System;
using System.Collections;

public class CarColliderMoveDetectScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	private float speed = 0f;
	//private bool firstMeasure = true;

	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;

	void Start() {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
		animation = GetComponent<Animation> ();
	}


	void Update() {
		if(Time.timeScale == 1) {
			/*if(firstMeasure) { 
				print ("first");
				//StartCoroutine(Wait());
				//firstMeasure = false;
			} else {*/
				//print (speed);
				speed = (float) System.Math.Round(this.GetComponent<Rigidbody2D>().velocity.magnitude,2); // meranie rychlosti objektu + zaokruhlenie na dve desat miesta

				if(speed <= 0.0) {
					print ("ides pomaly asda");
					//reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
				}
			//}
		}
	}

	/*IEnumerator Wait() {
		print(Time.time);
		yield return new WaitForSeconds(3);
		print(Time.time);
	}*/
	

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
			DestroyCarAndWinnPanel();
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("TopCollider")) {
			print ("top collider");
			DestroyCarAndWinnPanel();
		}
	}
	
	public void DestroyCarAndWinnPanel() {
		//DestroyObject(GameObject.Find("Player"));
		AudioSource.PlayClipAtPoint(explosionClips, transform.position);
		reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
	}
}
