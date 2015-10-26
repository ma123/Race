using UnityEngine;
using System;
using System.Collections;

public class CarMoveDetectScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	private float speed = 0f;
	private bool firstMeasure = true;

	void Start() {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
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
}
