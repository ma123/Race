using UnityEngine;
using System.Collections;

public class WheelDistanceScript : MonoBehaviour {
	private float anchorY;
	private GameObject soundsAndMusic;

	void Start() {
		anchorY = GameObject.Find ("Player").GetComponentsInChildren<WheelJoint2D> () [0].anchor.y;
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
	}

	// Update is called once per frame
	void Update () {
		if(this.transform.localPosition.y < anchorY) {
			this.transform.localPosition = new Vector3(this.transform.localPosition.x,anchorY,0);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupCoinAudio(transform);
			coin.SendMessage ("CoinReact");
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("InkBottle")) {
			GameObject inkBottle = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupInkAudio(transform);
			inkBottle.SendMessage ("InkBottleReact");
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("Gum")) {
			GameObject gum = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupGumAudio(transform);
			gum.SendMessage ("GumReact");
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("Goal")) {
			GameObject goal = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().WinAudio(transform);
			goal.SendMessage ("GoalReact");
		}
	}
}
