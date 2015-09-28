using UnityEngine;
using System.Collections;

public class CrateSpawner : MonoBehaviour {

	public GameObject Crate;
	public GameObject Player;

	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("SpawnCrate", 2, 5);
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void SpawnCrate()
	{
		//-14, 14
		float startX = Random.Range (-14, 14);
		Instantiate (Crate, new Vector3(startX ,Player.transform.position.y + 16 ,0), Quaternion.identity);
	}
}
