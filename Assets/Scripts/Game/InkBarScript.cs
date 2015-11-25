using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InkBarScript : MonoBehaviour {
	private float inkStack = 100f;
	public GameObject inkBarPanel;
	
	// Use this for initialization
	void Start () {
		inkStack = 100f;
		RefreshInkBar ();
	}
	
	public void Hit(float removeInk) {
		inkStack -= removeInk;
		
		if(inkStack <= 0f) {
			inkStack = 0f;
		}
		
		RefreshInkBar ();
	}
	
	public void AddInk(float addedInk) {
		inkStack += addedInk;
		if(inkStack >= 100f) {
			inkStack = 100f;
		}
		
		RefreshInkBar ();
	}
	
	private void RefreshInkBar() {
		Scrollbar inkBar = inkBarPanel.GetComponent<Scrollbar> ();
		inkBar.size = inkStack / 100f;
	}
	
	public float GetInkStack() {
		return inkStack;
	}
	
	/*public void SetInkStack(float inkStack) {
		this.inkStack = inkStack;
	}*/
}
