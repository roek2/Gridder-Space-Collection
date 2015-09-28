using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	
	//here we delcare the variables
	
	//make a new variable and its a float so it have decimals/ we have more control of how fast we want the player to move
	public float moveSpeed = 0.5f;
	float input;
	GroundCheck myGround;
	public Animator anim;
	private float yRotation;

	KeyCode jump = KeyCode.Space;

	public enum Player
	{
		one,
		two,
		three,
		four
	}

	public Player currentPlayer = Player.one;

	void Start()
	{
		myGround = GetComponent<GroundCheck> ();
	}

	//we use the update function with is going to be used every frame.
	void Update(){

		if(currentPlayer == Player.one)
		{
			input = Input.GetAxis ("Horizontal");
		//	jump = 
		}
		else if(currentPlayer == Player.two)
		{
			input = Input.GetAxis ("Horizontal2");
			//jump = KeyCode.U;
		}



		if(input != 0 && myGround.onGround)
		{

			anim.SetBool("Running", true);
			anim.speed = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x)/3;
		}
		else
			anim.SetBool("Running", false);

		if(input > 0)
			yRotation = Mathf.Lerp (yRotation, 0, 0.1f);
		else if(input < 0)
		{
			yRotation = Mathf.Lerp (yRotation, 180, 0.1f);
		}

		transform.eulerAngles = new Vector3(0, yRotation, 0);


		if(GetComponent<Rigidbody2D>().velocity.x < 10)
			GetComponent<Rigidbody2D>().AddForce(new Vector2(input * moveSpeed * Time.deltaTime,0));
		if(Input.GetButtonDown("Jump") && myGround.onGround)
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0,0.18f));




	}

}
