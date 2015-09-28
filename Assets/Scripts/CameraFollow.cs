using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, new Vector3 (player.position.x, player.position.y + 1.5f , transform.position.z), 0.1f);
	
	}
}
