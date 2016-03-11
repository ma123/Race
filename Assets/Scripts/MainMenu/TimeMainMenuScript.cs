using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeMainMenuScript : MonoBehaviour {
	private float time = 0;
	private static Text mText;

	void Start() {
		time = PlayerPrefs.GetFloat("time",0);
		mText = gameObject.GetComponent<Text>();
		mText.text = System.Math.Round(time,0).ToString ();
	}
}
