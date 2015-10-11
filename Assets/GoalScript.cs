using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;
	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevelName;
	}

	public void GoalReact () {
		print ("destroy object Goal");
		UnlockLevels ();
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
