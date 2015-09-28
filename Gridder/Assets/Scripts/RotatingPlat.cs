using UnityEngine;
using System.Collections;

public class RotatingPlat : MonoBehaviour {

	public Transform mid;
	public float rotationalSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround (mid.position, new Vector3(0,0,1), Time.deltaTime * rotationalSpeed);
		transform.up = new Vector3 (0,1,0);
	
	}
}
