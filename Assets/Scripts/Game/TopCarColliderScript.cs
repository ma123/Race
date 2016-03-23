using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class TopCarColliderScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if((coll.gameObject.tag == "LineDraw")  || (coll.gameObject.tag == "Obstacle")) {
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
		}	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("DynamicObstacle")) {
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
		}
	}
}
