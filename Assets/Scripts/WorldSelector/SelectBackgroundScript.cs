using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectBackgroundScript : MonoBehaviour {
	private int selectedBackground = 1;
	public Sprite[] images; 
	void Start () {
		selectedBackground = PlayerPrefs.GetInt ("background", 1);
		switch(selectedBackground) {
		case 1:
			// greenland background
		    this.GetComponent<Image>().overrideSprite = images[0];
			break;
		case 2:
			// city background
			this.GetComponent<Image>().overrideSprite = images[1];
			break;
		case 3:
			// dessert background
			this.GetComponent<Image>().overrideSprite = images[2];
			break;
		case 4:
			// dark greenland background
			this.GetComponent<Image>().overrideSprite = images[3];
			break;
		case 5:
			// snowland background
			this.GetComponent<Image>().overrideSprite = images[4];
			break;

	    // todo dalsie pozadia
		default:
			print ("nieco sa zoslonilo");
			break;
		}
	}	
}
