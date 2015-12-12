using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPanelScript : MonoBehaviour {
	public Toggle soundToggle;
	public Toggle musicToggle;
	public Toggle vibrationToggle;

	// Use this for initialization
	void Start () {
		print(soundToggle.isOn);
		print(musicToggle.isOn);
		print(vibrationToggle.isOn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
