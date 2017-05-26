namespace SavingStandars  {

	/// <summary>
	/// Contains all they general keys for saving and loading; 
	/// </summary>
	public static class Keys{
		public static string dataKey(int savefilenumber){
			return "savedata" + savefilenumber.ToString(); 
		}
		public static string playerPositionx(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "playerposx" + subindex.ToString(); 
		}
		public static string playerPositiony(int savefilenumber, int subindex){
			return "savedata" + savefilenumber.ToString() + "playerposy" + subindex.ToString(); 
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


}
