using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invent : MonoBehaviour {
	public int slotX, slotY;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	public KeyCode InvButton;
	public GUISkin skin;
	private ItemDataBase database;
	private bool showInventory = true;
	private bool showToolTip = false;
	private string toolTip;
	private bool draggingItem = false;
	private Item draggedItem;
	public Transform turretMesh;
	public Transform turretMesh2;
	public Transform magnetMesh;
	public Transform magnetMesh2;
	public Transform mineMesh;
	public Transform mineMesh2;
	public Transform shieldMesh;
	public GameObject player;
	static float score = 0;

	void Start () {
		for(int i = 0; i < (slotX * slotY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDataBase> ();
		addItem (0);
		addItem (1);
		addItem (2);
		addItem (3);
		addItem (4);
		addItem (5);
		addItem (6);
		addItem (7);
		addItem (8);
		addItem (9);
		addItem (10);
	}

	void Update()
	{
		if (Input.GetKeyDown(InvButton))
		{
			showInventory = !showInventory;
		}
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		toolTip = "";
		GUI.skin = skin;
		if(showInventory)
		{
			drawInventory();

			if(showToolTip)
			{
				GUI.Box(new Rect(Event.current.mousePosition.x - 240, Event.current.mousePosition.y - 20, 200, 100), toolTip, skin.GetStyle ("toolTip"));
			}

			if(draggingItem)
			{
				GUI.DrawTexture(new Rect(Event.current.mousePosition.x - 20, Event.current.mousePosition.y - 20, 30, 30), draggedItem.itemIcon);
			}

		}

	}

	void drawInventory()
	{
		Rect slotRectBG = new Rect (Screen.width - 80, 40, 90, 600);
		GUI.Box (slotRectBG, "     Shop\n\n" + "Cash: $" + score, skin.GetStyle ("slotBG"));
		Event e = Event.current;
		int i = 0;
		for (int y = 0; y < slotY; y++) {
			for (int x = 0; x < slotX; x++) {
				Rect slotRect = new Rect (Screen.width - 50, (110) +  y * 40, 30, 30);
				Rect iconRect = new Rect (Screen.width - 47, (112) +  y * 40, 25, 22);
				GUI.Box (slotRect, "", skin.GetStyle ("slot"));
				slots [i] = inventory [i];
				if (slots [i].itemName != null) {
					GUI.DrawTexture (iconRect, slots [i].itemIcon);
					if(slotRect.Contains (e.mousePosition))
					    {
							toolTip = createToolTip(slots[i]);
							showToolTip = true;
							if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
							{
								draggingItem = true;
								draggedItem = slots[i];
							}

						}

					if(toolTip == "")
					{
						showToolTip = false;
					}
				}
				i++;
			}
		}

		if(e.type == EventType.mouseUp && draggingItem == true)
		{

			float posX = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)).x;
			float posY = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)).y;

			draggingItem = false;
			Vector3 vec = new Vector3(posX, posY, 0);
			Quaternion rot = new Quaternion(0,0,0, 0);
			if(draggedItem.itemID == 0 )
			{
				GameObject play = GameObject.Find("newPlayer");
				Transform clone = Instantiate(shieldMesh, play.transform.position, play.transform.rotation ) as Transform;
				clone.transform.parent = play.transform;
			}

			if(draggedItem.itemID == 1  && draggedItem.itemPrice <= score)
			{
				Instantiate(mineMesh, vec, rot );
				score -= draggedItem.itemPrice;
				
			}

			if(draggedItem.itemID == 2 && draggedItem.itemPrice <= score)
			{
				Instantiate(mineMesh2, vec, rot );
				score -= draggedItem.itemPrice;
			}

			if(draggedItem.itemID == 3 && draggedItem.itemPrice <= score)
			{
				Instantiate(turretMesh, vec, rot );
				score -= draggedItem.itemPrice;
			}

			if(draggedItem.itemID == 4 && draggedItem.itemPrice <= score)
			{
				Instantiate(turretMesh2, vec, rot );
				score -= draggedItem.itemPrice;
			}

			if(draggedItem.itemID == 5 && draggedItem.itemPrice <= score)
			{
				Instantiate(magnetMesh, vec, rot );
				score -= draggedItem.itemPrice;
			}

			if(draggedItem.itemID == 6 && draggedItem.itemPrice <= score)
			{
				Instantiate(magnetMesh2, vec, rot );
				score -= draggedItem.itemPrice;
			}

			if(draggedItem.itemID == 7 && draggedItem.itemPrice <= score && Globals.upgrade  == 0)
			{ 
				score -= draggedItem.itemPrice;
				Globals.upgrade++;
			}

			if(draggedItem.itemID == 8 && draggedItem.itemPrice <= score && Globals.upgrade  == 1)
			{
				score -= draggedItem.itemPrice;
				Globals.upgrade++;
			}

			if(draggedItem.itemID == 9 && draggedItem.itemPrice <= score && Globals.upgrade  == 2)
			{
				score -= draggedItem.itemPrice;
				Globals.upgrade++;				
			}

			if(draggedItem.itemID == 10 && draggedItem.itemPrice <= score && Globals.upgrade  == 3)
			{
				score -= draggedItem.itemPrice;
				Globals.upgrade++;				
			}
		}

	}

	string createToolTip(Item item)
	{
		toolTip = "<color=#ffffff>" + item.itemName + "</color>\n\n";

		toolTip += "<color=#aaaaaa>" + item.itemDesc + "</color>\n\n";
		toolTip += "<color=#ffd700>" + "$" +  item.itemPrice + "</color>";
		return toolTip;
	}

	void addItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemName == null)
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						//print (id + " " + database.items[j].itemName);
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}

	}

	void removeItem(int id)
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			inventory[i] = new Item();
			break;
		}
	}

	public void addScore(float cash)
	{
		score += cash;
		print("money money");
	}
		
	bool inventoryContains(int id)
	{
		bool result = false;
		for (int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemID == id)
			{
				result = true;
				break;
			}
		}
		return result;
	}

}
