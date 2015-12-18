using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectBackgroundScript : MonoBehaviour {
	private int selectedBackground = 1;
	public Image[] images; 
	void Start () {
		selectedBackground = PlayerPrefs.GetInt ("background", 1);
		switch(selectedBackground) {
		case 1:
			//this.GetComponent<Image>();
			break;
		case 2:
			break;

	    // todo dalsie pozadia
		default:
			print ("nieco sa zoslonilo");
			break;
		}
	}	
	
	// Update is called once per frame
	void Update () {
	
	}
}
