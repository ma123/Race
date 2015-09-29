using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReactionScript : MonoBehaviour {
	public void ClickedLevelSelector() {
		print ("clicked load LevelSelector");
		Application.LoadLevel ("LevelSelectorScene");
	}

	public void ClickedChallenge() {
		print ("clicked load Challenge");
		Application.LoadLevel ("ChallengeScene");
	}

	public void ClickedExit() {
		print ("clicked exit");
		Application.Quit ();
	}
}
