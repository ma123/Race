using UnityEngine;
using System.Collections;

public class DynamicObstacleScript : MonoBehaviour {
	public bool horizontalMove = true;
	public float elevatorSpeed = 1.5f; 
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	private float elevatorDirection = 1.0f;
	private Vector2 elevatorAmount;
	private float originalX;
	private float originalY; 
	
	void Start () {
		if (horizontalMove) {
			this.originalX = this.transform.position.x;
		} else {
			this.originalY = this.transform.position.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (horizontalMove) {
			elevatorAmount.x = elevatorDirection * elevatorSpeed * Time.deltaTime;
			if (elevatorDirection > 0.0f && transform.position.x >= originalX + wallRight) {
				elevatorDirection = -1.0f;
			} else if (elevatorDirection < 0.0f && transform.position.x <= originalX - wallLeft) {
				elevatorDirection = 1.0f;
			}
			transform.Translate (elevatorAmount);
		} else {
			elevatorAmount.y = elevatorDirection * elevatorSpeed * Time.deltaTime;
			if (elevatorDirection > 0.0f && transform.position.y >= originalY + wallRight) {
				elevatorDirection = -1.0f;
			} else if (elevatorDirection < 0.0f && transform.position.y <= originalY - wallLeft) {
				elevatorDirection = 1.0f;
			}
			transform.Translate (elevatorAmount);
		}
	}
}
