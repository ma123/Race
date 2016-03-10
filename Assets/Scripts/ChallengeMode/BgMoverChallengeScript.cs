using UnityEngine;
using System.Collections;

public class BgMoverChallengeScript : MonoBehaviour {
	private int count = 3;

	void Move() {
		print ("Background collision");
		Bounds b = GetComponent<SpriteRenderer>().bounds;
		float sizeX = b.size.x;
		Vector2 pos = transform.position;
		pos.x += count * sizeX;
		transform.position = pos;
	}
}
