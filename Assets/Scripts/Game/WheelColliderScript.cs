using UnityEngine;
using System.Collections;

public class WheelColliderScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "LineDraw") {
			print ("Colizia ciara pod kolesom prehra");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
		}
	}
}
