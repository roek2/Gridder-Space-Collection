using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	private bool holding;
	public GameObject[] Objects;
	public int[] ObjectInventory;
	public bool canDrop;

	private GameObject CurrentObject;
	private Vector3 heldRotation;
	[HideInInspector]
	public int objectIndex = 0;
	public GameObject cam;
	private float camPos = 20;
	private bool gotNothing;
	public LayerMask myLayer;
	private bool ObjectPlacementCollision;
	private Vector3 objectPos;



	// Use this for initialization
	void Start () {
	

		createItem ();
		holding = true;
		CurrentObject.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		camPos = -cam.transform.position.z;
		if(holding && !gotNothing)
		{
			if(Input.GetJoystickNames().Length == 0)
				CurrentObject.transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, camPos));
			else
			{
				if(!GetComponent<Inventory>().InventoryActive)
				{
					objectPos += new Vector3(Input.GetAxis ("HorizontalR")/3, Input.GetAxis ("VerticalR")/3, 0);
					CurrentObject.transform.position = transform.position + objectPos; 
				}
				else
				{
					objectPos = new Vector3(0,2,0);
					heldRotation = new Vector3(0,0,0);
				}
			}
			CurrentObject.transform.eulerAngles = heldRotation; 
			layerCheck();

			if(Input.GetKeyDown(KeyCode.I))
			{
				objectIndex += itemCheck(-1);
				if(objectIndex < 0)
					objectIndex = Objects.Length + objectIndex;
				Destroy (CurrentObject);
				createItem();

			}
			else if(Input.GetKeyDown(KeyCode.P))
			{
				objectIndex += itemCheck(1);
				if(objectIndex > Objects.Length)
					objectIndex = Objects.Length - objectIndex;
				Destroy (CurrentObject);
				createItem();
			}


			Vector2 itemDir = new Vector2(Input.GetAxis ("HorizontalR"), Input.GetAxis ("VerticalR") );
			if(itemDir.magnitude > 0)
			{
				float rad = (Mathf.Atan2 (itemDir.x, itemDir.y)) * Mathf.Rad2Deg;
				if(rad < 0)
					rad = 360 + rad;

				float radialItemArea = 360/Objects.Length;
				for(int i = 0; i < Objects.Length; i++)
				{
					if(rad > (radialItemArea * i) - (radialItemArea/2) && rad < (radialItemArea * i) + (radialItemArea/2) && GetComponent<Inventory>().InventoryActive)
					{
						objectIndex = i;
						Destroy (CurrentObject);
						createItem();
					}
				}
			}



			if((Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Joystick1Button1)) && ObjectPlacementCollision)
			{
				deployItem();

				ObjectInventory[objectIndex]--;
				if(ObjectInventory[objectIndex] == 0)
				{
					objectIndex += itemCheck(1);
				}

				if(ObjectInventory[objectIndex] == 0)
				{
					gotNothing = true;
				}
				else
				{
					createItem();
				}
				

			}

			if(Input.GetButton("RotateL"))
				heldRotation += new Vector3(0,0,5);
			else if(Input.GetButton("RotateR"))
				heldRotation += new Vector3(0,0,-5);
		}	

		int something = 0;
		for(int i = 0; i < ObjectInventory.Length; i++)
		{
			if(ObjectInventory[i] > 0)
				something++;
		}

		if(something > 0)
		{
			if(gotNothing)
				createItem();
			gotNothing = false;
		}
		else
		{
			gotNothing = true;
		}
	}

	void layerCheck()
	{
		Vector2 pointA = new Vector2 (CurrentObject.transform.position.x - CurrentObject.transform.localScale.x, CurrentObject.transform.position.y - CurrentObject.transform.localScale.y);
		Vector2 pointB = new Vector2 (CurrentObject.transform.position.x + CurrentObject.transform.localScale.x, CurrentObject.transform.position.y + CurrentObject.transform.localScale.y);
		Color col = CurrentObject.GetComponent<SpriteRenderer> ().color;
		if(Physics2D.OverlapArea (pointA, pointB) != null)
		{
			CurrentObject.GetComponent<SpriteRenderer> ().color = new Color (col.r, 0.5f, 0.5f, col.a);
			ObjectPlacementCollision = false;
		}
		else
		{
			CurrentObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, col.a);
			ObjectPlacementCollision = true;
		}
	}

	bool rayCheck()
	{

		if(Physics.Raycast (new Vector3(CurrentObject.transform.position.x , CurrentObject.transform.position.y, CurrentObject.transform.position.z ),  (CurrentObject.transform.up * CurrentObject.GetComponent<Collider>().bounds.extents.y) + (-CurrentObject.transform.right * CurrentObject.GetComponent<Collider>().bounds.extents.x) , trig(CurrentObject.transform.localScale.x , CurrentObject.transform.localScale.y)))
		{
			print ("Hi1");
			return false;
		}

		if(Physics.Raycast (new Vector3(CurrentObject.transform.position.x , CurrentObject.transform.position.y, CurrentObject.transform.position.z ),  (-CurrentObject.transform.up * CurrentObject.GetComponent<Collider>().bounds.extents.y) + (-CurrentObject.transform.right * CurrentObject.GetComponent<Collider>().bounds.extents.x) , trig(CurrentObject.transform.localScale.x , CurrentObject.transform.localScale.y) ))
		{
			print ("Hi2");
			return false;
		}

		if(Physics.Raycast (new Vector3(CurrentObject.transform.position.x , CurrentObject.transform.position.y, CurrentObject.transform.position.z ),  (-CurrentObject.transform.up * CurrentObject.GetComponent<Collider>().bounds.extents.y) + (CurrentObject.transform.right * CurrentObject.GetComponent<Collider>().bounds.extents.x) , trig(CurrentObject.transform.localScale.x , CurrentObject.transform.localScale.y)))
		{
			print ("Hi3");
			return false;
		}

		if(Physics.Raycast (new Vector3(CurrentObject.transform.position.x , CurrentObject.transform.position.y, CurrentObject.transform.position.z ),  (CurrentObject.transform.up * CurrentObject.GetComponent<Collider>().bounds.extents.y) + (CurrentObject.transform.right * CurrentObject.GetComponent<Collider>().bounds.extents.x) , trig(CurrentObject.transform.localScale.x , CurrentObject.transform.localScale.y)))
		{
			print ("Hi4");
			return false;
		}
							
		

		if(Physics.Raycast (new Vector3(CurrentObject.transform.position.x , CurrentObject.transform.position.y, -camPos ), transform.forward, Vector3.Distance (CurrentObject.transform.position, Camera.main.transform.position),  ~(1 << 12) ))
		{
			print ("Hi5");
			return false;
		}

		return true;
	}
	
	float trig(float a, float b)
	{
		float c = Mathf.Sqrt ((a * a) + (b * b));
		return c/2;
	}
	
	bool checkPlacement(RaycastHit hit)
	{
		if(hit.collider == null)
			return true; 
		if(hit.collider != null && hit.distance >  trig(CurrentObject.transform.localScale.x , CurrentObject.transform.localScale.y))
			return true;
		
		//		print(hit.distance + ", " +  trig(CurrentObject.transform.localScale.x , CurrentObject.transform.localScale.y));
		return false;
	}

	void createItem()
	{
		CurrentObject = Instantiate (Objects[objectIndex], transform.position + new Vector3(0, 2 , 0), Quaternion.identity) as GameObject;
		CurrentObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.2f);
		CurrentObject.GetComponent<Collider2D>().enabled = false;
		if(CurrentObject.GetComponent<Rigidbody2D> () != null)
			CurrentObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
	}

	void deployItem()
	{
		Color temCol = CurrentObject.GetComponent<SpriteRenderer> ().color;
		CurrentObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		CurrentObject.GetComponent<Collider2D> ().enabled = true;
		if(CurrentObject.GetComponent<Rigidbody2D> () != null)
			CurrentObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
	}


	int itemCheck(int next)
	{
		int tempIndex = objectIndex + next;
		int startIndex = tempIndex;
		int outOfStock = 0;
		if(tempIndex < 0)
			tempIndex += ObjectInventory.Length;
		else if(tempIndex > ObjectInventory.Length - 1)
			tempIndex -= ObjectInventory.Length;

		while(ObjectInventory[tempIndex] == 0)
		{
			tempIndex = tempIndex + next;
			if(tempIndex < 0)
				tempIndex += ObjectInventory.Length;
			else if(tempIndex > ObjectInventory.Length - 1)
				tempIndex -= ObjectInventory.Length;

			outOfStock++;
			if(outOfStock == ObjectInventory.Length )
				return 0;

		}
		return tempIndex - objectIndex;
	}

}
