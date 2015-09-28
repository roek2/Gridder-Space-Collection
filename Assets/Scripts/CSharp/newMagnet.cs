using UnityEngine;
using System.Collections;

public class newMagnet : MonoBehaviour {
	
	public float health = 3;
	
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

}
