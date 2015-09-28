#pragma strict
//Player Script


//Inspectore Variables

var horizontalSpeed : float = 10.0;	//speed the player can move left and right
var verticalSpeed : float = 10.0;	//speed the player can move up and down
var horizMin : float = -6;			//left most barrier of the game
var horizMax : float = 6;			//right most barrier of the game
var vertMin : float = -3.5;			//botton barrier of the game
var vertMax : float = 5.5;			//top barrier of the game
var bullet : Transform;
var mine : Transform;
var voidMine : Transform;
var gun : Transform;
var sideGunL : Transform;
var sideGunR : Transform;
var jetFX : Transform;	
var lives : int = 3;
static var numOfShields : int = 1;
static var numOfTurrets : int = 0;
static var numOfMines : int = 2;
static var upgrade : int = 0;
var shieldMesh : Transform;
var turretMesh : Transform;
var shieldInput : KeyCode;
var turretInput : KeyCode;
var mineInput : KeyCode;
var pauseInput : KeyCode;
var leftInput : KeyCode;
var jetInput : KeyCode;
var canShoot : boolean = true;
var canShootLeft  : boolean = true;
var canShootRight : boolean = true;
var canSideShootLeft  : boolean = true;
var canSideShootRight : boolean = true;

//Private Variables
var shieldOn : boolean = false;
static var rateOfFire : float = 0.2;
static var rateOfFireLeft : float = 0.2;
static var rateOfFireRight : float = 0.2;

//Constructor
function Start () {

}

function Update () 
{
	//Allows the user to move left, right, up and down
	var tranH: float = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
	var tranV: float = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
	transform.Translate(tranH, tranV, 0);
	
	//applies barrier of were the plare can go, up, down, left and right
	transform.position.x = Mathf.Clamp(transform.position.x, horizMin, horizMax);
	transform.position.y = Mathf.Clamp(transform.position.y, vertMin, vertMax);
	
	playerInput();
	
	if(transform.FindChild("prefabShield(Clone)") == null)
	{
		shieldOn = false;
	}
	else
	{
		shieldOn = true;
	}
	
	if(upgrade == 1 )
	{
		rateOfFire = 0.1;
	}
	
	if(upgrade == 3 )
	{
		rateOfFireLeft = 0.1;
	}
	
	if(upgrade == 3 )
	{
		rateOfFireRight = 0.1;
	}
	
	
}

function incShields()
{
	numOfShields++;
}

function shoot()
{
	if(canShoot)
	{
		Instantiate(bullet, gun.position, gun.rotation );
		canShoot = false;
		yield WaitForSeconds(rateOfFire);
		canShoot = true;
		GetComponent.<AudioSource>().Play();
	}
}

function shootL()
{
	if(canShootLeft)
	{
		Instantiate(bullet, sideGunL.position, sideGunL.rotation );
		canShootLeft = false;
		yield WaitForSeconds(rateOfFireLeft);
		canShootLeft = true;
		GetComponent.<AudioSource>().Play();
	}
}

function shootR()
{
	if(canShootRight)
	{
		Instantiate(bullet, sideGunR.position, sideGunR.rotation );
		canShootRight = false;
		yield WaitForSeconds(rateOfFireRight);
		canShootRight = true;
		GetComponent.<AudioSource>().Play();
	}
}

function sideShootL()
{
	if(canSideShootLeft)
	{
		var clone = Instantiate(bullet, sideGunL.position, sideGunL.rotation );
		clone.gameObject.GetComponent(scriptBullet).vec = Vector3.left;
		canSideShootLeft = false;
		yield WaitForSeconds(rateOfFireLeft);
		canSideShootLeft = true;
		GetComponent.<AudioSource>().Play();
	}
}

function sideShootR()
{
	if(canSideShootRight)
	{
		var clone = Instantiate(bullet, sideGunR.position, sideGunR.rotation );
		clone.gameObject.GetComponent(scriptBullet).vec = Vector3.right;
		canSideShootRight = false;
		yield WaitForSeconds(rateOfFireRight);
		canSideShootRight = true;
		GetComponent.<AudioSource>().Play();
	}
}



function shoot2()
{
	shoot();
	shootR();
 	shootL();
	print(upgrade);
}

function shoot3()
{
	shoot();
 	shootR();
 	shootL();
 	sideShootL();
	sideShootR();
}

function playerInput()
{

	if(Input.GetKey("space"))
	{
		if(upgrade == 0)
		{
			shoot();
		}
		else if(upgrade == 1)
		{
			shoot();
		}
		else if(upgrade == 2)
		{
			shoot2();
		}
		else if(upgrade == 3)
		{
			shoot2();
		}
		else if(upgrade == 4)
		{
			shoot3();	
		}		
	}
	
	if(Input.GetKeyDown(mineInput))
	{
		if(numOfMines > 0)
		{
			Instantiate(mine, gun.position, gun.rotation );
			GetComponent.<AudioSource>().Play();
			numOfMines--;
		}
	}
	
	
	
	if(Input.GetKeyDown(shieldInput))
	{
		if(!shieldOn && numOfShields > 0)
		{
			var clone = Instantiate(shieldMesh, transform.position, transform.rotation );
			clone.transform.parent = gameObject.transform;
			numOfShields--;
		}
	}
	
	if(Input.GetKeyDown(turretInput))
	{
		if(numOfTurrets > 0)
		{
			var clone2 = Instantiate(turretMesh, transform.position, transform.rotation );
			numOfTurrets--;
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


function jet()
{	
	horizontalSpeed *= 2;
}

function jetDown()
{
	horizontalSpeed /= 2;
}
