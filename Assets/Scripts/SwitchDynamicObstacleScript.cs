using UnityEngine;
using System.Collections;

public class SwitchDynamicObstacleScript : MonoBehaviour {
	private bool switchOn = false;
	
	
	void OnTriggerEnter2D(Collider2D coll) {
		/*if (coll.GetComponent<Collider2D> ().CompareTag ("Player")) {
			switchOn = true;
			print (switchOn);
		}*/
	}
}
