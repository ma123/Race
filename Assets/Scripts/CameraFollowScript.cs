using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public Transform observingObject;
	private Vector3 pos;
	private Vector3 newPos;
	public float offSet = 8f;
	
	void Update() {
		if (observingObject == null)
			return;
		
		pos = transform.position;
		newPos = observingObject.position;

		newPos.x = observingObject.position.x + offSet; // posun auta v kamere dozadu
		newPos.y = pos.y;
		newPos.z = pos.z;
		
		transform.position = Vector3.Lerp(transform.position, newPos, 1f); // interpolacia starej pozicie kamery s novou
	}
}
