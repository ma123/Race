using UnityEngine;
using System.Collections;

public class SoundsAndMusicScript : MonoBehaviour {
	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;
	public AudioClip gumClips;
	public AudioClip noInkClips;
	public AudioClip inkClips;
	public AudioClip winClips;
	//public AudioClip gravityReverseClips;

	private int soundEnabled = 0;
	//private int musicEnabled = 0;
	private int vibrationEnabled = 0;
	
	void Start() {
		soundEnabled = PlayerPrefs.GetInt("sound",0);
		//musicEnabled = PlayerPrefs.GetInt("music",0);
		vibrationEnabled = PlayerPrefs.GetInt("vibration",0);
	}

	public void PickupCoinAudio(Transform transPos) {
		if(vibrationEnabled == 1) {
			print ("vibration coin");
		   Handheld.Vibrate();
		}

		if(soundEnabled == 1) {
			print ("sound coin");
		   AudioSource.PlayClipAtPoint(pickupCoinClips, transPos.position);
		}
	}

	public void ExplosionAudio(Transform transPos) {
		if (vibrationEnabled == 1) {
			Handheld.Vibrate ();
		}

		if (soundEnabled == 1) {
			AudioSource.PlayClipAtPoint (explosionClips, transPos.position);
		}
	}

	public void PickupGumAudio(Transform transPos) {
		if (vibrationEnabled == 1) {
			Handheld.Vibrate ();
		}

		if (soundEnabled == 1) {
			AudioSource.PlayClipAtPoint (gumClips, transPos.position);
		}
	}

	public void PickupInkAudio(Transform transPos) {
		if (vibrationEnabled == 1) {
			Handheld.Vibrate ();
		}

		if (soundEnabled == 1) {
			AudioSource.PlayClipAtPoint (inkClips, transPos.position);
		}
	}

	public void NoInkAudio(Transform transPos) {
		if (vibrationEnabled == 1) {
			Handheld.Vibrate ();
		}

		if (soundEnabled == 1) {
			AudioSource.PlayClipAtPoint (noInkClips, transPos.position);
		}
	}

	public void WinAudio(Transform transPos) {
		if (vibrationEnabled == 1) {
			Handheld.Vibrate ();
		}

		if (soundEnabled == 1) {
			AudioSource.PlayClipAtPoint (winClips, transPos.position);
		}
	}
}
