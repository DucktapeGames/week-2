using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using SavingStandars; 

public class Save_File_List : MonoBehaviour {

	public Text[] saves; 

	private float auxTime; 
	private int auxHours, auxMinutes, auxSeconds; 
	private int selectedIndex; 

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


	void LoadData(int index){
		Current_Saved_Data_Reference.playtime = PlayerPrefs.GetFloat (Keys.dataKey (index)); 
		Current_Saved_Data_Reference.playerPosition.x = PlayerPrefs.GetFloat (Keys.playerPositionx(index)); 
		Current_Saved_Data_Reference.playerPosition.y = PlayerPrefs.GetFloat (Keys.playerPositiony (index)); 
		for (int n = 0; n < Current_Saved_Data_Reference.npcStates.Length; n++) {
			Current_Saved_Data_Reference.npcStates [n] = PlayerPrefs.GetInt (Keys.npcstate (index, n)); 
			Current_Saved_Data_Reference.npcPositions [n].x = PlayerPrefs.GetInt (Keys.npcpositionx); 
			Current_Saved_Data_Reference.npcPositions [n].y = PlayerPrefs.GetInt (Keys.npcpositiony);
		}
		for (int n = 0; n < Current_Saved_Data_Reference.monster.Length; n++) {
			Current_Saved_Data_Reference.monster [n].available = PlayerPrefs.GetString (Keys.monsterAvailable); 
			Current_Saved_Data_Reference.monster [n].health = PlayerPrefs.GetFloat (Keys.monsterHealth); 
			Current_Saved_Data_Reference.monster [n].experience = PlayerPrefs.GetFloat (Keys.monsterExperience); 

		}
	}

}
