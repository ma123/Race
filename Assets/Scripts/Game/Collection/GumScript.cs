using UnityEngine;
using System.Collections;

public class GumScript : MonoBehaviour {
	public void GumReact () {
		GameObject inkBarObject = GameObject.FindGameObjectWithTag ("InkBarReact");
	    inkBarObject.GetComponent<InkBarScript>().Hit (30f);
		Destroy (gameObject);
	}
}
