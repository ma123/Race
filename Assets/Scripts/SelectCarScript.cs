using UnityEngine;
using System.Collections;

public class SelectCarScript : MonoBehaviour {
	private int currentVehicle = 1;
	// Use this for initialization
	void Start () {
		GameObject.Find ("PlayerArmyCar").SetActive(true);
		switch(currentVehicle) {
		case 1: 

			break;
		case 2: 
			//observingObject = GameObject.Find("PlayerSedanCar").transform;
			break;
		default: 
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
