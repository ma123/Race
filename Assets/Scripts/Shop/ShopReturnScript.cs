using UnityEngine;
using System.Collections;

public class ShopReturnScript : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.LoadLevel("MainMenuScene");
		}
	}

	public void ReturnToMainMenu() {
		Application.LoadLevel("MainMenuScene");
	}
}
