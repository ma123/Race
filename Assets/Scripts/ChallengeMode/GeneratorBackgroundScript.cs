using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorBackgroundScript : MonoBehaviour {
	public GameObject availableRooms;
	public List<GameObject> currentRooms;
	private float screenWidthInPoints;
	private GameObject playerObject;
	private float playerX;

	public GameObject coinObject;    
	public float objectsCoinMinDistance = 5.0f;    
	public float objectsCoinMaxDistance = 10.0f;
	public float objectsCoinMinY = -14f;
	public float objectsCoinMaxY = 13f;
	public float coinMinTimeSpawn = 0;
	public float coinMaxTimeSpawn = 0;
	private float lastCoinTime = 0;

	public GameObject inkObject;    
	public float objectsInkMinDistance = 5.0f;    
	public float objectsInkMaxDistance = 10.0f;
	public float objectsInkMinY = -14f;
	public float objectsInkMaxY = 13f;
	public float inkMinTimeSpawn = 0;
	public float inkMaxTimeSpawn = 0;
	private float lastInkTime = 0;

	public GameObject gumObject;    
	public float objectsGumMinDistance = 5.0f;    
	public float objectsGumMaxDistance = 10.0f;
	public float objectsGumMinY = -14f;
	public float objectsGumMaxY = 13f;
	public float gumMinTimeSpawn = 0;
	public float gumMaxTimeSpawn = 0;
	private float lastGumTime = 0;

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

	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}

	void FixedUpdate () {
		playerObject = GameObject.FindGameObjectWithTag ("TypeOfPlayer");
		playerX = playerObject.transform.position.x;  
		GenerateRoomIfRequred();
		GenerateObjects ();
	}

	void GenerateRoomIfRequred() {
		List<GameObject> roomsToRemove = new List<GameObject>();;
		bool addRooms = true;       
		float removeRoomX = playerX - screenWidthInPoints;   
		float addRoomX = playerX + screenWidthInPoints;
		float farhtestRoomEndX = 0;

		foreach(var room in currentRooms) {
			float roomWidth = room.transform.FindChild("DownColliderObject").localScale.x;
			float roomStartX = room.transform.position.x - (roomWidth * 0.5f);   
			float roomEndX = roomStartX + roomWidth;                            

			if (roomStartX > addRoomX) {
				addRooms = false;
			}

			if (roomEndX < (removeRoomX - 20f)) {  // magicke cislo 20
				roomsToRemove.Add (room);
			}
			farhtestRoomEndX = Mathf.Max(farhtestRoomEndX, roomEndX);
		}

		foreach(var room in roomsToRemove) {   // stale error hadze nechapem
			currentRooms.Remove(room);
			Destroy(room);	
		}

		if (addRooms) {
			AddRoom (farhtestRoomEndX);
		}
	}

	void AddRoom(float farhtestRoomEndX) {
		GameObject room = (GameObject) Instantiate(availableRooms);

		float roomWidth = room.transform.FindChild("DownColliderObject").localScale.x;
		float roomCenter = farhtestRoomEndX + roomWidth * 0.5f;
		room.transform.position = new Vector3(roomCenter, 0, 0);
		currentRooms.Add(room);
	} 

	void GenerateObjects() {
		float waitCoinTime = Random.Range(coinMinTimeSpawn, coinMaxTimeSpawn);
		if (Time.time > waitCoinTime + lastCoinTime) {
			CreateCoin ();
			lastCoinTime = Time.time;
		}    

		float waitInkTime = Random.Range(inkMinTimeSpawn, inkMaxTimeSpawn);
		if (Time.time > waitInkTime + lastInkTime) {
			CreateInk ();
			lastInkTime = Time.time;
		}   

		float waitGumTime = Random.Range(gumMinTimeSpawn, gumMaxTimeSpawn);
		if (Time.time > waitGumTime + lastGumTime) {
			CreateGum ();
			lastGumTime = Time.time;
		}   

		float waitObstacleTime = Random.Range(obstacleMinTimeSpawn, obstacleMaxTimeSpawn);
		if (Time.time > waitObstacleTime + lastObstacleTime) {
			CreateObstacle ();
			lastObstacleTime = Time.time;
		}   
	}

	void CreateCoin() {
		GameObject obj = (GameObject)Instantiate(coinObject);
		float playerPos = playerX + 10f;
		float objectPositionX = playerPos + Random.Range(objectsCoinMinDistance, objectsCoinMaxDistance);
		float randomY = Random.Range(objectsCoinMinY, objectsCoinMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0);   
	}

	void CreateInk() {
		GameObject obj = (GameObject)Instantiate(inkObject);
		float playerPos = playerX + 15f;
		float objectPositionX = playerPos + Random.Range(objectsCoinMinDistance, objectsInkMaxDistance);
		float randomY = Random.Range(objectsCoinMinY, objectsInkMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0);   
	}

	void CreateGum() {
		GameObject obj = (GameObject)Instantiate(gumObject);
		float playerPos = playerX + 15f;
		float objectPositionX = playerPos + Random.Range(objectsGumMinDistance, objectsGumMaxDistance);
		float randomY = Random.Range(objectsGumMinY, objectsGumMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0);   
	}

	void CreateObstacle() {
		GameObject obj = (GameObject)Instantiate(obstacleObject);
		float playerPos = playerX + 15f;
		float objectPositionX = playerPos + Random.Range(objectsObstacleMinDistance, objectsObstacleMaxDistance);
		float randomY = Random.Range(objectsObstacleMinY, objectsObstacleMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0); 

		float rotation = Random.Range(obstacleMinRotation, obstacleMaxRotation);
		obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
		float xSize = Random.Range(minXSize, maxXSize);
		float ySize = Random.Range(minYSize, maxYSize);
		obj.transform.localScale = new Vector3 (xSize, ySize, 0);
	}
}