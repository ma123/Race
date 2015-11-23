using UnityEngine;
using System.Collections;

public class WheelDistanceScript : MonoBehaviour {
	private float anchorY;
	void Start() {
		anchorY = GameObject.Find ("Player").GetComponentsInChildren<WheelJoint2D> () [0].anchor.y;
	}

	// Update is called once per frame
	void Update () {
		if(this.transform.localPosition.y < anchorY) {
			this.transform.localPosition = new Vector3(this.transform.localPosition.x,anchorY,0);
		}
	}
}
