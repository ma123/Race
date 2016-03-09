using UnityEngine;
using System.Collections;

public class DestroyAfterTimeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 15.0f);
	}
}
