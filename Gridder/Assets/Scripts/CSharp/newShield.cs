using UnityEngine;
using System.Collections;

public class newShield : MonoBehaviour {

	public int shieldHealth = 3;
	
	void Update () 
	{	
		if(shieldHealth <= 0)
		{
			Destroy(gameObject);
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "asteroid" || other.tag == "laser")
		{
			shieldHealth--;
		}
	}
}
