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
	public AudioClip greenlandIntro;
	public AudioClip citylandIntro;
	public AudioClip desertlandIntro;
	public AudioClip darkgreenlandIntro;
	public AudioClip snowlandIntro;
	// loop melody
	public AudioClip greenlandLoop;
	public AudioClip citylandLoop;
	public AudioClip desertlandLoop;
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
			StartCoroutine(PlayBackgroundMusic());
		}
	}

	IEnumerator PlayBackgroundMusic() {
		string currentLevel = Application.loadedLevelName;
		int numberWorld = ((int)currentLevel [5]) - 48; // konverzia z char na int odpocitame 48 ako rozdiel v ascii tabulke
			switch(numberWorld) {
			case 1: // greenland
			    musicBackground.clip = greenlandIntro;  // priradi intro melodiu  
				musicBackground.Play();  
				yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
				musicBackground.clip = greenlandLoop; // priradi loop melodiu
				musicBackground.Play();
				break;
			case 2: // cityland
				musicBackground.clip = citylandIntro;  // priradi intro melodiu  
				musicBackground.Play();  
				yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
				musicBackground.clip = citylandLoop; // priradi loop melodiu
				musicBackground.Play();
				break;
			case 3: // desertland
				musicBackground.clip = desertlandIntro;  // priradi intro melodiu  
				musicBackground.Play();  
				yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
				musicBackground.clip = desertlandLoop; // priradi loop melodiu
				musicBackground.Play();
				break;
			case 4: // drakgreenland
				musicBackground.clip = darkgreenlandIntro;  // priradi intro melodiu  
				musicBackground.Play();  
				yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
				musicBackground.clip = darkgreenlandLoop; // priradi loop melodiu
				musicBackground.Play();
				break;
			case 5: // snowland
				musicBackground.clip = snowlandIntro;  // priradi intro melodiu  
				musicBackground.Play();  
				yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
				musicBackground.clip = snowlandLoop; // priradi loop melodiu
				musicBackground.Play();
				break;
			default:
				// default vetva no sounds
				break;
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
