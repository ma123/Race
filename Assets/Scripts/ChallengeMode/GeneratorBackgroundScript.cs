using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GeneratorBackgroundScript : MonoBehaviour {
	public GameObject availableRooms;
	public List<GameObject> currentRooms;
	private float screenWidthInPoints;
	private GameObject playerObject;
	private List<GameObject> roomsToRemove;
	// object generator coin ink 
	public GameObject objectCoin;    
	public List<GameObject> objects;

	public float objectsMinDistance = 5.0f;    
	public float objectsMaxDistance = 10.0f;

	public float objectsMinY = -1.4f;
	public float objectsMaxY = 1.4f;

	//public float objectsMinRotation = -45.0f;
	//public float objectsMaxRotation = 45.0f; 

	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
		roomsToRemove = new List<GameObject>();
	}

	void Update () {
		playerObject = GameObject.FindGameObjectWithTag ("TypeOfPlayer");
		//GenerateRoomIfRequred();

		GenerateObjectsIfRequired();
	}

	void GenerateRoomIfRequred() {
		bool addRooms = true;       
		float playerX = playerObject.transform.position.x;
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

			if (roomEndX < removeRoomX - 20f) {  // magicke cislo 20
				roomsToRemove.Add (room);
			}
			farhtestRoomEndX = Mathf.Max(farhtestRoomEndX, roomEndX);
		}

		foreach(var room in roomsToRemove) {   // stale error hadze nechapem
			try {
				currentRooms.Remove(room);
				Destroy(room);
			} catch(Exception e) {
				Debug.Log("Destroy room problem" + e);
			}
		}

		if (addRooms) {
			AddRoom (farhtestRoomEndX);
		}
	}

	void AddRoom(float farhtestRoomEndX) {
			GameObject room = (GameObject)Instantiate(availableRooms);
			float roomWidth = room.transform.FindChild("DownColliderObject").localScale.x;
			float roomCenter = farhtestRoomEndX + roomWidth * 0.5f;
			room.transform.position = new Vector3(roomCenter, 0, 0);
			currentRooms.Add(room);
	} 

	void GenerateObjectsIfRequired() {
			float playerX = playerObject.transform.position.x;
			float removeObjectsX = playerX - screenWidthInPoints;
			float addObjectX = playerX + screenWidthInPoints;
			float farthestObjectX = 0;

			List<GameObject> objectsToRemove = new List<GameObject>();

			foreach (var obj in objects) {
				float objX = obj.transform.position.x;

				farthestObjectX = Mathf.Max(farthestObjectX, objX);

				if (objX < removeObjectsX) {            
					objectsToRemove.Add (obj);
				}
			}
				
			foreach (var obj in objectsToRemove) {
			   objects.Remove (obj);
			   Destroy(obj.gameObject);
			}

		print (" far " + farthestObjectX + " addObj " + addObjectX);
			
			if (farthestObjectX < addObjectX) {
				AddObject (farthestObjectX);
			}
	}

	void AddObject(float lastObjectX) {
		print ("last object " + lastObjectX);
		GameObject obj = (GameObject)Instantiate(objectCoin);
		float objectPositionX = lastObjectX + UnityEngine.Random.Range(objectsMinDistance, objectsMaxDistance);
		float randomY = UnityEngine.Random.Range(objectsMinY, objectsMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0); 
		//float rotation = Random.Range(objectsMinRotation, objectsMaxRotation);
		//obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
		objects.Add(obj);            
	}
}