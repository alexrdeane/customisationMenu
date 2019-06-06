using UnityEngine;

public static class ItemData {
	
	public static Item CreateItem(int itemID) {
		string name = "";
		int value = 0;
		string desc = "";
		string icon = "";
		string mesh = "";
		ItemType type = ItemType.Material;
		int heal = 0;
		int damage = 0;
		int armor = 0;
		int amount = 0;

		switch (itemID) {
			#region Food 0-99
			case 0:
				name = "Meat";
				value = 15;
				desc = "Meat from mountain boars";
				icon = "Meat_Icon";
				mesh = "Meat_Mesh";
				type = ItemType.Food;
				heal = 20;
				amount = 1;
				break;
			case 1:
				name = "Chicken";
				value = 10;
				desc = "Chicken from mountain hens";
				icon = "Chicken_Icon";
				mesh = "Chicken_Mesh";
				type = ItemType.Food;
				heal = 15;
				amount = 1;
				break;
			case 2:
				name = "Bread";
				value = 2;
				desc = "Bread made from mountain wheat";
				icon = "Bread_Icon";
				mesh = "Bread_Mesh";
				type = ItemType.Food;
				heal = 2;
				amount = 1;
				break;
			#endregion
			#region Potion 100-199
			case 100:
				name = "Infinite Stamina Potion";
				value = 100;
				desc = "Grants infinite stamina for 5 minutes";
				icon = "InfiniteStaminaPotion_Icon";
				mesh = "InfiniteStaminaPotion_Mesh";
				type = ItemType.Potion;
				heal = 0;
				amount = 1;
				break;
			case 101:
				name = "Magic Regen Potion";
				value = 40;
				desc = "Grants double mana regeneration for 6 minutes";
				icon = "MagicRegenPotion_Icon";
				mesh = "MagicRegenPotion_Mesh";
				type = ItemType.Potion;
				heal = 0;
				amount = 1;
				break;
			case 102:
				name = "Ironskin Potion";
				value = 40;
				desc = "Grants +8 Defense for 7 minutes";
				icon = "IronskinPotion_Icon";
				mesh = "IronskinPotion_Mesh";
				type = ItemType.Potion;
				heal = 0;
				amount = 1;
				break;
			#endregion
			#region Material 200-299
			case 200:
				name = "Cog";
				value = 1;
				desc = "Cog from the mountain dwarves";
				icon = "Cog_Icon";
				mesh = "Cog_Mesh";
				type = ItemType.Material;
				amount = 1;
				break;
			case 201:
				name = "Spring";
				value = 1;
				desc = "Spring from the mountain dwarves";
				icon = "Spring_Icon";
				mesh = "Spring_Mesh";
				type = ItemType.Material;
				amount = 1;
				break;
			case 202:
				name = "Acorn";
				value = 1;
				desc = "Acorn from the mountain trees";
				icon = "Acorn_Icon";
				mesh = "Acorn_Mesh";
				type = ItemType.Material;
				amount = 1;
				break;
			#endregion
			#region Apparel 300-399
			case 300:
				name = "Knight Helmet";
				value = 35;
				desc = "A basic knight helmet";
				icon = "KnightHelm_Icon";
				mesh = "KnightHelm_Mesh";
				type = ItemType.Apparel;
				armor = 10;
				amount = 1;
				break;
			case 301:
				name = "Mage Hood";
				value = 35;
				desc = "A basic mage hood";
				icon = "MageHelm_Icon";
				mesh = "MageHelm_Mesh";
				type = ItemType.Apparel;
				armor = 6;
				amount = 1;
				break;
			#endregion
			#region Weapon 400-499
			case 400:
				name = "Shortsword";
				value = 35;
				desc = "A basic shortsword";
				icon = "Shortsword_Icon";
				mesh = "Shortsword_Mesh";
				type = ItemType.Weapon;
				damage = 15;
				amount = 1;
				break;
			case 401:
				name = "Longsword";
				value = 60;
				desc = "A basic longsword";
				icon = "Longsword_Icon";
				mesh = "Longsword_Mesh";
				type = ItemType.Weapon;
				damage = 25;
				amount = 1;
				break;
			case 402:
				name = "Battleaxe";
				value = 60;
				desc = "A basic battleaxe";
				icon = "Battleaxe_Icon";
				mesh = "Battleaxe_Mesh";
				type = ItemType.Weapon;
				damage = 30;
				amount = 1;
				break;

			#endregion
			default:
				itemID = 4;
				name = "Apple";
				value = 2;
				desc = "Crunchy apple";
				icon = "Apple_Icon";
				mesh = "Apple_Mesh";
				type = ItemType.Food;
				heal = 5;
				amount = 1;
				break;
		}

		Item temp = new Item {

			Name = name,
			Desc = desc,
			ID = itemID,
			Value = value,
			Damage = damage,
			Armor = armor,
			Amount = amount,
			Heal = heal,
			Type = type,
			Mesh = (GameObject)Resources.Load("Prefabs/" + mesh),
			Icon = (Texture2D)Resources.Load("Icon/" + icon)

		};
		return temp;
	}
}
