#pragma strict

function Start () {

}

function Update () {

}

function OnGUI () {

	GUI.BeginGroup(Rect(Screen.width/2 - 50, Screen.height/2 - 80, 100, 175));
	
	GUI.Box(Rect(0,0,100,175), "Main Menu");
	
	if(GUI.Button(Rect(10,30,80,30),"Start Game"))
	{
		Application.LoadLevel("SceneLoad");
	}	
	
	if(GUI.Button(Rect(10,65,80,30),"Credits"))
	{
		Application.LoadLevel("SceneCredits");
	}	
	
	if(GUI.Button(Rect(10,100,80,30),"Exit Game"))
	{
		Application.Quit();
	}	
	
	if(GUI.Button(Rect(10,135,80,30),"Facebook"))
	{
		Application.OpenURL("https://www.facebook.com/karl.roe.7");
	}	
	
	GUI.EndGroup();
}