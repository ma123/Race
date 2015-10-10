using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {
	private Rigidbody2D rigidBodyCar;
	public float maxSpeed = 7f; // max rychlost ktoru moze ziskat hrac na osi x
	public float moveSpeed = 3f;

	// Use this for initialization
	void Start () {
		rigidBodyCar = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigidBodyCar.velocity = new Vector2 (moveSpeed * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	}
}