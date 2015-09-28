using UnityEngine;
using System.Collections;

public class newBullet : MonoBehaviour {

	//Inspectore Variables
	public float bulletSpeed = 15.0f;
	public float bulletRange = 10.0f;
	public float horizMin = -12;			//left most barrier of the game
	public float horizMax = 12;
	public Transform explosion;	
	public GameObject sceneManager;	
	public AudioClip fxSound;
	public float volume = 0.1f;
	public Vector3 vec = Vector3.up;
	
	//Game Loop
	
	void Update () {
		
		transform.Translate(vec * (bulletSpeed * Time.deltaTime));
		if(transform.position.y > bulletRange)
		{
			Destroy(gameObject);
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "asteroid")
		{
			if(--other.GetComponent<newEnemy>().health <= 0)
			{
				other.GetComponent<newEnemy>().resetEnemy();
				Instantiate(explosion, transform.position, transform.rotation);
				//audio.PlayClipAtPoint(fxSound, gameObject.transform.position, volume);
			}
			
			Destroy(gameObject);
			
		}
		
	}
}
