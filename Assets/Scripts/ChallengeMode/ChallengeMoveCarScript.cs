using UnityEngine;
using System.Collections;

public class ChallengeMoveCarScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	private GameObject soundsAndMusic;
	private float speed = 1f;
	private bool firstMeasure = false;
	private bool particleEnd = false;
	private bool isParticle = true;
	public GameObject particles;

	void Start() {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
		StartCoroutine(Wait());
	}


	void Update() {
		if(particleEnd) {
			PlayerPrefs.SetInt ("money", MoneyScript.GetMoney());  // ulozenie poctu coin do preferences
			reactionFromPanel.GetComponent<ReactionChallengeScript>().PausePanelReaction(true); // parameter 2 pre dead stav
			particleEnd = false;
		}

		if(firstMeasure) {  // prve meranie az po 2 sekundach funkcie Wait() 
			speed = (float) System.Math.Round(this.GetComponentInChildren<Rigidbody2D>().velocity.magnitude,2); // meranie rychlosti objektu + zaokruhlenie na dve desat miesta
			if(speed <= 0.015) {  // ak je rychlost mensia alebo rovna nule hrac prehrava 
				DestroyCarAndWinnPanel(); 
				firstMeasure = false;
			}
		}
	}

	// prejdu 2 sekundy nasledne sa firstMeasure zmeni na true
	IEnumerator Wait() { 
		yield return new WaitForSeconds(2);
		firstMeasure = true;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupCoinAudio(transform);
			coin.GetComponent<CoinChallengeScript> ().CoinReact ();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("InkBottle")) {
			GameObject inkBottle = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupInkAudio(transform);
			inkBottle.GetComponent<InkBottleCHallengeScript> ().InkBottleReact ();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Gum")) {
			GameObject gum = coll.GetComponent<Collider2D>().gameObject;
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupGumAudio(transform);
			gum.GetComponent<GumChallengeScript> ().GumReact ();
		}

	if(coll.GetComponent<Collider2D>().CompareTag("DownCollider")) {
		DestroyCarAndWinnPanel();
	}

	if(coll.GetComponent<Collider2D>().CompareTag("TopCollider")) {
		DestroyCarAndWinnPanel();
	}

	if(coll.GetComponent<Collider2D>().CompareTag("DynamicObstacle")) {
		DestroyCarAndWinnPanel();
	}
}

public void DestroyCarAndWinnPanel() {
	if(isParticle) {
		StartCoroutine(WaitParticle());

		GameObject vehicle = GameObject.Find ("Player");
		for(byte i = 0; i < 3; i++) {
				vehicle.GetComponentsInChildren<Rigidbody2D> () [i].bodyType = RigidbodyType2D.Static;
			//vehicle.GetComponentsInChildren<Rigidbody2D> ()[i].isKinematic = true;
			vehicle.GetComponentsInChildren<SpriteRenderer>()[i].enabled = false;
		}

		soundsAndMusic.GetComponent<SoundsAndMusicScript>().ExplosionAudio(transform);
		Instantiate(particles, transform.position, transform.rotation);
		isParticle = false;
	}
}

// prejdu 2 sekundy nasledne sa firstMeasure zmeni na true
IEnumerator WaitParticle() { 
	yield return new WaitForSeconds(2f);
	particleEnd = true;
}
}
