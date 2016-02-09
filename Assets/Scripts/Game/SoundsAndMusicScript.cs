using UnityEngine;
using System;
using System.Collections;

public class SoundsAndMusicScript : MonoBehaviour {
	// sound effect
	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;
	public AudioClip gumClips;
	public AudioClip noInkClips;
	public AudioClip inkClips;
	public AudioClip winClips;
	// intro melody
	public AudioClip landIntro;
	// loop melody
	public AudioClip landLoop;

	//public AudioClip gravityReverseClips;
	//private AudioSource sfxEffect;
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
			StartCoroutine(PlayBackgroundMusic());
		}
	}

	IEnumerator PlayBackgroundMusic() {
		musicBackground.clip = landIntro;  // priradi intro melodiu  
		musicBackground.Play();  
		yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
		musicBackground.clip = landLoop; // priradi loop melodiu
		musicBackground.Play();
	}

	public AudioSource GetMusicBackgroundObject() {
		return musicBackground;
	}

	public void PickupCoinAudio(Transform transPos) {
		PhoneVibrate ();

		if(soundEnabled == 1) {
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
