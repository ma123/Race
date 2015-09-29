using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public Transform observingObject;
	
	void Update()
	{
		if (observingObject == null)
			return;
		
		Vector3 pos = transform.position;
		Vector3 newPos = observingObject.position;
		
		newPos.y = pos.y;
		newPos.z = pos.z;
		
		transform.position = Vector3.Lerp(transform.position, newPos, 1f);
	}
}
