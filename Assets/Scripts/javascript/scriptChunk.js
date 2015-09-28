#pragma strict

//publics//
var asteroidSpeed: float = 6.0;
var horizMin : float = -6;			//left most barrier of the game
var horizMax : float = 6;
var explosion : Transform;		
var hitPlayer : AudioClip;
var hitShield : AudioClip;
var health : float = 1;
var vec : Vector3;
var cash : float = 1.0;
var gravitationalPull : boolean = false;
var inventory : GameObject;	




//privates///
private var initHealth : float;
private var holePosition : Vector3;


function Start () {

	transform.position.y = Random.Range(transform.parent.position.y - 1, transform.parent.position.y + 1);
	transform.position.x = Random.Range(transform.parent.position.x - 1, transform.parent.position.x + 1);
	initHealth = health;

}

function Update () {

	transform.Translate(Vector3.down * asteroidSpeed * Time.deltaTime);
	if(transform.position.y < -21)
	{
		Destroy(gameObject);
	}
	
	if(gravitationalPull)
	{
		transform.position = Vector3.MoveTowards(transform.position, holePosition, Time.deltaTime * 10);
		gravitationalPull = false;
	}

}

function OnTriggerEnter(other: Collider)
{
	if(other.gameObject.tag == "Player"|| other.gameObject.tag == "collector")
	{
	//	inventory.GetComponent(Inventory).addScore(1);
		GetComponent.<AudioSource>().clip = hitShield;
		GetComponent.<AudioSource>().Play();
		Destroy(gameObject);
	}
	
}

function OnTriggerStay(other: Collider)
{
	if(other.gameObject.tag == "magnet")
	{
		holePosition = other.transform.position;
		gravitationalPull = true;
	}
}
