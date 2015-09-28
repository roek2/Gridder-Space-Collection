#pragma strict

function Start () {

}

function Update () {

}

function OnGUI () {

	GUI.BeginGroup(Rect(Screen.width/2 - 100, Screen.height/2 - 80, 200, 200));
	
	GUI.Box(Rect(0,0,200,200), "Credits");

	GUI.Label(Rect(30, 30, 200, 40),"Designer          Karl Roe");
	GUI.Label(Rect(30, 60, 160, 70),"Artist               Karl Roe");
	GUI.Label(Rect(30, 90, 160, 100),"Software          Karl Roe");
	GUI.Label(Rect(30, 120, 160, 100),"Level Design    Karl Roe");
	if(GUI.Button(Rect(60, 155,80,30),"Back"))
	{
		Application.LoadLevel("SceneMainMenu");
	}	
	GUI.EndGroup();
}