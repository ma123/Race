using UnityEngine;
using System.Collections;

public class DynamicObstacleScript : MonoBehaviour {
	public float obstacleSpeed = 1.5f; 

	public Transform[] routPoints;
	private bool[] routPointsBool;

	void Start () {
		routPointsBool = new bool[routPoints.Length];
	    routPointsBool[0] = true;
		routPointsBool[1] = false;
		routPointsBool[2] = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(routPointsBool[0]) {
			if (transform.position == routPoints [0].position) {
				routPointsBool[0] = false;
				routPointsBool[1] = true;
			} else {
				transform.position = Vector2.MoveTowards(transform.position, routPoints[0].position, Time.deltaTime* obstacleSpeed);
			}
		}

		if(routPointsBool[1]) {
			if (transform.position == routPoints [1].position) {
				routPointsBool[1] = false;
				routPointsBool[2] = true;
			} else {
				transform.position = Vector2.MoveTowards(transform.position, routPoints[1].position, Time.deltaTime* obstacleSpeed);
			}
		}

		if(routPointsBool[2]) {
			if (transform.position == routPoints [2].position) {
				routPointsBool[2] = false;
				routPointsBool[0] = true;
			} else {
				transform.position = Vector2.MoveTowards(transform.position, routPoints[1].position, Time.deltaTime* obstacleSpeed);
			}
		}

	}
}
