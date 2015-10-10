using UnityEngine;
using System.Collections;

public class InkBottleScript : MonoBehaviour {
	public void InkBottleReact () {
		print ("destroy object inkbottle");
		InkStackScript.AddInk (20f);
		Destroy (gameObject);
	}
}
