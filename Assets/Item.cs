﻿//in this script  you will only need using UnityEngine as we just need the script to connect to unity
using UnityEngine;
//this public class doent inherit from MonoBehaviour
//this script is also referenced by other scripts but never attached to anything
public class Item {
	//basic variables for items that we need are 
	#region Private Variables
	//Identification Number
	int _id;
	//Object Name
	string _name;
	//Value of the Object
	int _value;
	//Description of what the Object is
	string _desc;
	//Icon that displays when that Object is in an Inventory
	Texture2D _icon;
	//Mesh of that object when it is equiped or in the world
	GameObject _mesh;
	//Enum ItemType which is the Type of object so we can classify them
	ItemType _type;
	int _heal;
	int _damage;
	int _armor;
	int _amount;
	#endregion

	#region Constructors
	//A constructor is a bit of code that allows you to create objects from a class. You call the constructor by using the keyword new 
	//followed by the name of the class, followed by any necessary parameters.
	//the Item needs Identification Number, Object Name, Icon and Type
	//here we connect the parameters with the item variables
	public void ItemCon(int itemId, string itemName, Texture2D itemIcon, ItemType itemType) {
		_id = itemId;
		_name = itemName;
		_icon = itemIcon;
		_type = itemType;
	}
	#endregion

	#region Public Variables
	//here we are creating the public versions or our private variables that we can reference and connect to when interacting with items
	//public Identification Number
	public int ID {
		//get the private Identification Number
		get { return _id; }
		//and set it to the value of our public Identification Number
		set { _id = value; }
	}
	//public Name 
	public string Name {
		//get the private Name
		get { return _name; }
		//and set it to the value of our public Name
		set { _name = value; }
	}
	//public Value 
	public int Value {
		//get the private Value
		get { return _value; }
		//and set it to the value of our public Value
		set { _value = value; }
	}
	//public Description 
	public string Desc {
		//get the private Description
		get { return _desc; }
		//and set it to the value of our public Description
		set { _desc = value; }
	}
	//public Icon 
	public Texture2D Icon {
		//get the private Icon
		get { return _icon; }
		//and set it to the value of our public Icon
		set { _icon = value; }
	}
	//public Mesh 
	public GameObject Mesh {
		//get the private Mesh
		get { return _mesh; }
		//and set it to the value of our public Mesh
		set { _mesh = value; }
	}
	//public Type 
	public ItemType Type {
		//get the private Type
		get { return _type; }
		//and set it to the value of our public Type
		set { _type = value; }
	}
	public int Heal {
		//get the private Type
		get { return _heal; }
		//and set it to the value of our public Type
		set { _heal = value; }
	}
	public int Damage {
		//get the private Type
		get { return _damage; }
		//and set it to the value of our public Type
		set { _damage = value; }
	}
	public int Armor {
		//get the private Type
		get { return _armor; }
		//and set it to the value of our public Type
		set { _armor = value; }
	}
	public int Amount {
		//get the private Type
		get { return _amount; }
		//and set it to the value of our public Type
		set { _amount = value; }
	}
	#endregion
}
#region Enums
//The Global Enum ItemType that we have created categories in
public enum ItemType {
	Money,
	Food,
	Potion,
	Material,
	Apparel,
	Weapon
}
#endregion
