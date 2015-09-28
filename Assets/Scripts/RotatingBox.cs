using UnityEngine;
using System.Collections;

public class RotatingBox : MonoBehaviour {

	float counter = 0;
	Vector3 rotationVector;

	// Use this for initialization
	void Start () {
	
		rotationVector = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

		counter += Time.deltaTime;
//		print (counter);
		if(counter > 3)
		{
			rotationVector.z += 90;
			if(rotationVector.z == 360)
				rotationVector.z = 0;
			counter = 0;
		}
		transform.eulerAngles = Vector3.Lerp (transform.eulerAngles,  rotationVector, 0.2f);
	
	}
}
