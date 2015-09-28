using UnityEngine;
using System.Collections;

public class WaterDeath : MonoBehaviour {

	public GameObject waterManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < waterManager.GetComponent<WaterRise> ().waterLevel)
			Application.Quit ();
	
	}
}
