using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	private GameObject reactionFromPanel;
	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;
	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevelName;
		reactionFromPanel = GameObject.FindGameObjectWithTag ("ReactionFromPanel");
	}

	public void GoalReact () {
		print ("destroy object Goal");
		reactionFromPanel.GetComponent<ReactionFromPanelScript>().WinnPanelReaction(3); // parameter 3 pre winn stav 
		//UnlockLevels ();
		Destroy (gameObject);
	}

	protected void  UnlockLevels (){
		//set the playerprefs value of next level to 1 to unlock
		for(int i = 0; i < LockLevelScript.worlds; i++){
			for(int j = 1; j < LockLevelScript.levels; j++){               
				if(currentLevel == "Level"+(i+1).ToString() +"." +j.ToString()){
					worldIndex  = (i+1);
					levelIndex  = (j+1);
					PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),1);
				}
			}
		}
		//load the World1 level 
		Application.LoadLevel("GreenLandLevelsScene");
	}
}
