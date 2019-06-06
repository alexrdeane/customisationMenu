using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
using UnityEngine.SceneManagement;
public class CustomisationGet : MonoBehaviour {

	[Header("Character")]
	//public variable for the Skinned Mesh Renderer which is our character reference
	public Renderer character;

	#region Start
	void Start() {
		//our character reference connected to the Skinned Mesh Renderer via finding the Mesh
		character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();
		//Run the function LoadTexture	

	}
	#endregion

	#region LoadTexture Function
	//PlayerData data = SaveSystem.LoadPlayer();
	//indices[0] = data.indexEyes;
	//	indices[1] = data.indexHair;
	//	indices[2] = data.indexMouth;
	//	indices[3] = data.indexSkin;
	//	charName = data.charName;
	//check to see if our save file for this character
	//if it doesnt then load the CustomSet level
	//if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs
	//grab the gameObject in scene that is our character and set its Object name to the Characters name
	#endregion
	#region SetTexture

	//Create a function that is called SetTexture it should contain a string and int
	//the string is the name of the material we are editing, the int is the direction we are changing
	void SetTexture(string type, int index) {

		//we need variables that exist only within this function
		//these are int material index and Texture2D array of textures
		Texture2D tex = null;
		int matIndex = 0;
		//inside a switch statement that is swapped by the string name of our material
		switch (type) {
			//case skin      
			case "Skin":
				//textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
				tex = (Texture2D)Resources.Load("Character/Skin_" + index);
				//material index element number is 1
				matIndex = 1;
				//break
				break;
			//now repeat for each material 
			case "Hair":
				tex = (Texture2D)Resources.Load("Character/Hair_" + index);
				//hair is 2
				matIndex = 2;
				break;
			case "Mouth":
				tex = (Texture2D)Resources.Load("Character/Mouth_" + index);
				//mouth is 3
				matIndex = 3;
				break;
			case "Eyes":
				tex = (Texture2D)Resources.Load("Character/Eyes_" + index);
				//eyes are 4
				matIndex = 4;
				break;
		}

		//Material array is equal to our characters material list
		Material[] mats = character.materials;
		//our material arrays current material index's main texture is equal to our texture arrays current index
		mats[matIndex].mainTexture = tex;
		//our characters materials are equal to the material array
		character.materials = mats;
	}
	#endregion
}
