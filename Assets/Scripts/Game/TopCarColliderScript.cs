using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class TopCarColliderScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		print (coll.gameObject.tag);
		if((coll.gameObject.tag == "LineDraw")  || (coll.gameObject.tag == "Obstacle")) {
			print ("kolizia na streche");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
		}	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("DynamicObstacle")) {
			print ("kolizia na streche");
			GameObject vehicle = GameObject.Find("Player");
			vehicle.GetComponentInChildren<CarColliderMoveDetectScript>().DestroyCarAndWinnPanel();
		}
	}
}
