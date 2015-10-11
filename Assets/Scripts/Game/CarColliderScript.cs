using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class CarColliderScript : MonoBehaviour {
	public GameObject winPanel;
	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;

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
			Time.timeScale = 0; // pauznutie hry
			winPanel.SetActive(true);
			GameObject btnInteractable = GameObject.Find("NextLvlBtn");
			btnInteractable.GetComponent<Button>().interactable = false;
			GameObject btnInteractableBack = GameObject.Find("BackToGameBtn");
			btnInteractableBack.GetComponent<Button>().interactable = false;
		}
	}
}
