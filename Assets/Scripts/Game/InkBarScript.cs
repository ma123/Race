using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InkBarScript : MonoBehaviour {
	private static float inkStack = 100f;
	public GameObject inkPanel;
	private static Scrollbar inkBar;
	
	// Use this for initialization
	void Start () {
		inkStack = 100f;
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
		inkBar = GameObject.GetComponent<Scrollbar> ();
		inkBar.size = inkStack / 100f;
	}
	
	public float GetInkStack() {
		return inkStack;
	}
	
	/*public static void SetInkStack(float inkStack) {
		this.inkStack = inkStack;
	}*/
}
