using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocketdex : MonoBehaviour {

	private static Pocketdex _instance; 
	public static Pocketdex Instance{
		get{ 
			if (_instance == null) { 
				GameObject go = new GameObject ("Pocketdex");
				go.AddComponent<Pocketdex> (); 
				_instance = go.GetComponent<Pocketdex> (); 
				return _instance; 
			}
			return _instance; 
		}
	}
	void Awake(){
		_instance = this; 
	}

	public enum Types{
		Null = 0,
		Food = 1, 
		Tool = 2,
		Dafaq =3, 
	}

	public struct Attack{
		private string _name;
		private string _description; 
		private Types _type; 
		private float _basePower; 
		public string Name{
			get{
				return _name; 
			}
			set{
				_name = value; 
			}
		}
		public Types AttackType{
			get{
				return _type; 
			}
			set{
				_type = value; 
			}
		}
		public string Description{
			get{
				return _description; 
			}
			set{
				_description = value; 
			}
		}
		public float BasePower{
			get{
				return _basePower; 
			}
			set{
				_basePower = value; 
			}
		}

		public Attack(string a_name, float a_power, string a_description, Types a_type){
			_name = a_name; 
			_basePower = a_power; 
			_description = a_description; 
			_type = a_type; 
		}
	}

	public class pocketdexMonster{
		public string name; 
		public Types type; 
		public string Description; 
		public Attack[] attacks;




	}

	public class HotPocketchu: pocketdexMonster{
		HotPocketchu(){
			name = "Hotpocketchu"; 
			type = Types.Food; 
			attacks = new Attack[2]; 
			attacks[0] = new Attack("Tackuruh!", 0, "Hotpockechu screams 'Tackle!' in a masculine Japanese voice. It does nothing.", Types.Food); 
			attacks[1] = new Attack("Squirt Sauce", 7f, "Hotpockechu clenches its insides, shooting a bit of its bodily sauce at foe", Types.Food); 
			//continuar agregando el movellist.  
		}

	}
	//continuar agregando pocketmons





}
