﻿using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	private Transform observingObject;
	private Vector3 pos;
	private Vector3 newPos;
	public float offSet = 8f;
	public int currentVehicle = 0;

	void Start() {
		currentVehicle = PlayerPrefs.GetInt ("selectedCar", 0);
		GameObject playerParent = GameObject.Find ("Player");
		Transform car = null;

		switch(currentVehicle) {
		case 0: 
			car = playerParent.transform.Find("PlayerSedanCar");
			car.gameObject.SetActive(true);
			observingObject = car.transform;

			break;
		case 1: 
			car = playerParent.transform.Find("PlayerSkodaRapidCar");
			car.gameObject.SetActive(true);
			observingObject = car.transform;
			break;

		case 2: 
			car = playerParent.transform.Find("PlayerArmyCar");
			car.gameObject.SetActive(true);
			observingObject = car.transform;
			break;

	    // TODO DALSIE AUTA 
		default: 
			break;
		}
	
	}
	
	void Update() {
		if (observingObject == null)
			return;
		
		pos = transform.position;
		newPos = observingObject.position;

		newPos.x = observingObject.position.x + offSet; // posun auta v kamere dozadu
		//newPos.y = pos.y;
		newPos.z = pos.z;
		
		transform.position = Vector3.Lerp(transform.position, newPos, 1f); // interpolacia starej pozicie kamery s novou
	}
}
