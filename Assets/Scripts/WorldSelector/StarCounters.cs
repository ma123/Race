using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StarCounters : MonoBehaviour {
	public Text[] starTextArray;
	private int totalStars = 0;
	// Use this for initialization
	void Start () {
		for(int i = 1; i <= LockLevelScript.worlds; i++){
			for (int j = 1; j <= LockLevelScript.levels; j++) {
				totalStars += PlayerPrefs.GetInt ("level" + i.ToString () + ":" + j.ToString () + "stars", 0);
			}
			print (totalStars);
	
			starTextArray[i-1].text = totalStars.ToString() +"/45";
			totalStars = 0;
		}
	}
}
