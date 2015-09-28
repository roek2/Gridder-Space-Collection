using UnityEngine;
using System.Collections;



public class newTurret2 : MonoBehaviour
{
	
	public Transform gun;
	public Transform gunL;
	public Transform gunR;
	public Transform bullet;
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
		Instantiate(bullet, gunL.position, gunL.rotation );
		Instantiate(bullet, gunR.position, gunR.rotation );
	}
}