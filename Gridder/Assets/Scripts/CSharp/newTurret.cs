using UnityEngine;
using System.Collections;



public class newTurret : MonoBehaviour
{

	Transform gun;
	Transform bullet;
	float health = 3;


	void Start () {
		
		InvokeRepeating("autoShoot", 1, 1.0f);
		
	}

	void Update () {
		
		if(health <= 0)
		{
			Destroy(gameObject);
		}	
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "asteroid" || other.tag == "laser")
		{
			health--;
		}
	}

	void autoShoot ()
	{
		Instantiate(bullet, gun.position, gun.rotation );
	}
}
