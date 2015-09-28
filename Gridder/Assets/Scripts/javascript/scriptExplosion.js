#pragma strict

function Start () {

}

function Update () {

	existAndDie();

}

function existAndDie () {

	yield WaitForSeconds(2);
	Destroy(gameObject);

}
