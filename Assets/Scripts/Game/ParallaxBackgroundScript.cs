using UnityEngine;
using System.Collections;

public class ParallaxBackgroundScript : MonoBehaviour {
	public Transform[] background;
	public float parallaxScale;
	public float parallaxReductionFactor;
	public float smoothing;
	private Vector2 lastPosition;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var parallax = (lastPosition.x - transform.position.x) * parallaxScale;

		for (int i = 0; i < background.Length; i++) {
			var backgroundTargetPosition = background[i].position.x + parallax * (i * parallaxReductionFactor + 1);
			background[i].position = Vector2.Lerp(background[i].position,
			                                      new Vector2(backgroundTargetPosition, background[i].position.y),
			                                      smoothing * Time.deltaTime);
		}
		lastPosition = transform.position;
	}
}
