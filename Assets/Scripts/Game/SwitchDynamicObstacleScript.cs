using UnityEngine;
using System.Collections;

public class SwitchDynamicObstacleScript : MonoBehaviour {
	private bool switchOn = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.GetComponent<Collider2D> ().CompareTag ("TopCarCollider")) {
			switchOn = true;
			print (true);
		}
	}

	public bool GetSwitchOn() {
		return switchOn;
	}
}
