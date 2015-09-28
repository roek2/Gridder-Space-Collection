using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start()
	{
		items.Add(new Item("Shield", 0, "Drag and Drop to create shield", 5, Item.ItemType.Consumable));
		items.Add(new Item("Mine", 1, "Proximety mie destroys enemies", 5, Item.ItemType.Weapon));
		items.Add(new Item("Void Mine", 2, "Pulls enemies towards it", 5, Item.ItemType.Weapon));
		items.Add(new Item("turret", 3, "Helpful Automated gun", 5, Item.ItemType.Weapon));
		items.Add(new Item("turret2", 4, "Bigger Helpful Automated gun", 5, Item.ItemType.Weapon));
		items.Add(new Item("Magnet", 5, "Collects gold from asteroids", 5, Item.ItemType.Weapon));
		items.Add(new Item("Magnet2", 6, "Collects more gold from asteroids", 5, Item.ItemType.Weapon));
		items.Add(new Item("Upgrade1", 7, "Drag to upgrade player gun", 5, Item.ItemType.Consumable));
		items.Add(new Item("Upgrade2", 8, "Drag to upgrade player gun more", 5, Item.ItemType.Consumable));
		items.Add (new Item ("Upgrade3", 9, ".....and more", 5, Item.ItemType.Consumable));
		items.Add (new Item ("Upgrade4", 10, "....and even more", 5, Item.ItemType.Consumable));
	}
}
