using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {
	public Transform[] background;
	public float[] parallaxScale;
	public float smoothing;
	private Vector3 previousCameraPosition;

	// Use this for initialization
	void Start () {
		previousCameraPosition = transform.position;
		parallaxScale = new float[background.Length];

		for(int i = 0; i < parallaxScale.Length; i++) {
			parallaxScale [i] = background [i].position.z * -1;
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < background.Length; i++) {
			Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScale[i] / smoothing);
			background [i].position = new Vector3 (background[i].position.x + parallax.x, background[i].position.y + parallax.y, background[i].position.z);
		}

		previousCameraPosition = transform.position;
	}
}
