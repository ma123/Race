using UnityEngine;
using System;
using System.Collections;

public class CarColliderMoveDetectScript : MonoBehaviour {
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
			reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav
			particleEnd = false;
		}

		if(firstMeasure) {  // prve meranie az po 2 sekundach funkcie Wait() 
			speed = (float) System.Math.Round(this.GetComponentInChildren<Rigidbody2D>().velocity.magnitude,2); // meranie rychlosti objektu + zaokruhlenie na dve desat miesta
			//print (speed);
			if(speed <= 0.01) {  // ak je rychlost mensia alebo rovna nule hrac prehrava 
				print ("ides pomaly");
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
			coin.SendMessage ("CoinReact");
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("InkBottle")) {
			GameObject inkBottle = coll.GetComponent<Collider2D>().gameObject;
			//soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupCoinAudio(transform);
			inkBottle.SendMessage ("InkBottleReact");
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("Gum")) {
			GameObject gum = coll.GetComponent<Collider2D>().gameObject;
			//soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupCoinAudio(transform);
			gum.SendMessage ("GumReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("ReverseGravity")) {
			GameObject reverse = coll.GetComponent<Collider2D>().gameObject;
			Destroy(reverse);

			this.transform.Rotate(180.0f, 0, 0);
			GameObject.FindWithTag("CarCollider").transform.Rotate(180.0f, 0, 0);;

			//this.GetComponent<Rigidbody2D>().gravityScale = -1.0f;

			Rigidbody2D[] rigid =  this.GetComponentsInChildren<Rigidbody2D>();
			for(int i = 0; i < rigid.Length; i++) {
				rigid[i].gravityScale = -rigid[i].gravityScale;
			}

			WheelJoint2D[] wheelJoint = this.GetComponents<WheelJoint2D>();
			for(int i = 0; i < wheelJoint.Length; i++) {
				wheelJoint[i].anchor = new Vector2(wheelJoint[i].anchor.x, -wheelJoint[i].anchor.y);  // zmena anchor na opacne

				JointMotor2D m = wheelJoint[i].motor; // zmena rychlosti na opacnu
				m.motorSpeed = -wheelJoint[i].motor.motorSpeed;
				wheelJoint[i].motor = m;
			}
			//soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupCoinAudio(transform);
		}
		
		if(coll.GetComponent<Collider2D>().CompareTag("Goal")) {
			GameObject goal = coll.GetComponent<Collider2D>().gameObject;
			//soundsAndMusic.GetComponent<SoundsAndMusicScript>().PickupCoinAudio(transform);
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

		if(coll.GetComponent<Collider2D>().CompareTag("DynamicObstacle")) {
			print ("dynamic obstacle");
			DestroyCarAndWinnPanel();
		}
	}

	public void DestroyCarAndWinnPanel() {
		if(isParticle) {
			StartCoroutine(WaitParticle());

			GameObject vehicle = GameObject.Find ("Player");
			for(int i = 0; i < 3; i++) {
				vehicle.GetComponentsInChildren<Rigidbody2D> ()[i].isKinematic = true;
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