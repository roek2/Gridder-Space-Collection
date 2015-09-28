#pragma strict

var waitTime: float = 3.0;

function Start () {

}

function Update () {

	if(Input.GetKeyDown("space"))
	{
		Application.LoadLevel("SceneMainGame4");
	}
	else
	{
		waitForTime();
	}

}

function OnGUI () {

	GUI.BeginGroup(Rect(Screen.width/2 - 100, Screen.height/2 - 80, 200, 200));
	
	GUI.Box(Rect(0,0,200,200), "Instructions");

	GUI.Label(Rect(30, 30, 200, 40),"Press arrow keys to move");
	GUI.Label(Rect(40, 60, 160, 70),"Press Space to shoot");
	GUI.Label(Rect(50, 90, 160, 100),"Press Esc to Quit");
	
	GUI.EndGroup();
}

function waitForTime()
{
	yield WaitForSeconds(waitTime);
	Application.LoadLevel("SceneMainGame");
}
