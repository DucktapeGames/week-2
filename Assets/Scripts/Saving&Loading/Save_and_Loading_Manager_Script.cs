using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saving_Standars; 
using UnityEngine.UI; 

public class Save_and_Loading_Manager_Script : MonoBehaviour {

	public GameObject[] saves; 
	private Text[] savesText;
	float auxTime;
	int hours, minutes, seconds; 

	void Awake(){
		savesText = new Text[16]; 
		for (int n = 0; n < 16; n++) {
			savesText [n] = saves [n].GetComponentInChildren<Text> ();
			if (PlayerPrefs.HasKey (Keys.saveData (n))) {
				auxTime = PlayerPrefs.GetFloat (Keys.saveData (n)); 
				hours = Mathf.FloorToInt (auxTime / 3600); 
				minutes = Mathf.Abs (hours * 60 - Mathf.FloorToInt (auxTime / 60)); 
				seconds = Mathf.FloorToInt (auxTime % 100); 
				savesText [n].text = "Save " +(n+1)+": " + hours + " : " + minutes + " : " + seconds;  
			} else {
				savesText [n].text =  savesText [n].text = "Save " +(n+1)+": Blank"; 
			}
		}
	}






}
