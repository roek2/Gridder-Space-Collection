using UnityEngine;
using System.Collections;

public class movingPlat : MonoBehaviour {


	public enum Direction
	{
		undefined,
		horizontal,
		vertical
	}
	private bool vertical;
	public Direction ForcedDir;
	private float dirTimer;
	private int dir = 1;

	// Use this for initialization
	void Start () {

		int randvalue = Random.Range (1, 10);
		if (ForcedDir == Direction.horizontal)
			vertical = false;
		else if(ForcedDir == Direction.vertical)
			vertical = true;
		else
		{
			if(randvalue > 5)
				vertical = true;
			else
				vertical = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if(vertical)
			transform.position += new Vector3 (0,dir,0) * Time.deltaTime;
		else
			transform.position += new Vector3 (dir,0,0) * Time.deltaTime;

		if(dirTimer > 5)
		{
			dir = dir * (-1);
			dirTimer = 0;
		}

		dirTimer += Time.deltaTime;
	}
}
