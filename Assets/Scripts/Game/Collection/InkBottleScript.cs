using UnityEngine;
using System.Collections;

public class InkBottleScript : MonoBehaviour {
	public void InkBottleReact () {
		GameObject inkBarObject = GameObject.FindGameObjectWithTag ("InkBarReact");
		inkBarObject.GetComponent<InkBarScript>().AddInk(40f);
		Destroy (gameObject);
	}
}
