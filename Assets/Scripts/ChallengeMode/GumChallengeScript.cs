using UnityEngine;
using System.Collections;

public class GumChallengeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20.0f);
	}
	
	public void GumReact () {
		GameObject inkBarObject = GameObject.FindGameObjectWithTag ("InkBarReact");
		inkBarObject.GetComponent<InkBarScript>().Hit (30f);
		Destroy (gameObject);
	}
}
