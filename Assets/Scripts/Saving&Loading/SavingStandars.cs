namespace SavingStandars  {

	/// <summary>
	/// Contains all they general keys for saving and loading; 
	/// </summary>
	public static class Keys{
		public static string dataKey(int savefilenumber){
			return "savedata" + savefilenumber.ToString(); 
		}
		public static string playerPositionx(int savefilenumber){
			return "savedata" + savefilenumber.ToString() + "playerposx"; 
		}
		public static string playerPositiony(int savefilenumber){
			return "savedata" + savefilenumber.ToString() + "playerposy"; 
		}
		public static string monsterAvailable(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "monsterav" + subindex.ToString(); 
		}
		public static string monsterExperience(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "monsterexp" + subindex.ToString(); 
		}
		public static string monsterHealth(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "monsterhealth" + subindex.ToString(); 
		}
		public static string npcstate(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "statenpc" + subindex.ToString(); 
		}
		public static string npcpositionx(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "npcposx" + subindex.ToString(); 
		}
		public static string npcpositiony(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "npcposy" + subindex.ToString(); 
		}
	}


	public class MonsterData{
		public string available; 
		public float health; 
		public float experience; 

		public MonsterData(){
			available = "false"; 
			health = 100f; 
			experience = 0; 

		}

		public MonsterData(string _available, float _health, float _experienc){
			available  = _available; 
			health = _health; 
			experience = _experienc; 

		}

	}


}
