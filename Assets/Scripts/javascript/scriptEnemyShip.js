#pragma strict

//publics//
var asteroidSpeed: float = 6.0;
var horizMin : float = -6;			//left most barrier of the game
var horizMax : float = 6;
var explosion : Transform;	
var bullet : Transform;	
var hitPlayer : AudioClip;
var hitShield : AudioClip;
var health : float = 1;
var vec : Vector3;
var cash : float = 1.0;
var gravitationalPull : boolean = false;
var randomPoint : Vector3;
var randomPoint2 : Vector3;
var randomPoint3 : Vector3;
var speed : float = 10;
var rateOfFire : float = 0.4;


//privates///
private var initHealth : float;
private var holePosition : Vector3;


function Start () {

	transform.position.y = 15;
	transform.position.x = Random.Range(horizMin, horizMax);
	initHealth = health;
	randomPoint = Vector3(Random.Range(horizMin, horizMax),Random.Range(-2, 3),0);
	InvokeRepeating("move", 1, 3);
	InvokeRepeating("shoot", 1, rateOfFire);

}

function Update () {
	
	transform.position = Vector3.MoveTowards(transform.position, randomPoint, Time.deltaTime * speed);	
}

function move ()
{
	if(transform.position == randomPoint)
	{
		randomPoint = Vector3(Random.Range(horizMin, horizMax),Random.Range(-4, 4),0);
	}
}

function shoot ()
{
	var clone = Instantiate(bullet, transform.position, transform.rotation );
	var player = GameObject.FindGameObjectWithTag("Player");
	clone.gameObject.GetComponent(scriptBullet2).vec = (player.transform.position - clone.position).normalized;
	clone.gameObject.GetComponent(scriptBullet2).bulletSpeed = 10;	
	print("player.position: " + player.transform.position);
}

function OnTriggerEnter(other: Collider)
{
	if(other.gameObject.tag == "Player")
	{
		other.GetComponent(scriptPlayer).lives--;
		Instantiate(explosion, transform.position, transform.rotation);
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
	transform.position.y = 15;
	transform.position.x = Random.Range(horizMin, horizMax);
	health = initHealth;
}