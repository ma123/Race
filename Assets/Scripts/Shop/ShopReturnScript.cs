using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShopReturnScript : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			SceneManager.LoadScene("MainMenuScene");
		}
	}

	public void ReturnToMainMenu() {
		SceneManager.LoadScene("MainMenuScene");
	}
}
