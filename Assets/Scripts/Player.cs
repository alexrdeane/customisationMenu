using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public int indexSkin;
	public int indexHair;
	public int indexMouth;
	public int indexEyes;
	public string charName;

	public float health;
	public float maxHealth;

	public void SavePlayer() {
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer() {
		PlayerData data = SaveSystem.LoadPlayer();
		indexEyes = data.indexEyes;
		indexHair = data.indexHair;
		indexMouth = data.indexMouth;
		indexSkin = data.indexSkin;
		charName = data.charName;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.F5)) {
			SavePlayer();
		}
	}
}
