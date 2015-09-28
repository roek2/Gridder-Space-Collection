//publics//
var asteroidSpeed: float = 12.0;
var horizMin : float = -6;			//left most barrier of the game
var horizMax : float = 6;
var explosion : Transform;		
var hitPlayer : AudioClip;
var hitShield : AudioClip;
var health : float = 1;



//privates///
private var initHealth : float;


function Start () {

	transform.position.y = 15;
	transform.position.x = Random.Range(horizMin, horizMax);
	initHealth = health;

}

function Update () {

	transform.Translate(Vector3.down * asteroidSpeed * Time.deltaTime);
	if(transform.position.y < -12)
	{
		resetEnemy();
	}

}

function OnTriggerEnter(other: Collider)
{
	if(other.gameObject.tag == "Player")
	{
		other.GetComponent(scriptPlayer).lives--;
		Instantiate(explosion, transform.position, transform.rotation);
		resetEnemy();
		GetComponent.<AudioSource>().clip = hitPlayer;
		GetComponent.<AudioSource>().Play();
	}
	
	else if(other.gameObject.tag == "shield")
	{
		Instantiate(explosion, transform.position, transform.rotation);
		resetEnemy();
		GetComponent.<AudioSource>().clip = hitShield;
		GetComponent.<AudioSource>().Play();
	}
	
	else if(other.gameObject.tag == "turret")
	{
		Instantiate(explosion, transform.position, transform.rotation);
		resetEnemy();
		GetComponent.<AudioSource>().clip = hitPlayer;
		GetComponent.<AudioSource>().Play();
	}
}

function resetEnemy()
{
	transform.position.y = 15;
	transform.position.x = Random.Range(horizMin, horizMax);
	health = initHealth;
}