#pragma strict
//Player Script


//Inspectore Variables
var bulletSpeed : float = 15.0;
var bulletRange : float = 10.0;
var horizMin : float = -12;			//left most barrier of the game
var horizMax : float = 12;
var explosion : Transform;	
var mineExplosion : Transform;	
var voidMineExplosion : Transform;	
var sceneManager : GameObject;	
var fxSound: AudioClip;
var volume : float = 0.1;

//Private Variables



function Start () {

}

//Game Loop

function Update () 
{

}

function OnTriggerEnter(other: Collider)
{
	if(other.gameObject.tag == "asteroid")
	{
		
		other.GetComponent(scriptEnemy).health -= 3;
		Instantiate(voidMineExplosion, transform.position, transform.rotation);
		
		
		if(other.GetComponent(scriptEnemy).health <= 0)
		{
			other.GetComponent(scriptEnemy).resetEnemy();
			Instantiate(explosion, transform.position, transform.rotation);
			GetComponent.<AudioSource>().PlayClipAtPoint(fxSound, transform.position, volume);
		}
		
		Destroy(gameObject);
		
	}

	
	
}