using UnityEngine;
using System.Collections;

public class newChunk : MonoBehaviour {
	
	float cash = 1.0f;
	public float asteroidSpeed = 6;
	bool gravitationalPull = false;
	public GameObject inventory;	
	private Vector3 holePosition;
	
	void Start () {

		transform.position = new Vector3 (Random.Range (transform.parent.position.x - 1, transform.parent.position.x + 1), Random.Range (transform.parent.position.y - 1, transform.parent.position.y + 1), 0);
	}
	
	void Update () {
		
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
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"|| other.gameObject.tag == "collector")
		{
			inventory.GetComponent<Invent>().addScore(1);
			GetComponent<AudioSource>().Play();
			Destroy(gameObject);
		}
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "magnet")
		{
			holePosition = other.transform.position;
			gravitationalPull = true;
		}
	}
}
