using UnityEngine;
using System.Collections;

public class SoundsAndMusicScript : MonoBehaviour {
	public AudioClip explosionClips;
	public AudioClip pickupCoinClips;

	public void PickupCoinAudio(Transform transPos) {
		AudioSource.PlayClipAtPoint(pickupCoinClips, transPos.position);
	}

	public void ExplosionAudio(Transform transPos) {
		AudioSource.PlayClipAtPoint(pickupCoinClips, transPos.position);
	}

}
