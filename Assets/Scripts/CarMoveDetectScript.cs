using UnityEngine;
using System;
using System.Collections;

public class CarMoveDetectScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	private float speed;
	private Vector3 lastPosition;

	void Start() {
		lastPosition = Vector3.zero;
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
	}


	void Update() {
		speed = this.GetComponent<Rigidbody2D>().velocity.magnitude;

		if(System.Math.Round(speed,2) <= 0) {
			reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(2); // parameter 2 pre dead stav 
		}
	}
}
