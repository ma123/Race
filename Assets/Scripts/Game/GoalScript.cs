using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;

	void Start () {
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
		currentLevel = Application.loadedLevelName; // nacitanie mena aktualneho levela
	}

	public void GoalReact () {
		print ("destroy object Goal");
		PlayerPrefs.SetInt ("money", MoneyScript.GetMoney());
		UnlockLevels ();
		Destroy (gameObject);
	}

	protected void UnlockLevels (){
		for(int i = 1; i <= LockLevelScript.worlds; i++){
			for(int j = 1; j <= LockLevelScript.levels; j++){
				if(currentLevel == "Level"+ i.ToString() +"." +j.ToString()){
					if (j == LockLevelScript.levels) { // posledny level vo svete
						if (i != LockLevelScript.worlds) { // ak nie sme v poslednom svete 
							worldIndex = i + 1;
							levelIndex = 1;
							PlayerPrefs.SetInt ("level" + worldIndex.ToString () + ":" + levelIndex.ToString (), 1); // otvorenie prveho levelu v dalsom svete
							PlayerPrefs.SetInt ("world" + worldIndex.ToString(), 1); // otvorenie dalsieho sveta dlazdica
						}
					} else {
						worldIndex = i;
						levelIndex = (j + 1);
						PlayerPrefs.SetInt ("level" + worldIndex.ToString () + ":" + levelIndex.ToString (), 1);
					}
				}
			}
		}
		reactionFromPanel.GetComponent<ReactionFromPanelScript>().ShowLevelCompletePanel(); // parameter 2 pre dead stav
	}
}