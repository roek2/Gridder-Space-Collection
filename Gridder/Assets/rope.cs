using UnityEngine;
using System.Collections;

public class rope : MonoBehaviour {

	public GameObject ob1;
	public GameObject ob2;
	public GameObject ConnectionPrefab;
	public GameObject[] ropeParts;
	int ropeCount;
	Vector3 offset;
	Vector3 start;

	// Use this for initialization
	void Start () {

		ob1.AddComponent<SpringJoint2D> ();
		ob1.GetComponent<SpringJoint2D> ().distance = Vector3.Distance (ob1.transform.position, ob2.transform.position);
		ob1.GetComponent<SpringJoint2D> ().connectedBody = ob2.GetComponent<Rigidbody2D> ();
		ropeParts = new GameObject[200];
		ropeParts [0] = ob1;
		ropeParts [1] = ob2;
		ropeCount = 1;

		start = ob1.transform.position;
		offset = (ob2.transform.position - start) * ConnectionPrefab.transform.localScale.y;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < ropeCount; i++)
		{
			checkForNewNode (i);

		}

		for(int i = ropeCount - 2; i >= 0; i--)
		{
			checkNodeRelevance(i);
		}


		drawRope ();

	}



	void checkForNewNode(int index)
	{

		start = ropeParts [index].transform.position;
		offset = new Vector3(0.2f,0,0);
		start += offset;
		Vector3 angle = ropeParts [index + 1].transform.position - start;
		
		RaycastHit2D hit = Physics2D.Raycast(start, angle, Vector3.Distance (ropeParts[index].transform.position, ropeParts [index + 1].transform.position), (1 << 8));
		if(hit.collider != null)
		{
			print (hit.collider.tag);
			if(hit.collider.tag == "Ground")
			{
				pushArray(index);
				ropeParts[index + 1] = Instantiate(ConnectionPrefab, hit.point + new Vector2(0, ConnectionPrefab.transform.localScale.y * 1), Quaternion.identity) as GameObject;
				ropeCount++;
				setJoint(index);
				setJoint(index + 1);
				
			}
		}
	}

	void checkNodeRelevance (int index)
	{
		
		if(ropeCount > 1)
		{

			start = ropeParts[index].transform.position;
			offset = new Vector3(-0.2f,0,0);
			start += offset;
			RaycastHit2D hit = Physics2D.Raycast(start , ropeParts[index + 2].transform.position - ropeParts[index].transform.position, Vector3.Distance (ropeParts[index].transform.position, ropeParts[index + 2].transform.position), (1 << 8) | (1 << 13) );
			if(hit.collider != null)
			{
				if(hit.collider.tag == "Object")
				{
					DestroyImmediate (ropeParts[index + 1]);
					pullArray(index + 1);
					ropeParts[ropeCount] = null;
					ropeCount--;
					setJoint(index);
				}
			}
		}
	}


	void pushArray(int index)
	{
		for(int j = ropeCount; j > index; j--)
		{
			ropeParts [j + 1] = ropeParts [j];
		}
	}

	void pullArray(int index)
	{
		for(int j = index; j < ropeCount; j++)
		{
			ropeParts [j] = ropeParts [j + 1];
		}
	}

	void drawRope()
	{
		for(int i = 0; i < ropeCount; i++)
		{
			Debug.DrawLine (ropeParts[i].transform.position, ropeParts[i + 1].transform.position);
		}
		
	}

	void setJoint(int index)
	{
		ropeParts[index].GetComponent<SpringJoint2D> ().distance = Vector3.Distance (ropeParts[index].transform.position, ropeParts[index + 1].transform.position);
		ropeParts[index].GetComponent<SpringJoint2D> ().connectedBody = ropeParts[index + 1].GetComponent<Rigidbody2D> ();


	}

}
