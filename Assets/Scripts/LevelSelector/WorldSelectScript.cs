using UnityEngine;
using System.Collections;

public class WorldSelectScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.LoadLevel("MainMenuScene"); 
		}
	}

	public void OpenWorld(string worldName){
		print ("Open world" + worldName);
		Application.LoadLevel(worldName); //nacitanie sveta
	}
}
