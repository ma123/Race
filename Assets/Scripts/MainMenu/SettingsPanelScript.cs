using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPanelScript : MonoBehaviour {
	public Toggle soundToggle;
	public Toggle musicToggle;
	public Toggle vibrationToggle;
	private int soundInt = 0;
	private int musicInt = 0;
	private int vibrationInt = 0;

	// Use this for initialization
	void Start () {
		soundInt = PlayerPrefs.GetInt("sound",0);
		musicInt = PlayerPrefs.GetInt("music",0);
		vibrationInt = PlayerPrefs.GetInt("vibration",0);
		print (soundInt + " " + musicInt + " " + vibrationInt);

		if (soundInt == 0) {
			soundToggle.isOn = false;
		} else {
			soundToggle.isOn = true;
		}

		if (musicInt == 0) {
			musicToggle.isOn = false;
		} else {
			musicToggle.isOn = true;
		}

		if (vibrationInt == 0) {
			vibrationToggle.isOn = false;
		} else {
			vibrationToggle.isOn = true;
		}
	}

	public void ClickSoundEnabled() {
		if (soundToggle.isOn) {
			PlayerPrefs.SetInt ("sound", 1);
		} else {
			PlayerPrefs.SetInt ("sound", 0);
		}
	}

	public void ClickMusicEnabled() {
		if (musicToggle.isOn) {
			PlayerPrefs.SetInt ("music", 1);
		} else {
			PlayerPrefs.SetInt ("music", 0);
		}
	}

	public void ClickVibrationEnabled() {
		if (vibrationToggle.isOn) {
			PlayerPrefs.SetInt ("vibration", 1);
		} else {
			PlayerPrefs.SetInt ("vibration", 0);
		}
	}
}
