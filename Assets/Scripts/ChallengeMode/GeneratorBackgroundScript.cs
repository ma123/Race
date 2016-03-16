using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GeneratorBackgroundScript : MonoBehaviour {
	private GameObject playerObject;
	private float playerX;
	// coin spawn
	public GameObject coinObject;    
	public float objectsCoinMinDistance = 5.0f;    
	public float objectsCoinMaxDistance = 10.0f;
	public float objectsCoinMinY = -14f;
	public float objectsCoinMaxY = 13f;
	public float coinMinTimeSpawn = 0;
	public float coinMaxTimeSpawn = 0;
	private float lastCoinTime = 0;
	//ink spawn
	public GameObject inkObject;    
	public float objectsInkMinDistance = 5.0f;    
	public float objectsInkMaxDistance = 10.0f;
	public float objectsInkMinY = -14f;
	public float objectsInkMaxY = 13f;
	public float inkMinTimeSpawn = 0;
	public float inkMaxTimeSpawn = 0;
	private float lastInkTime = 0;
	// gum spawn
	public GameObject gumObject;    
	public float objectsGumMinDistance = 5.0f;    
	public float objectsGumMaxDistance = 10.0f;
	public float objectsGumMinY = -14f;
	public float objectsGumMaxY = 13f;
	public float gumMinTimeSpawn = 0;
	public float gumMaxTimeSpawn = 0;
	private float lastGumTime = 0;
	//obstacle spawn
	public GameObject obstacleObject;    
	public float objectsObstacleMinDistance = 5.0f;    
	public float objectsObstacleMaxDistance = 10.0f;
	public float objectsObstacleMinY = -14f;
	public float objectsObstacleMaxY = 13f;
	public float obstacleMinTimeSpawn = 0;
	public float obstacleMaxTimeSpawn = 0;
	public float obstacleMinRotation = -45.0f;
	public float obstacleMaxRotation = 45.0f; 
	public float minXSize = 0.1f;
	public float maxXSize = 0.1f;
	public float minYSize = 0.1f;
	public float maxYSize = 0.1f;

	private float lastObstacleTime = 0;

	void FixedUpdate () {
		playerObject = GameObject.FindGameObjectWithTag ("TypeOfPlayer");
		playerX = playerObject.transform.position.x;  
		GenerateObjects ();
	}

	void GenerateObjects() {
		float waitCoinTime = UnityEngine.Random.Range(coinMinTimeSpawn, coinMaxTimeSpawn);
		if (Time.time > (waitCoinTime + lastCoinTime)) {
			CreateCoin ();
			lastCoinTime = Time.time;
		}    

		float waitInkTime = UnityEngine.Random.Range(inkMinTimeSpawn, inkMaxTimeSpawn);
		if (Time.time > (waitInkTime + lastInkTime)) {
			CreateInk ();
			lastInkTime = Time.time;
		}   

		float waitGumTime = UnityEngine.Random.Range(gumMinTimeSpawn, gumMaxTimeSpawn);
		if (Time.time > (waitGumTime + lastGumTime)) {
			CreateGum ();
			lastGumTime = Time.time;
		}   

		float waitObstacleTime = UnityEngine.Random.Range(obstacleMinTimeSpawn, obstacleMaxTimeSpawn);
		if (Time.time > (waitObstacleTime + lastObstacleTime)) {
			CreateObstacle ();
			lastObstacleTime = Time.time;
		}   
	}

	void CreateCoin() {
		GameObject obj = (GameObject)Instantiate(coinObject);
		float objectPositionX = (playerX + 15f) + UnityEngine.Random.Range(objectsCoinMinDistance, objectsCoinMaxDistance);
		float randomY = UnityEngine.Random.Range(objectsCoinMinY, objectsCoinMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0);   
	}

	void CreateInk() {
		GameObject obj = (GameObject)Instantiate(inkObject);
		float objectPositionX = (playerX + 15f) + UnityEngine.Random.Range(objectsCoinMinDistance, objectsInkMaxDistance);
		float randomY = UnityEngine.Random.Range(objectsCoinMinY, objectsInkMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0);   
	}

	void CreateGum() {
		GameObject obj = (GameObject)Instantiate(gumObject);
		float objectPositionX = (playerX + 15f) + UnityEngine.Random.Range(objectsGumMinDistance, objectsGumMaxDistance);
		float randomY = UnityEngine.Random.Range(objectsGumMinY, objectsGumMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0);   
	}

	void CreateObstacle() {
		GameObject obj = (GameObject)Instantiate(obstacleObject);
		float objectPositionX = (playerX + 15f) + UnityEngine.Random.Range(objectsObstacleMinDistance, objectsObstacleMaxDistance);
		float randomY = UnityEngine.Random.Range(objectsObstacleMinY, objectsObstacleMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0); 

		float rotation = UnityEngine.Random.Range(obstacleMinRotation, obstacleMaxRotation);
		obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
		float xSize = UnityEngine.Random.Range(minXSize, maxXSize);
		float ySize = UnityEngine.Random.Range(minYSize, maxYSize);
		obj.transform.localScale = new Vector3 (xSize, ySize, 0);
	}
}