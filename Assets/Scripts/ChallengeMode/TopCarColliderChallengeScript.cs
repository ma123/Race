using UnityEngine;
using System.Collections;

public class TopCarColliderChallengeScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if((coll.gameObject.tag == "LineDraw")  || (coll.gameObject.tag == "Obstacle")) {
			print ("kolizia na streche");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<ChallengeMoveCarScript>().DestroyCarAndWinnPanel();
		}	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("DynamicObstacle")) {
			print ("kolizia na streche");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<ChallengeMoveCarScript>().DestroyCarAndWinnPanel();
		}
	}
}
