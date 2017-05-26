using UnityEngine; 
namespace Saving_Standars {

	public static class Keys{
		/// <summary>
		/// Keeps the total play time; 
		/// </summary>
		/// <returns>The data.</returns>
		/// <param name="fileindex">Fileindex.</param>
		public static string saveData(int fileindex){
			return "<"+fileindex+">"; 
		}
		/// <summary>
		/// Se esta presuponiendo que conocemos los ID de todos los entities. 
		/// WIth the entity ID and the save file index you get the entities name in that save. 
		/// </summary>
		/// <returns>The name.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="entityID">Entity I.</param>
		public static string entityName(int fileIndex,int entityID){
			return "<"+fileIndex+">-entity-<" + entityID + ">-name"; 
		}
		/// <summary>
		/// Se esta presuponiendo que conocemos los ID de todos los entities. 
		/// WIth the entity ID and the save file index you get the entities x position in that save. 
		/// </summary>
		/// <returns>The position x.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="entityID">Entity I.</param>
		public static string entityPosX(int fileIndex,int entityID){
			return "<"+fileIndex+">-entity-<" + entityID + ">-x"; 
		}
		/// <summary>
		/// Se esta presuponiendo que conocemos los ID de todos los entities. 
		/// WIth the entity ID and the save file index you get the entities y position in that save.
		/// </summary>
		/// <returns>The position y.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="entityID">Entity I.</param>
		public static string entityPosY(int fileIndex,int entityID){
			return "<"+fileIndex+">-entity-<" + entityID + ">-y"; 
		}
		/// <summary>
		/// Se esta presuponiendo que conocemos los ID de todos los entities. 
		/// WIth the entity ID and the save file index you get ether or not the entitie is
		/// a trainer, (0 for false 1 for true) in that save.
		/// </summary>
		/// <returns>The trainer.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="entityID">Entity I.</param>
		public static string isTrainer(int fileIndex,int entityID){
			return "<"+fileIndex+">-entity-<" + entityID + ">-isTrainer";
		}
		/// <summary>
		/// Se esta presuponiendo que conocemos los ID de todos los entities. 
		/// WIth the entity ID and the save file index you get the entities inventory in that save.
		/// </summary>
		/// <returns>The I.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="entityID">Entity I.</param>
		public static string invetoryID(int fileIndex,int entityID){
			return "<"+fileIndex+">-entity-<" + entityID + ">-inventoryID";
		}
		/// <summary>
		/// Una vez obtenido el inventory id puedes hacer referencia a los slots, puesto que el 
		/// entities invetory ID corresponde a 1 solo entitie.
		/// Using the save file index and the inventory ID (which correspondes to a certain entitie):  
		/// gest the ID of the monster in the specified slot of the inventory. 
		/// </summary>
		/// <returns>The I.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="inventoryID">Inventory I.</param>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		public static string slotID(int fileIndex,int inventoryID, int row, int column){
			return "<"+fileIndex+">-inventory-<" + inventoryID + ">-slot-["+row+","+column+"]-ID";

		}
		/// <summary>
		/// Una vez obtenido el inventory id puedes hacer referencia a los slots, puesto que el 
		/// entities invetory ID corresponde a 1 solo entitie.
		/// Using the save file index and the inventory ID (which correspondes to a certain entitie):  
		/// gest the pocketedxID of the monster in the specified slot of the inventory.
		/// </summary>
		/// <returns>The pocketdex I.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="inventoryID">Inventory I.</param>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		public static string slotPocketdexID(int fileIndex,int inventoryID, int row, int column){
			return "<"+fileIndex+">-inventory-<" + inventoryID + ">-slot-["+row+","+column+"]-pocketdexID";

		}
		/// <summary>
		/// Una vez obtenido el inventory id puedes hacer referencia a los slots, puesto que el 
		/// entities invetory ID corresponde a 1 solo entitie.
		/// Using the save file index and the inventory ID (which correspondes to a certain entitie):  
		/// gest the health of the monster in the specified slot of the inventory.
		/// </summary>
		/// <returns>The hp.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="inventoryID">Inventory I.</param>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		public static string slotHp(int fileIndex,int inventoryID, int row, int column){
			return "<"+fileIndex+">-inventory-<" + inventoryID + ">-slot-["+row+","+column+"]-stats-hp";

		}
		/// <summary>
		/// Una vez obtenido el inventory id puedes hacer referencia a los slots, puesto que el 
		/// entities invetory ID corresponde a 1 solo entitie.
		/// Using the save file index and the inventory ID (which correspondes to a certain entitie):  
		/// gest the experience of the monster in the specified slot of the inventory.
		/// </summary>
		/// <returns>The xp.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="inventoryID">Inventory I.</param>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		public static string slotXp(int fileIndex,int inventoryID, int row, int column){
			return "<"+fileIndex+">-inventory-<" + inventoryID + ">-slot-["+row+","+column+"]-stats-xp";

		}
		/// <summary>
		/// Una vez obtenido el inventory id puedes hacer referencia a los slots, puesto que el 
		/// entities invetory ID corresponde a 1 solo entitie.
		/// Using the save file index and the inventory ID (which correspondes to a certain entitie):  
		/// gest the attack of the monster in the specified slot of the inventory.
		/// </summary>
		/// <returns>The atk.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="inventoryID">Inventory I.</param>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		public static string slotAtk(int fileIndex,int inventoryID, int row, int column){
			return "<"+fileIndex+">-inventory-<" + inventoryID + ">-slot-["+row+","+column+"]-stats-atk";

		}
		/// <summary>
		/// Una vez obtenido el inventory id puedes hacer referencia a los slots, puesto que el 
		/// entities invetory ID corresponde a 1 solo entitie.
		/// Using the save file index and the inventory ID (which correspondes to a certain entitie):  
		/// gest the defence of the monster in the specified slot of the inventory.
		/// </summary>
		/// <returns>The def.</returns>
		/// <param name="fileIndex">File index.</param>
		/// <param name="inventoryID">Inventory I.</param>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		public static string slotDef(int fileIndex,int inventoryID, int row, int column){
			return "<"+fileIndex+">-inventory-<" + inventoryID + ">-slot-["+row+","+column+"]-stats-def";

		}


	}

	/// <summary>
	/// Class: contains 4 stats -> health, experience, attack, defence.
	/// Purpose: To be used in monster class.   
	/// </summary>
	public class StatsClass{
		public float hp; 
		public float xp; 
		public float atk; 
		public float def; 

		/// <summary>
		/// Inicializes all the stat values with 0;  
		/// </summary>
		public StatsClass(){
			hp = 0; 
			xp = 0; 
			atk = 0; 
			def = 0;
		}
		/// <summary>
		/// Takes in the heath and experience for this stat values. 
		/// If not specified the stat will be set to 0 by defaul. 
		/// </summary>
		/// <param name="_hp">Hp.</param>
		/// <param name="_xp">Xp.</param>
		public StatsClass(float _hp, float _xp){
			hp = _hp; 
			xp = _xp; 
		}
		/// <summary>
		/// Takes in the heath, experience and attack for this stat values. 
		/// If not specified the stat will be set to 0 by defaul. 
		/// </summary>
		/// <param name="_hp">Hp.</param>
		/// <param name="_xp">Xp.</param>
		/// <param name="_atk">Atk.</param>
		public StatsClass(float _hp, float _xp, float _atk){
			hp = _hp; 
			xp = _xp; 
			atk = _atk; 
		}
		/// <summary>
		/// Takes in the health, experience, attack and defence for this stat values. 
		/// </summary>
		/// <param name="_hp">Hp.</param>
		/// <param name="_xp">Xp.</param>
		/// <param name="_atk">Atk.</param>
		/// <param name="_def">Def.</param>
		public StatsClass(float _hp, float _xp, float _atk, float _def){
			hp = _hp; 
			xp = _xp; 
			atk = _atk; 
			def = _def; 
		}
	}
	/// <summary>
	/// Struct: Contains an id, a series number (pocketdexID) and stats. 
	/// </summary>
	public class MonsterClass{
		public int id; 
		public int pocketdexID; 
		public StatsClass stats;

		/// <summary>
		/// Takes an id, series number in the pocketdex and healht and experience for the creature. 
		/// If the stat is not specified will be set to 0;
		/// </summary>
		/// <param name="_id">Identifier.</param>
		/// <param name="_pocketdexID">Pocketdex I.</param>
		/// <param name="_hp">Hp.</param>
		/// <param name="_xp">Xp.</param>
		public MonsterClass(int _id, int _pocketdexID, float _hp, float _xp){
			id = _id; 
			pocketdexID = _pocketdexID; 
			stats = new StatsClass( _hp,  _xp);  
		}
		/// <summary>
		/// Takes an id, series number in the pocketdex and healht, experience, and attack  for the creature. 
		/// If the stat is not specified will be set to 0; 
		/// </summary>
		/// <param name="_id">Identifier.</param>
		/// <param name="_pocketdexID">Pocketdex I.</param>
		/// <param name="_hp">Hp.</param>
		/// <param name="_xp">Xp.</param>
		/// <param name="_atk">Atk.</param>
		public MonsterClass(int _id, int _pocketdexID, float _hp, float _xp, float _atk){
			id = _id; 
			pocketdexID = _pocketdexID; 
			stats = new StatsClass( _hp,  _xp,  _atk);  
		}
		/// <summary>
		/// Takes an id, series number in the pocketdex and healht, experience, attack and defence for the creature. 
		/// If the stat is not specified will be set to 0; 
		/// </summary>
		/// <param name="_id">Identifier.</param>
		/// <param name="_pocketdexID">Pocketdex I.</param>
		/// <param name="_hp">Hp.</param>
		/// <param name="_xp">Xp.</param>
		/// <param name="_atk">Atk.</param>
		/// <param name="_def">Def.</param>
		public MonsterClass(int _id, int _pocketdexID, float _hp, float _xp, float _atk, float _def){
			id = _id; 
			pocketdexID = _pocketdexID; 
			stats = new StatsClass( _hp,  _xp,  _atk,  _def);  
		}
		/// <summary>
		/// The id, series number in the pocketdex and the stats for the creature. 
		/// </summary>
		/// <param name="_id">Identifier.</param>
		/// <param name="_pocketdexID">Pocketdex I.</param>
		/// <param name="_stats">Stats.</param>
		public MonsterClass(int _id, int _pocketdexID, StatsClass _stats){
			id = _id; 
			pocketdexID = _pocketdexID; 
			stats = _stats;  
		}
	}

	/// <summary>
	/// Used to define the player and NPCs. Takes a name,  an int to determine wether or not is trainer, an inventory ID
	/// and an 2D array of MonsterClass type objects. (The player can only carry monster for now). 
	/// </summary>
	public class EntityClass{
		public int Id; 
		public string name; 
		public int isTrainer; 
		public int inventoryID;
		public MonsterClass[,] inventory; 

		/// <summary>
		/// If nothing is specified, name will be set to "It",  istrainer = 0 (false) and inventory ID = 0and the inventory 
		/// will be inicialized to a 3x4 2D array and with the defaul monster class constructor: 
		/// Monstercalss(0,0,new StatsClass());  
		/// </summary>
		public EntityClass(int _id){
			Id = _id; 
			name = "It"; 
			isTrainer = 0; 
			inventoryID = 0; 
			inventory = new MonsterClass[3, 4]; 
			for (int n = 0; n < 3; n++) {
				for (int m = 0; m < 4; m++) {
					inventory [n, m] = new MonsterClass (0, 0, new StatsClass ()); 
				}
			}
		}
		/// <summary>
		/// Sets the name. 
		/// istrainer = 0 (false), the inventory ID = 0 and the invetory 
		/// will be inicialized to a 3x4 2D array with the defaul monster class constructor: 
		/// Monstercalss(0,0,new StatsClass()); 
		/// </summary>
		/// <param name="_name">Name.</param>
		public EntityClass(int _id, string _name){
			Id = _id; 
			name = _name; 
			isTrainer = 0; 
			inventoryID = 0; 
			inventory = new MonsterClass[3, 4]; 
			for (int n = 0; n < 3; n++) {
				for (int m = 0; m < 4; m++) {
					inventory [n, m] = new MonsterClass (0, 0, new StatsClass ()); 
				}
			}
		}
		/// <summary>
		/// Sets wether or not is trainer. (0 for false, 1 for true). 
		/// If nothing is specified, name will be set to "It" , the inventory ID = 0 and the inventory 
		/// will be inicialized to a 3x4 2D array with the defaul monster class constructor: 
		/// Monstercalss(0,0,new StatsClass());  
		/// </summary>
		/// <param name="_isTrainer">Is trainer.</param>
		public EntityClass(int _id, int _isTrainer){
			Id = _id; 
			name = "It"; 
			isTrainer = _isTrainer; 
			inventoryID = 0; 
			inventory = new MonsterClass[3, 4]; 
			for (int n = 0; n < 3; n++) {
				for (int m = 0; m < 4; m++) {
					inventory [n, m] = new MonsterClass (0, 0, new StatsClass ()); 
				}
			}
		}
		/// <summary>
		/// Sets the name and wether or not is trainer (0 for false, 1 for true). Inventory ID = 0 and 
		/// the inventory will be inicialized to a 3x4 2D array with the defaul monster class constructor: 
		/// Monstercalss(0,0,new StatsClass());  
		/// </summary>
		/// <param name="_name">Name.</param>
		/// <param name="_isTrainer">Is trainer.</param>
		public EntityClass(int _id, string _name, int _isTrainer){
			Id = _id; 
			name = _name; 
			isTrainer = _isTrainer; 
			inventoryID = 0; 
			inventory = new MonsterClass[3, 4]; 
			for (int n = 0; n < 3; n++) {
				for (int m = 0; m < 4; m++) {
					inventory [n, m] = new MonsterClass (0, 0, new StatsClass ()); 
				}
			}
		}
		/// <summary>
		/// Sets the name, wether or not is trainer (0 for false 1 for true) and the inventory ID. 
		/// the inventory will be inicialized to a 3x4 2D array with the defaul monster class constructor: 
		/// Monstercalss(0,0,new StatsClass());  
		/// </summary>
		/// <param name="_name">Name.</param>
		/// <param name="_isTrainer">Is trainer.</param>
		/// <param name="_inventoryID">Inventory I.</param>
		public EntityClass(int _id, string _name, int _isTrainer, int _inventoryID){
			Id = _id; 
			name = _name; 
			isTrainer = _isTrainer; 
			inventoryID = _inventoryID; 
			inventory = new MonsterClass[3, 4]; 
			for (int n = 0; n < 3; n++) {
				for (int m = 0; m < 4; m++) {
					inventory [n, m] = new MonsterClass (0, 0, new StatsClass ()); 
				}
			}
		}
		/// <summary>
		/// sets the name, wether or not is trainer (0 for false, 1 for ture0, the inventory ID and the inventory itself
		/// which is a 3x4 2D array of MonsterClass type objects. 
		/// </summary>
		/// <param name="_name">Name.</param>
		/// <param name="_isTrainer">Is trainer.</param>
		/// <param name="_inventoryID">Inventory I.</param>
		/// <param name="_inventory">Inventory.</param>
		public EntityClass(int _id, string _name, int _isTrainer, int _inventoryID, MonsterClass[,] _inventory){
			Id = _id; 
			name = _name; 
			isTrainer = _isTrainer; 
			inventoryID = _inventoryID; 
			inventory = _inventory;  
		}

		/// <summary>
		/// Sets a specific slot of the inventory to a certain monster. THe inventory is 3x4. 
		/// Will throw error if the specified index is out of range. 
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		/// <param name="_monster">Monster.</param>
		public void setInvetorySlot(int row, int column, MonsterClass _monster){
			if(row<2 && row>=0 && column<4 && column>=0){
				if (inventory == null) {
					inventory = new MonsterClass[3, 4]; 
					inventory [row, column] = _monster; 
				} else {
					inventory [row, column] = _monster; 
				}
			}else{
				Debug.LogError("Rows must be within 0 - 2. Columns must be 0 - 3."); 

			}
		}

		}

	}
	
