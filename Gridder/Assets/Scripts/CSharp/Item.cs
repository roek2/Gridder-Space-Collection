using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemPrice;
	public ItemType itemType;

	public enum ItemType
	{
		Weapon,
		Consumable
	}

	public Item (string name, int id, string desc, int price, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D> ("Item_icons/" + name);
		itemPrice = price;
		itemType = type;
	}

	public Item()
	{
	}
}
