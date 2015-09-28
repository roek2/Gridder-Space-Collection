using UnityEngine;
using System.Collections;

public class newMine : MonoBehaviour {

	//Inspectore Variables
	public Transform explosion;	
	public Transform mineExplosion;	
	
	//Private Variables
	

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "asteroid")
		{
			
			other.GetComponent<newEnemy>().health -= 3;
			Instantiate(mineExplosion, transform.position, transform.rotation);
			Destroy(gameObject);
			
			if(other.GetComponent<newEnemy>().health <= 0)
			{
				other.GetComponent<newEnemy>().resetEnemy();
				Instantiate(explosion, transform.position, transform.rotation);
				//audio.PlayClipAtPoint(fxSound, transform.position, volume);
			}
			
		}
		
		
		
	}
}
