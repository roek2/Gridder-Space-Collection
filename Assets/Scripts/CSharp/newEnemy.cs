using UnityEngine;
using System.Collections;

//publics//

public class newEnemy : MonoBehaviour
{
	public float asteroidSpeed = 6.0f;
	public int horizMin = -6;			//left most barrier of the game
	public int horizMax = 6;
	public Transform explosion ;		
	public AudioClip hitPlayer;
	public AudioClip hitShield;
	public float health = 1;
	public Vector3 vec;
	public float cash  = 1.0f;
	public bool gravitationalPull = false;
	
	
	
	//privates///
	float initHealth;
	Vector3 holePosition;
	
	
	void Start () {
		
		this.transform.position += new Vector3(Random.Range(horizMin, horizMax), 23, 0);
		initHealth = health;
		
	}
	
	void Update () {
		
		gameObject.transform.Translate(Vector3.down * asteroidSpeed * Time.deltaTime);
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
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.GetComponent<newPlayer>().lives--;
			health -= 3;
			GetComponent<AudioSource>().clip = hitPlayer;
			GetComponent<AudioSource>().Play();
		}
		
		else if(other.gameObject.tag == "shield")
		{
			health -= 3;
			GetComponent<AudioSource>().clip = hitShield;
			GetComponent<AudioSource>().Play();
		}
		
		else if(other.gameObject.tag == "turret")
		{
			health -= 3;
			GetComponent<AudioSource>().clip = hitPlayer;
			GetComponent<AudioSource>().Play();
		}
		
		else if(other.gameObject.tag == "collector")
		{
			health -= 3;
			GetComponent<AudioSource>().clip = hitPlayer;
			GetComponent<AudioSource>().Play();
		}
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "hole")
		{
			holePosition = other.transform.position;
			gravitationalPull = true;
		}
	}
	
	
	public void resetEnemy()
	{
		//transform.position.y = 23;
		//transform.position.x = Random.Range(horizMin, horizMax);
		//health = initHealth;
		Destroy(gameObject);
	}
}

