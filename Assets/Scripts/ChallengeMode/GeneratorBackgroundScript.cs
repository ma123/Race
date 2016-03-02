using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GeneratorBackgroundScript : MonoBehaviour {
	public GameObject availableRooms;
	public List<GameObject> currentRooms;
	private float screenWidthInPoints;

	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
		print (screenWidthInPoints + " camera ");
	}

	void Update () {
		GenerateRoomIfRequred();
	}

	void GenerateRoomIfRequred()
	{
		List<GameObject> roomsToRemove = new List<GameObject>();
		bool addRooms = true;       
		float playerX = transform.position.x;
		print (playerX + " playerX ");
		float removeRoomX = playerX - screenWidthInPoints;   
		print (removeRoomX + " playerX - camera ");
		float addRoomX = playerX + screenWidthInPoints;
		print (addRoomX + " playerX + camera ");
		float farhtestRoomEndX = 0;

		foreach(var room in currentRooms)
		{
			float roomWidth = room.transform.FindChild("DownColliderObject").localScale.x;
			print (roomWidth + "sirka collideru");
			float roomStartX = room.transform.position.x - (roomWidth * 0.5f);   
			print (roomStartX + "sirka collideru");
			float roomEndX = roomStartX + roomWidth;                            

			if (roomStartX > addRoomX) {
				addRooms = false;
			}

			if (roomEndX < removeRoomX) {
				roomsToRemove.Add (room);
			}
			print (farhtestRoomEndX + " max " + roomEndX);
			farhtestRoomEndX = Mathf.Max(farhtestRoomEndX, roomEndX);
			print (farhtestRoomEndX);
		}

		foreach(var room in roomsToRemove)
		{
			currentRooms.Remove(room);
			Destroy(room);            
		}

		if (addRooms) {
			AddRoom (farhtestRoomEndX);
		}
	}

	void AddRoom(float farhtestRoomEndX) {
		try {
			GameObject room = (GameObject)Instantiate(availableRooms);
			float roomWidth = room.transform.FindChild("DownColliderObject").localScale.x;
			float roomCenter = farhtestRoomEndX + roomWidth * 0.5f;
			room.transform.position = new Vector3(roomCenter, 0, 0);

			currentRooms.Add(room);
		} catch(Exception e) {
			Debug.Log ("GameObject exception");
		}
	} 


}