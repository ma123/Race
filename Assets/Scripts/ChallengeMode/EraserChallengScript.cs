﻿using UnityEngine;
using System.Collections;

public class EraserChallengScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		/*if (col.CompareTag ("Stalag")) {
			if (col != null)
				Destroy (col.gameObject);
		}*/

		if(col.CompareTag("Background")) {
			col.SendMessage("Move");
		}
	}
}