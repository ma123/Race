using UnityEngine;
using System.Collections;

public class DynamicObstacleScript : MonoBehaviour {
	public bool horizontalMove = true;
	public float elevatorSpeed = 1.5f; 
	public float startX = 0.0f;       // Define wallLeft
	public float startY = 0.0f;       // Define wallLeft
	public float midlleX = 2.5f;      // Define wallRight
	public float midlleY = 2.5f;       // Define wallLeft
	public float endX = 5.0f;      // Define wallRight
	public float endY = 5.0f;       // Define wallLeft
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
			if (elevatorDirection > 0.0f && transform.position.x >= originalX + startX) {
				elevatorDirection = -1.0f;
			} else if (elevatorDirection < 0.0f && transform.position.x <= originalX - endX) {
				elevatorDirection = 1.0f;
			}
			transform.Translate (elevatorAmount);
		} else {
			elevatorAmount.y = elevatorDirection * elevatorSpeed * Time.deltaTime;
			if (elevatorDirection > 0.0f && transform.position.y >= originalY + startX) {
				elevatorDirection = -1.0f;
			} else if (elevatorDirection < 0.0f && transform.position.y <= originalY - endY) {
				elevatorDirection = 1.0f;
			}
			transform.Translate (elevatorAmount);
		}
	}
}
