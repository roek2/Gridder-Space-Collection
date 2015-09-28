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



//privates///
private var initHealth : float;
private var holePosition : Vector3;


function Start () {

	transform.position.y = 23;
	transform.position.x = Random.Range(horizMin, horizMax);
	initHealth = health;

}

function Update () {

	transform.Translate(Vector3.down * asteroidSpeed * Time.deltaTime);
	if(transform.position.y < -20)
	{
		resetEnemy();
	}
	
	if(gravitationalPull)
	{
		transform.position = Vector3.MoveTowards(transform.position, holePosition, Time.deltaTime * 10);
		gravitationalPull = false;
	}
	
	if(health <= 0)
	{
		health = initHealth;
		Instantiate(explosion, transform.position, transform.rotation);
		resetEnemy();
	}

}

function OnTriggerEnter(other: Collider)
{
	if(other.gameObject.tag == "Player")
	{
		other.GetComponent(scriptPlayer).lives--;
		health -= 3;
		GetComponent.<AudioSource>().clip = hitPlayer;
		GetComponent.<AudioSource>().Play();
	}
	
	else if(other.gameObject.tag == "shield")
	{
		health -= 3;
		GetComponent.<AudioSource>().clip = hitShield;
		GetComponent.<AudioSource>().Play();
	}
	
	else if(other.gameObject.tag == "turret")
	{
		health -= 3;
		GetComponent.<AudioSource>().clip = hitPlayer;
		GetComponent.<AudioSource>().Play();
	}
	
	else if(other.gameObject.tag == "collector")
	{
		health -= 3;
		GetComponent.<AudioSource>().clip = hitPlayer;
		GetComponent.<AudioSource>().Play();
	}
	
}

function OnTriggerStay(other: Collider)
{
	if(other.gameObject.tag == "hole")
	{
		holePosition = other.transform.position;
		gravitationalPull = true;
	}
}


function resetEnemy()
{
	//transform.position.y = 23;
	//transform.position.x = Random.Range(horizMin, horizMax);
	//health = initHealth;
	Destroy(gameObject);
}