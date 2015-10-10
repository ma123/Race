using UnityEngine;
using System.Collections;

public class GumScript : MonoBehaviour {
	public void GumReact () {
		print ("destroy object gum");
		InkStackScript.Hit (30f);
		Destroy (gameObject);
	}
}
