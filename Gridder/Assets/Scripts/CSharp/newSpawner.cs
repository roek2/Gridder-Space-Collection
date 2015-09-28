using UnityEngine;
using System.Collections;

public class newSpawner : MonoBehaviour{
	public Transform asteroid = null;
	public float horizMin = -26;			//left most barrier of the game
	public float horizMax = 26;
	public bool canSpawn = true;
	public bool spawnChange = true;
	public float spawnRate = 3;
	public int asteroidCount = 0;
	
	void Update () {
		
		StartCoroutine(spawn());
	}
	
	IEnumerator spawn ()
	{
		print ("yo");
		gameObject.transform.position += new Vector3(Random.Range(horizMin, horizMax), 23f, 0);
		if(canSpawn)
		{
			float scale = scaleAsteroid();
			float speed = Random.Range(3, 12);
			Transform ast = GameObject.Instantiate(asteroid, new Vector3(Random.Range(horizMin, horizMax), 23, 0), gameObject.transform.rotation) as Transform;
			ast.transform.localScale += new Vector3(scale,scale,scale);
			ast.GetComponent<newEnemy>().health = scale * 3;
			ast.GetComponent<newEnemy>().asteroidSpeed = speed;
			ast.GetComponent<Renderer>().material.color = Color.gray;
			
			canSpawn = false;
			yield return new WaitForSeconds(spawnRate);
			canSpawn = true;
		}
		
		StartCoroutine(spawnDelay());
		
	}
	
	float scaleAsteroid()
	{
		float scale1 = Random.Range(1, 8);
		float scale = 0.3f;
		if(asteroidCount > 8)
		{
			scale = scale1;
			asteroidCount = 0;
		}
		asteroidCount++;
		return scale;
	}
	
	IEnumerator spawnDelay()
	{
		if(spawnChange && spawnRate > 0.1)
		{
			spawnRate /= 2;
			spawnChange = false;
			yield return new WaitForSeconds(10);
			spawnChange = true;
		}
	}
	
	Color setColour()
	{
		var color = new Color(111,111, 111);
		return color;
		
	}
}