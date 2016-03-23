using UnityEngine;
using System;
using System.Collections;

public class UISound : MonoBehaviour {
	public AudioClip clickClips;
	private int soundEnabled = 0;
	// Use this for initialization
	void Start () {
		soundEnabled = PlayerPrefs.GetInt("sound",0);
	}
	
	public void ClickAudio() {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (clickClips, this.transform.position);
			}
			catch (Exception e) {
				Debug.Log ("no sound" + e);
			}  
		}
	}

}
