using UnityEngine;
using System.Collections;

public class InkStackScript : MonoBehaviour {
	private static float inkStack = 100f;
	private static float initSize;
	private static Transform transformHealth;
	
	// Use this for initialization
	void Start () {
		inkStack = 100f;
		transformHealth = transform;
		initSize = transformHealth.localScale.x;  // zisti pociatocnu velkost health baru
		RefreshInkBar ();
	}
	
	public static void Hit(float removeInk) {
		inkStack -= removeInk;
		
		if(inkStack <= 0f) {
			inkStack = 0f;
		}
		
		RefreshInkBar ();
	}
	
	public static void AddInk(float addedInk) {
		inkStack += addedInk;
		if(inkStack >= 100f) {
			inkStack = 100f;
		}
		
		RefreshInkBar ();
	}
	
	private static void RefreshInkBar() {
		Vector3 scale = transformHealth.localScale;
		scale.x = (initSize / 100) * inkStack;
		transformHealth.localScale = scale;
	}

	public static float GetInkStack() {
		return inkStack;
	}

	/*public static void SetInkStack(float inkStack) {
		this.inkStack = inkStack;
	}*/
}
