using UnityEngine;
using System.Collections;

public class InkStackScript : MonoBehaviour {
	private float inkStack = 100f;
	private float initSize;
	private Transform transformHealth;
	
	// Use this for initialization
	void Start () {
		print (inkStack);
		transformHealth = transform;
		initSize = transformHealth.localScale.x;  // zisti pociatocnu velkost health baru
		RefreshHealthBar ();
	}
	
	public void Hit(float removeInk) {
		inkStack -= removeInk;
		
		if(inkStack <= 0f) {
			inkStack = 0f;
		}
		
		RefreshHealthBar ();
	}
	
	public void AddInk(int addedHealth) {
		inkStack += addedHealth;
		if(inkStack >= 100f) {
			inkStack = 100f;
		}
		
		RefreshHealthBar ();
	}
	
	private void RefreshHealthBar() {
		Vector3 scale = transformHealth.localScale;
		scale.x = (initSize / 100) * inkStack;
		transformHealth.localScale = scale;
	}

	public void SetInkStack(float inkStack) {
		this.inkStack = inkStack;
	}
}
