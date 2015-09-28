#pragma strict
//Player Script


//Inspectore Variables
var bulletSpeed : float = 15.0;
var bulletRange : float = 10.0;
var horizMin : float = -12;			//left most barrier of the game
var horizMax : float = 12;
var explosion : Transform;	
var sceneManager : GameObject;	
var fxSound: AudioClip;
var volume : float = 0.1;
var vec : Vector3 = Vector3.up;

//Private Variables



function Start () {

}

//Game Loop

function Update () {

	transform.Translate(vec * (bulletSpeed * Time.deltaTime));
	if(transform.position.y > bulletRange)
	{
		Destroy(gameObject);
	}

}

function OnTriggerEnter(other: Collider)
{
	if(other.gameObject.tag == "asteroid")
	{
		if(--other.GetComponent(scriptEnemy).health <= 0)
		{
			other.GetComponent(scriptEnemy).resetEnemy();
			Instantiate(explosion, transform.position, transform.rotation);
			GetComponent.<AudioSource>().PlayClipAtPoint(fxSound, transform.position, volume);
		}
		
		Destroy(gameObject);
		
	}
	
	if(other.gameObject.tag == "ship")
	{
		if(--other.GetComponent(scriptEnemyShip).health <= 0)
		{
			other.GetComponent(scriptEnemyShip).resetEnemy();
			Instantiate(explosion, transform.position, transform.rotation);
			GetComponent.<AudioSource>().PlayClipAtPoint(fxSound, transform.position, volume);
		}
		
		Destroy(gameObject);
		
	}
	
	
}