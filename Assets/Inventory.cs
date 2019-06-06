using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Variables
	public static List<Item> inv = new List<Item>();
	public static bool showInv;
	public Item selectedItem;
	public static int money;

	public Vector2 scr;
	public Vector2 scrollPos;

	public string[] sortType = new string[7];
	public int index;
	public string sortingType = "All";

	public Transform dropLocation;
	public Transform[] equippedLocation;

	public GameObject curWeapon;
	public GameObject curHelm;

	public Player player;
	#endregion

	void Start() {
		sortType = new string[] { "All", "Food", "Potion", "Weapon", "Apparel", "Material" };
		inv.Add(ItemData.CreateItem(0));
		inv.Add(ItemData.CreateItem(100));
		inv.Add(ItemData.CreateItem(200));
		inv.Add(ItemData.CreateItem(300));
		inv.Add(ItemData.CreateItem(400));
		inv.Add(ItemData.CreateItem(401));
		inv.Add(ItemData.CreateItem(402));
		for (int i = 0; i < inv.Count; i++) {
		}
	}
	public bool ToggleInv() {
		if (showInv) {
			showInv = false;
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			Movement.canMove = true;
			return false;
		} else {
			if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9) {
				scr.x = Screen.width / 16;
				scr.y = Screen.height / 9;
			}
			showInv = true;
			Time.timeScale = 0.01f; ;
			Cursor.lockState = CursorLockMode.None;
			Movement.canMove = false;
			return true;
		}
	}
	void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			ToggleInv();
		}
	}
	void DisplayInv(string sortType) {
		if (!(sortType == "All" || sortType == "")) {

			#region Types

			ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
			int a = 0;
			int s = 0;
			for (int i = 0; i < inv.Count; i++) {
				if (inv[i].Type == type) {
					a++;
				}
			}
			if (a <= 35) {
				for (int i = 0; i < inv.Count; i++) {
					if (inv[i].Type == type) {
						if (GUI.Button(new Rect(0.5f*scr.x, 0.25f*scr.y + s*(0.25f*scr.y), 3f*scr.x, 0.25f * scr.y), inv[i].Name)) {
							selectedItem = inv[i];
						}
						s++;
					}
				}
			} else {
				scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f* scr.y, 3.5f*scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f*scr.y + (a-34)), false, true);
				for (int i = 0; i < inv.Count; i++) {
					if (inv[i].Type == type) {
						if (GUI.Button(new Rect(0, 0, 3f * scr.x, 0.25f * scr.y), inv[i].Name)) {
							selectedItem = inv[i];
						}
						s++;
					}
				}
				GUI.EndScrollView();

			}
			#endregion
		} else {
			if (inv.Count <= 34) {
				for (int i = 0; i < inv.Count; i++) {
					if (GUI.Button(new Rect (0.5f*scr.x, 0.25f*scr.y+i*0.25f*scr.y, 3*scr.x, 0.25f*scr.y), inv[i].Name)) {
						selectedItem = inv[i];
					}
				}
			} else {
				scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + (inv.Count - 34)), false, true);
				for (int i = 0; i < inv.Count; i++) {
					if (GUI.Button(new Rect(0, 0, 3f * scr.x, 0.25f * scr.y), inv[i].Name)) {
						selectedItem = inv[i];
					}
				}
				GUI.EndScrollView();
			}
		}
	}
	void DisplayItem() {
		switch (selectedItem.Type) {
			case ItemType.Food:
				GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Desc + "\nValue:" + selectedItem.Value + "\nHeals:" + selectedItem.Heal + "\nAmount:" + selectedItem.Amount);
				if (player.health < player.maxHealth) {
					if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat")) {
						player.health += selectedItem.Heal;
						DepleteAmount();
					}
				}
				if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard")) {
					Discard();
				}
				break;
			case ItemType.Potion:
				GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Desc + "\nValue:" + selectedItem.Value + "\nHeals:" + selectedItem.Heal + "\nAmount:" + selectedItem.Amount);
				if (player.health < player.maxHealth) {
					if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Drink")) {
						player.health += selectedItem.Heal;
						DepleteAmount();
					}
				}
				if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard")) {
					Discard();
				}
				break;
			case ItemType.Material:
				GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Desc + "\nValue:" + selectedItem.Heal + "\nAmount:" + selectedItem.Amount);
				if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard")) {
					Discard();
				}
				break;
			case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Desc + "\nValue:" + selectedItem.Heal + "\nDamage:" + selectedItem.Damage);
                if (curHelm == null || selectedItem.Mesh.name != curHelm.name)
                {
                    if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (curHelm != null)
                        {
                            Destroy(curHelm);
                        }
                        curHelm = Instantiate(selectedItem.Mesh, equippedLocation[1]);
                        curHelm.GetComponent<ItemHandler>().enabled = false;
                        curHelm.name = selectedItem.Mesh.name;
                        Rigidbody rigidbody = curHelm.GetComponent<Rigidbody>();
                        Destroy(rigidbody);
                    }
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard")) {
					if (curHelm != null && selectedItem.Mesh.name == curHelm.name) {
						Destroy(curHelm);
					}
					Discard();
				}
				break;
			case ItemType.Weapon:
				GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Desc + "\nValue:" + selectedItem.Heal + "\nDamage:" + selectedItem.Damage);
				if (curWeapon == null || selectedItem.Mesh.name != curWeapon.name) {
					if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip")) {
						if (curWeapon != null) {
							Destroy(curWeapon);
						}
						curWeapon = Instantiate(selectedItem.Mesh, equippedLocation[0]);
						curWeapon.GetComponent<ItemHandler>().enabled = false;
						curWeapon.name = selectedItem.Mesh.name;

					}
				}
				if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard")) {
					if (curWeapon != null && selectedItem.Mesh.name == curWeapon.name) {
						Destroy(curWeapon);
					}
					Discard();
				}
				break;
		}
	}
	void DepleteAmount() {
		if (selectedItem.Amount > 1) {
			selectedItem.Amount--;
		} else {
			inv.Remove(selectedItem);
			selectedItem = null;
		} return;
	}
	void Discard() {
		GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
		clone.AddComponent<Rigidbody>().useGravity = true;
		DepleteAmount();
	}
	void OnGUI() {
		if (showInv) {
			GUI.Box(new Rect(0, 0, scr.x, scr.y), "Inventory");
			for (int i = 0; i < sortType.Length; i++) {
				if (GUI.Button(new Rect(5.5f*scr.x + i*scr.x, 0.25f*scr.y, scr.x, 0.25f*scr.y), sortType[i])) {
					sortingType = sortType[i];
				}
			}
			DisplayInv(sortingType);
			if (selectedItem != null) {
				GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
				DisplayItem();

			}

		}

	}
}
