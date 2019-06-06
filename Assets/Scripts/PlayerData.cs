using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour {

	public int indexSkin;
	public int indexHair;
	public int indexMouth;
	public int indexEyes;
	public string charName;

	public PlayerData(Player player) {
		indexSkin  = player.indexSkin;
		indexHair  = player.indexHair;
		indexMouth = player.indexMouth;
		indexEyes  = player.indexEyes;
		charName = player.charName;
	}
}
