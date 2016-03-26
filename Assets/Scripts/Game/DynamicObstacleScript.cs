using UnityEngine;
using System.Collections;

public class DynamicObstacleScript : MonoBehaviour {
	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 1.0f;
	private int currentPoint = 0;
	private float direction = 1.0f;
	private bool pathDirection = true;

	void Start() {
		transform.position = path [0].position;
	}

	void FixedUpdate() {
	  if(SwitchDynamicObstacleScript.GetSwitchOn()) { 
		float dist = Vector3.Distance (path[currentPoint].position, transform.position);
		transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

		if (pathDirection) {
			if (dist <= reachDist) {
				if (currentPoint < path.Length - 1) {
					currentPoint++;
				} else {
					pathDirection = false;
				}
			} 
		} else {
			if (dist <= reachDist) {
				if(currentPoint > 0) {
					currentPoint--;
				} else {
					pathDirection = true;
				}
			} 
		}

		if ((direction < 0.0f) && ((transform.position.x + 5) >= path[path.Length - 1].position.x)) {
			direction = 1.0f;
			Flip ();
		}

		if ((direction > 0.0f) && ((transform.position.x - 5) <= path [0].position.x)) {
			direction = -1.0f;
			Flip ();
		} 
	  }
	}

	private void Flip() {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
