using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class TopCarColliderScript : MonoBehaviour {
	public GameObject winPanel;
	public AudioClip explosionClips;

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll != null) {
			print ("kolizia na streche");
			AudioSource.PlayClipAtPoint(explosionClips, transform.position);
			Time.timeScale = 0; // pauznutie hry
			winPanel.SetActive(true);
			GameObject btnInteractable = GameObject.Find("NextLvlBtn");
			btnInteractable.GetComponent<Button>().interactable = false;
			GameObject btnInteractableBack = GameObject.Find("BackToGameBtn");
			btnInteractableBack.GetComponent<Button>().interactable = false;
		}	

			
	}
}
