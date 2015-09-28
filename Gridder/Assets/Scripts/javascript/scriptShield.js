#pragma strict
var shieldHealth : int = 3;

function Start () {

}

function Update () 
{	
	if(shieldHealth <= 0)
	{
		Destroy(gameObject);
	}

}

function OnTriggerEnter(other: Collider)
{
	if(other.tag == "asteroid" || other.tag == "laser")
	{
		shieldHealth--;
	}
}