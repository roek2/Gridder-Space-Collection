using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			Application.LoadLevel (1);
		}
		else if(Input.GetKeyDown (KeyCode.A))
		{
			Application.LoadLevel (2);
		}

		else if(Input.GetKeyDown (KeyCode.Z))
		{
			Application.Quit ();
		}
	
	}
}
