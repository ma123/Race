using UnityEngine;
using System;
using System.Collections;

public class CarColliderMoveDetectScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	private float speed = 1f;
	private bool firstMeasure = false;
	private bool particleEnd = false;
	public GameObject particles;

	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;

	void Start() {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
		StartCoroutine(Wait());
	}


	void Update() {
		if(firstMeasure) {  // prve meranie az po 2 sekundach funkcie Wait() 
			speed = (float) System.Math.Round(this.GetComponent<Rigidbody2D>().velocity.magnitude,2); // meranie rychlosti objektu + zaokruhlenie na dve desat miesta
			if(speed <= 0.0) {  // ak je rychlost mensia alebo rovna nule hrac prehrava 
				print ("ides pomaly");
				DestroyCarAndWinnPanel(); 
			}
		}

		if(particleEnd) {
			reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav
		}

		/*if ((GameObject.Find ("LeftWheel").transform.localPosition.y <= -1.37f) && (GameObject.Find ("RightWheel").transform.localPosition.y <= -1.37f)) {
			GameObject.Find ("LeftWheel").transform.localPosition = new Vector3(GameObject.Find ("LeftWheel").transform.localPosition.x, -1.37f, 0);
			GameObject.Find ("RightWheel").transform.localPosition = new Vector3(GameObject.Find ("RightWheel").transform.localPosition.x, -1.37f, 0); // 
		}*/
		//print(GameObject.Find ("Player").GetComponentInChildren<WheelJoint2D>().motor.motorSpeed);
		// podla transform karoserie auta a polohz kolies vzpocitat nejaku medyu kde sa kolesa nesmu dostat uz
		// ak sa tam dostanu tak sa nepohnu uy dalej
	}

	// prejdu 2 sekundy nasledne sa firstMeasure zmeni na true
	IEnumerator Wait() { 
		yield return new WaitForSeconds(2);
		firstMeasure = true;
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
			DestroyCarAndWinnPanel();
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("TopCollider")) {
			print ("top collider");
			DestroyCarAndWinnPanel();
		}
	}



	public void DestroyCarAndWinnPanel() {
		StartCoroutine(WaitParticle());

		//GameObject.Find ("Player").SetActive(false);
		GameObject vehicle = GameObject.Find ("Player");
		for(int i = 0; i < 3; i++) {
			vehicle.GetComponentsInChildren<Rigidbody2D> ()[i].velocity = Vector2.zero;
			vehicle.GetComponentsInChildren<Rigidbody2D> () [i].gravityScale = 0f;
			vehicle.GetComponentsInChildren<SpriteRenderer>()[i].enabled = false;
		}

		AudioSource.PlayClipAtPoint(explosionClips, transform.position);
		Instantiate(particles, transform.position, transform.rotation);
	}

	// prejdu 2 sekundy nasledne sa firstMeasure zmeni na true
	IEnumerator WaitParticle() { 
		yield return new WaitForSeconds(2f);
		particleEnd = true;
	}
}