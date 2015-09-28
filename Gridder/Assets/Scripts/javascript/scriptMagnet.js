#pragma strict
var gun : Transform;
var bullet : Transform;
var health : float = 3;


function Start () {



}

function Update () {

	if(health <= 0)
	{
		Destroy(gameObject);
	}	

}

function OnTriggerEnter(other: Collider)
{
	if(other.tag == "asteroid" || other.tag == "laser")
	{
		health--;
	}
}

