using UnityEngine;
using System.Collections;

public class InkBottleCHallengeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20.0f);
	}

	public void InkBottleReact () {
		GameObject inkBarObject = GameObject.FindGameObjectWithTag ("InkBarReact");
		inkBarObject.GetComponent<InkBarScript>().AddInk(40f);
		Destroy (gameObject);
	}
}
