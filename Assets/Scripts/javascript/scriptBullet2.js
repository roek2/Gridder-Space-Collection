

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
var hitPlayer : AudioClip;
var hitShield : AudioClip;

//Private Variables



function Start () {
print("wake up");

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
			sceneManager.GetComponent(scriptSceneManager).addScore(other.GetComponent(scriptEnemy).cash);
		}
		
		Destroy(gameObject);
		
	}
	
	if(other.gameObject.tag == "Player")
	{
		print("i hit the player");
		other.GetComponent(scriptPlayer).lives--;
		Destroy(gameObject);
		
	}
	
	else if(other.gameObject.tag == "shield")
	{
		print("i hit the shield");
		Destroy(gameObject);
	}
	
	else if(other.gameObject.tag == "turret")
	{
		GetComponent.<AudioSource>().clip = hitPlayer;
		GetComponent.<AudioSource>().Play();
		Destroy(gameObject);
	}
	
	
}