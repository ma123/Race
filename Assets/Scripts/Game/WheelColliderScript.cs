using UnityEngine;
using System.Collections;

public class WheelColliderScript : MonoBehaviour {
	//private GameObject reactionFromPanel;
	void Start() {
	//	reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "EdgeColl") {
			print ("Colizia ciara pod kolesom prehra");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
			//reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
		}
	}
}
