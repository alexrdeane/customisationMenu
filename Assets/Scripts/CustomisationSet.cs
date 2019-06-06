using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour {

	public Player player;

	#region Variables
	[Header("Texture List")]
	//Texture2D List for skin, hair, mouth, eyes
	List<Texture2D> skin = new List<Texture2D>();
	List<Texture2D> hair = new List<Texture2D>();
	List<Texture2D> mouth = new List<Texture2D>();
	List<Texture2D> eyes = new List<Texture2D>();
	[Header("Index")]
	//index numbers for our current skin, hair, mouth, eyes textures
	public List<int> indices = new List<int>() { 0, 0, 0, 0 };
	[Header("Renderer")]
	//renderer for our character mesh so we can reference a material list
	public Renderer characterRenderer;
	[Header("Max Index")]
	//max amount of skin, hair, mouth, eyes textures that our lists are filling with
	List<int> maxIndices = new List<int>() { 4, 5, 3, 4 };

	List<string> textureNames = new List<string>() { "Skin_", "Hair_", "Mouth_", "Eyes_" };

	public string charName = "Character Name";
	public int[] stats = new int[6];
	public CharacterClass charClass = CharacterClass.Knight;

	#endregion

	void Awake() {
		/*Debug.Log(Application.persistentDataPath);
		PlayerData data = SaveSystem.LoadPlayer();
		if (data) {
			indices[0] = data.indexEyes;
			indices[1] = data.indexHair;
			indices[2] = data.indexMouth;
			indices[3] = data.indexSkin;
			charName = data.charName;
		}*/
	}

	#region Start
	//in start we need to set up the following
	void Start() {
		
		#region for loop to pull textures from file
		for (int i = 0; i < indices.Count; i++) {
			for (int j = 0; j < maxIndices[i]; j++) {
				Texture2D temp = Resources.Load<Texture2D>("Character/" + textureNames[i] + j.ToString());
				if (i == 0) { skin.Add(temp); }
				else if (i == 1) { hair.Add(temp); }
				else if (i == 2) { mouth.Add(temp); }
				else { eyes.Add(temp); }
			}
		}
		//for loop looping from 0 to less than the max amount of skin textures we need
		//creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
		//add our temp texture that we just found to the skin List
		//for loop looping from 0 to less than the max amount of hair textures we need
		//creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
		//add our temp texture that we just found to the hair List
		//for loop looping from 0 to less than the max amount of mouth textures we need    
		//creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
		//add our temp texture that we just found to the mouth List

		//for loop looping from 0 to less than the max amount of eyes textures we need
		//creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
		//add our temp texture that we just found to the eyes List            
		#endregion
		//connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
		#region do this after making the function SetTexture
		SetTexture(0, 0);
		//SetTexture skin, hair, mouth, eyes to the first texture 0
		#endregion
	}
	#endregion

	#region SetTexture
	//Create a function that is called SetTexture it should contain a string and int
	void SetTexture(int mat, int a) {
		indices[mat] = (indices[mat] + maxIndices[mat] + a) % maxIndices[mat];
		if (mat == 0) {
			characterRenderer.materials[1].mainTexture = skin[indices[mat]];
		}
		else if (mat == 1) {
			characterRenderer.materials[2].mainTexture = hair[indices[mat]];
		}
		else if (mat == 2) {
			characterRenderer.materials[3].mainTexture = mouth[indices[mat]];
		}
		else {
			characterRenderer.materials[4].mainTexture = eyes[indices[mat]];
		}
		//the string is the name of the material we are editing, the int is the direction we are changing
		//we need variables that exist only within this function
		//these are ints index numbers, max numbers, material index and Texture2D array of textures
		//inside a switch statement that is swapped by the string name of our material
		#region Switch Material
		//case skin
		//index is the same as our skin index
		//max is the same as our skin max
		//textures is our skin list .ToArray()
		//material index element number is 1
		//break
		//now repeat for each material 
		//hair is 2
		//index is the same as our index
		//max is the same as our max
		//textures is our list .ToArray()
		//material index element number is 2
		//break
		//mouth is 3
		//index is the same as our index
		//max is the same as our max
		//textures is our list .ToArray()
		//material index element number is 3
		//break
		//eyes are 4
		//index is the same as our index
		//max is the same as our max
		//textures is our list .ToArray()
		//material index element number is 4
		//break
		#endregion
		#region OutSide Switch
		//outside our switch statement
		//index plus equals our direction
		//cap our index to loop back around if is is below 0 or above max take one
		//Material array is equal to our characters material list
		//our material arrays current material index's main texture is equal to our texture arrays current index
		//our characters materials are equal to the material array
		//create another switch that is goverened by the same string name of our material
		#endregion
		#region Set Material Switch
		//case skin
		//skin index equals our index
		//break
		//case hair
		//index equals our index
		//break
		//case mouth
		//index equals our index
		//break
		//case eyes
		//index equals our index
		//break
		#endregion
	}
	#endregion

	#region Save
	//Function called Save this will allow us to save our indexes 
	void Save() {
		
		//SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
		//SetString CharacterName

	}
	#endregion

	#region OnGUI
	void OnGUI() {
		float scrW = 1 / 16;
		float scrH = 1 / 9;

		//Function for our GUI elements
		//create the floats scrW and scrH that govern our 16:9 ratio
		//create an int that will help with shuffling your GUI elements under eachother
		#region Skin
		//GUI button on the left of the screen with the contence <
		if (GUI.Button(new Rect(100, 340, 100, 100), "<")) {
			SetTexture(0, -1);
		}
		GUI.Box(new Rect(200, 340, 200, 100), "Skin");
		if (GUI.Button(new Rect(400, 340, 100, 100), ">")) {
			SetTexture(0, 1);
		}
		if (GUI.Button(new Rect(100, 440, 100, 100), "<")) {
			SetTexture(1, -1);
		}
		GUI.Box(new Rect(200, 440, 200, 100), "Hair");
		if (GUI.Button(new Rect(400, 440, 100, 100), ">")) {
			SetTexture(1, 1);
		}
		if (GUI.Button(new Rect(100, 540, 100, 100), "<")) {
			SetTexture(2, -1);
		}
		GUI.Box(new Rect(200, 540, 200, 100), "Mouth");
		if (GUI.Button(new Rect(400, 540, 100, 100), ">")) {
			SetTexture(2, 1);
		}
		if (GUI.Button(new Rect(100, 640, 100, 100), "<")) {
			SetTexture(3, -1);
		}
		GUI.Box(new Rect(200, 640, 200, 100), "Eyes");
		if (GUI.Button(new Rect(400, 640, 100, 100), ">")) {
			SetTexture(3, 1);
		}
		//when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
		//GUI Box or Lable on the left of the screen with the contence Skin
		//GUI button on the left of the screen with the contence >
		//when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
		//move down the screen with the int using ++ each grouping of GUI elements are moved using this
		#endregion
		//set up same things for Hair, Mouth and Eyes
		#region Hair
		//GUI button on the left of the screen with the contence <
		//when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
		//GUI Box or Lable on the left of the screen with the contence material Name
		//GUI button on the left of the screen with the contence >
		//when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
		//move down the screen with the int using ++ each grouping of GUI elements are moved using this
		#endregion
		#region Mouth
		//GUI button on the left of the screen with the contence <
		//when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
		//GUI Box or Lable on the left of the screen with the contence material Name
		//GUI button on the left of the screen with the contence >
		//when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
		//move down the screen with the int using ++ each grouping of GUI elements are moved using this
		#endregion
		#region Eyes
		//GUI button on the left of the screen with the contence <
		//when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
		//GUI Box or Lable on the left of the screen with the contence material Name
		//GUI button on the left of the screen with the contence >
		//when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
		//move down the screen with the int using ++ each grouping of GUI elements are moved using this
		#endregion
		#region Random Reset
		if (GUI.Button(new Rect(100, 240, 200, 100), "Random")) {
			for (int i = 0; i < indices.Count; i++) {
				for (int j = 0; j < 4; j++) {
					SetTexture(i, Random.Range(-3, 3));
				}
			}
		}
		if (GUI.Button(new Rect(300, 240, 200, 100), "Reset")) {
			indices[0] = 0;
			indices[1] = 0;
			indices[2] = 0;
			indices[3] = 0;
			SetTexture(0, 0);
			SetTexture(1, 0);
			SetTexture(2, 0);
			SetTexture(3, 0);
		}
		//create 2 buttons one Random and one Reset
		//Random will feed a random amount to the direction 
		//reset will set all to 0 both use SetTexture
		//move down the screen with the int using ++ each grouping of GUI elements are moved using this
		#endregion
		#region Character Name and Save & Play
		charName = GUI.TextField(new Rect(0, 0, 100, 100), charName, 25);
		if (GUI.Button(new Rect(100, 0, 100, 100), "Save & Play")) {
			Save();
			SceneManager.LoadScene(2);
		}
	//name of our character equals a GUI TextField that holds our character name and limit of characters
	//move down the screen with the int using ++ each grouping of GUI elements are moved using this

	//GUI Button called Save and Play
	//this button will run the save function and also load into the game level
	#endregion
	}
	#endregion
	void ChooseClass(int className) {
		switch(className) {
			case 0:
				charClass = CharacterClass.Knight;
				stats[0] = 15; // VIT
				stats[1] = 8;  // END
				stats[2] = 12; // RES
				stats[3] = 15; // STR
				stats[4] = 8;  // SPD
				stats[5] = 5;  // MAG
				break;
			case 1:
				charClass = CharacterClass.Archer;
				stats[0] = 10; // VIT
				stats[1] = 15; // END
				stats[2] = 10; // RES
				stats[3] = 8;  // STR
				stats[4] = 15; // SPD
				stats[5] = 5;  // MAG
				break;
			case 2:
				charClass = CharacterClass.Mage;
				stats[0] = 8;  // VIT
				stats[1] = 15; // END
				stats[2] = 8;  // RES
				stats[3] = 5;  // STR
				stats[4] = 15; // SPD
				stats[5] = 15; // MAG
				break;
		}
	}
	
}

public enum CharacterClass {
	Knight,
	Archer,
	Mage
};