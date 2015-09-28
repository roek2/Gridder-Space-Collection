#pragma strict
var asteroid : Transform;
var horizMin : float = -26;			//left most barrier of the game
var horizMax : float = 26;
var canSpawn : boolean = true;
var spawnChange : boolean = true;
var spawnRate : float = 3;
var asteroidCount : int = 0;

function Start () {

}

function Update () {

	spawn();

}

function spawn ()
{
	//transform.position.y = 23;
	//transform.position.x = Random.Range(horizMin, horizMax);
	if(canSpawn)
	{
		var scale = scaleAsteroid();
		var speed = Random.Range(3, 12);
		
		var ast = Instantiate(asteroid, Vector3(Random.Range(horizMin, horizMax), 23, 0), transform.rotation);
		ast.transform.localScale += Vector3(scale,scale,scale);
		var comp = ast.GetComponent(scriptEnemy);
		comp.health = scale * 3;
		comp.asteroidSpeed = speed;
		var color = setColour();
		ast.GetComponent.<Renderer>().material.color = color.gray;
		
		canSpawn = false;
		yield WaitForSeconds(spawnRate);
		canSpawn = true;
	}
	
	spawnDelay();
	
}

function scaleAsteroid()
{
	var scale1 = Random.Range(0.5, 8);
	var scale = 0.3;
	if(asteroidCount > 8)
	{
		scale = scale1;
		asteroidCount = 0;
	}
	asteroidCount++;
	return scale;
}

function spawnDelay()
{
	if(spawnChange && spawnRate > 0.1)
	{
		spawnRate /= 2;
		spawnChange = false;
		yield WaitForSeconds(10);
		spawnChange = true;
	}
}

function setColour()
{
	var color = Color(0.6, 0.1, 0.74);
	return color;
}