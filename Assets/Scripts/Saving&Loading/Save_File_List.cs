using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using SavingStandars; 

public class Save_File_List : MonoBehaviour {

	public Text[] saves; 

	private float auxTime; 
	private int auxHours, auxMinutes, auxSeconds; 

	void Awake(){
		for (int n = 0; n < saves.Length; n++) {
			if (PlayerPrefs.HasKey (Keys.dataKey (n))) {
				auxTime = PlayerPrefs.GetFloat (Keys.dataKey (n)); 
				auxHours = Mathf.FloorToInt (auxTime / 3600); 
				auxMinutes =  Mathf.Abs(Mathf.FloorToInt ((auxHours * 60) - Mathf.FloorToInt (auxTime/60)));
				auxSeconds = Mathf.FloorToInt (auxTime % 60);
				saves [n].text = "Save " + (n + 1) + ": " + auxHours + "h:" + auxMinutes + "m:" + auxSeconds + "s"; 
			} else {
				saves [n].text = "Save " + (n + 1) + ": Blank"; 
			}
		}
	}

	void Start(){

	}



	/*double getSavedData(){
		
	}*/

}
