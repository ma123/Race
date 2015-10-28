using UnityEngine;
using System.Collections;

public class WorldSelectScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.LoadLevel("MainMenuScene"); 
		}
	}

	public void OpenGrasLandWorld(){
		print ("Open grassLand");
		Application.LoadLevel("World1"); //nacitanie sveta
	}

	// toto dalsie svety
}
