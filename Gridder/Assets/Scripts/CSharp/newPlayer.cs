using UnityEngine;
using System.Collections;

public static class Globals
{
	public static int upgrade = 0; // Modifiable in Code
}

public class newPlayer : MonoBehaviour {
	
	public float horizontalSpeed = 10.0f;	//speed the player can move left and right
	public float verticalSpeed = 10.0f;	//speed the player can move up and down
	public float horizMin = -6;			//left most barrier of the game
	public float horizMax = 6;			//right most barrier of the game
	public float vertMin = -3.5f;			//botton barrier of the game
	public float vertMax = 5.5f;			//top barrier of the game
	public Transform bullet;
	public Transform mine ;
	public Transform voidMine;
	public Transform gun ;
	public Transform sideGunL ;
	public Transform sideGunR ;
	public Transform jetFX;	
	public int lives = 3;
	static int numOfShields = 1;
	public Transform shieldMesh;
	public Transform turretMesh;
	public KeyCode shieldInput;
	public KeyCode pauseInput;
	public KeyCode leftInput;
	public KeyCode jetInput;
	public bool canShoot = true;
	public bool canShootLeft = true;
	public bool canShootRight = true;
	public bool canSideShootLeft = true;
	public bool canSideShootRight = true;
	
	//Private Variables
	bool shieldOn = false;
	static float rateOfFire = 0.2f;
	static float rateOfFireLeft = 0.2f;
	static float rateOfFireRight = 0.2f;
	
	//Constructor
	void Start () {
		
	}
	
	void Update () 
	{
		//Allows the user to move left, right, up and down
		float tranH = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
		float tranV = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
		transform.Translate(tranH, tranV, 0);

		gameObject.transform.position = new Vector3 (Mathf.Clamp (gameObject.transform.position.x, horizMin, horizMax), Mathf.Clamp (gameObject.transform.position.y, vertMin, vertMax), 0);

		playerInput();
		
		if(transform.FindChild("prefabShield(Clone)") == null)
		{
			shieldOn = false;
		}
		else
		{
			shieldOn = true;
		}
		
		if(Globals.upgrade == 1 )
		{
			rateOfFire = 0.1f;
		}
		
		if(Globals.upgrade == 3 )
		{
			rateOfFireLeft = 0.1f;
		}
		
		if(Globals.upgrade == 3 )
		{
			rateOfFireRight = 0.1f;
		}
		
		
	}
	
	void incShields()
	{
		numOfShields++;
	}
	
	IEnumerator shoot()
	{
		if(canShoot)
		{
			Instantiate(bullet, gun.position, gun.rotation );
			canShoot = false;
			yield return new WaitForSeconds(rateOfFire);
			canShoot = true;
			GetComponent<AudioSource>().Play();
		}
	}
	
	IEnumerator shootL()
	{
		if(canShootLeft)
		{
			Instantiate(bullet, sideGunL.position, sideGunL.rotation );
			canShootLeft = false;
			yield return new WaitForSeconds(rateOfFireLeft);
			canShootLeft = true;
			GetComponent<AudioSource>().Play();
		}
	}
	
	IEnumerator shootR()
	{
		if(canShootRight)
		{
			Instantiate(bullet, sideGunR.position, sideGunR.rotation );
			canShootRight = false;
			yield return new WaitForSeconds(rateOfFireRight);
			canShootRight = true;
			GetComponent<AudioSource>().Play();
		}
	}
	
	IEnumerator sideShootL()
	{
		if(canSideShootLeft)
		{
			GameObject clone = Instantiate(bullet, sideGunL.position, sideGunL.rotation ) as GameObject;
			clone.GetComponent<newBullet>().vec = Vector3.left;
			canSideShootLeft = false;
			yield return new WaitForSeconds(rateOfFireLeft);
			canSideShootLeft = true;
			GetComponent<AudioSource>().Play();
		}
	}
	
	IEnumerator sideShootR()
	{
		if(canSideShootRight)
		{
			GameObject clone = Instantiate(bullet, sideGunR.position, sideGunR.rotation ) as GameObject;
			clone.gameObject.GetComponent<newBullet>().vec = Vector3.right;
			canSideShootRight = false;
			yield return new WaitForSeconds(rateOfFireRight);
			canSideShootRight = true;
			GetComponent<AudioSource>().Play();
		}
	}
	
	
	
	void shoot2()
	{
		StartCoroutine(shoot());
		StartCoroutine(shootR());
		StartCoroutine(shootL());
	}
	
	void shoot3()
	{
		StartCoroutine(shoot());
		StartCoroutine(shootR());
		StartCoroutine(shootL());
		StartCoroutine(sideShootL());
		StartCoroutine(sideShootR());
	}
	
	void playerInput()
	{
		
		if(Input.GetKey("space"))
		{
			if(Globals.upgrade == 0)
			{
				StartCoroutine(shoot());
			}
			else if(Globals.upgrade == 1)
			{
				StartCoroutine(shoot());
			}
			else if(Globals.upgrade == 2)
			{
				shoot2();
			}
			else if(Globals.upgrade == 3)
			{
				shoot2();
			}
			else if(Globals.upgrade == 4)
			{
				shoot3();	
			}		
		}
		
		
		
		if(Input.GetKeyDown(shieldInput))
		{
			if(!shieldOn && numOfShields > 0)
			{
				var clone = Instantiate(shieldMesh, transform.position, transform.rotation );
			//	clone.transform.parent = gameObject.transform;
				numOfShields--;
			}
		}

		
		if(Input.GetKeyDown(jetInput))
		{
			jet();
		}
		
		else if(Input.GetKeyUp(jetInput))
		{
			jetDown();
		}
		
		
	}
	
	
	void jet()
	{	
		horizontalSpeed *= 2;
	}
	
	void jetDown()
	{
		horizontalSpeed /= 2;
	}

}
