using UnityEngine;
using System;
using System.Collections;

public class SoundsAndMusicScript : MonoBehaviour {
	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;
	public AudioClip gumClips;
	public AudioClip noInkClips;
	public AudioClip inkClips;
	public AudioClip winClips;
	public AudioClip greenlandLoop;
	public AudioClip citylandLoop;
	public AudioClip dessertlandLoop;
	public AudioClip darkgreenlandLoop;
	public AudioClip snowlandLoop;

	//public AudioClip gravityReverseClips;
	private AudioSource sfxEffect;
	private AudioSource musicBackground;

	private int soundEnabled = 0;
	private int musicEnabled = 0;
	private int vibrationEnabled = 0;
	
	void Start() {
		soundEnabled = PlayerPrefs.GetInt("sound",0);
		musicEnabled = PlayerPrefs.GetInt("music",0);
		vibrationEnabled = PlayerPrefs.GetInt("vibration",0);

		if (musicEnabled == 1) {
			musicBackground = this.GetComponent<AudioSource> ();
			string currentLevel = Application.loadedLevelName;
			int numberWorld = ((int)currentLevel [5]) - 48; // konverzia z char na int odpocitame 48 ako rozdiel v ascii tabulke
			switch(numberWorld) {
			   case 1:
				musicBackground.clip = greenlandLoop;
				break;
			   case 2:
				musicBackground.clip = citylandLoop;
				break;
			   case 3:
				musicBackground.clip = dessertlandLoop;
				break;
			   case 4:
				musicBackground.clip = darkgreenlandLoop;
				break;
			   case 5:
				musicBackground.clip = snowlandLoop;
				break;
			   default:
				// default vetva no sounds
				break;
			}

			try {
				musicBackground.Play();
			}
			catch (Exception e) {
				print("sound problem");
			}  
		}
	}

	public void PickupCoinAudio(Transform transPos) {
		PhoneVibrate ();

		if(soundEnabled == 1) {
			print ("sound coin");
			try {
				AudioSource.PlayClipAtPoint(pickupCoinClips, transPos.position);
			}
			catch (Exception e) {
				print("no sound");
			}  
		}
	}

	public void ExplosionAudio(Transform transPos) {
		PhoneVibrate ();

		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (explosionClips, transPos.position);
			}
			catch (Exception e) {
				print("no sound");
			}  
		}
	}

	public void PickupGumAudio(Transform transPos) {
		PhoneVibrate ();

		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (gumClips, transPos.position);
			}
			catch (Exception e) {
				print("no sound");
			}  
		}
	}

	public void PickupInkAudio(Transform transPos) {
		PhoneVibrate ();

		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (inkClips, transPos.position);
			}
			catch (Exception e) {
				print("no sound");
			}  
		}
	}

	public void NoInkAudio(Transform transPos) {
		PhoneVibrate ();

		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (noInkClips, transPos.position);
			}
			catch (Exception e) {
				print("no sound");
			}  
		}
	}

	public void WinAudio(Transform transPos) {
		PhoneVibrate ();

		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (winClips, transPos.position);
			}
			catch (Exception e) {
				print("no sound");
			}  
		}
	}

	private void PhoneVibrate() {
		if(vibrationEnabled == 1) {
			try {
				Handheld.Vibrate();
			}
			catch (Exception e) {
				print("vibration problem");
			}  
		}
	}
}
