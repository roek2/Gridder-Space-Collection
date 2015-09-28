#pragma strict

function Start () {

}

function Update () {

}

function OnGUI () {

	GUI.BeginGroup(Rect(Screen.width/2 - 100, Screen.height/2 - 80, 200, 100));
	
	GUI.Box(Rect(0,0,200,200), "You Win");

	GUI.Label(Rect(30, 30, 200, 40),"Score: " + PlayerPrefs.GetInt("SCORE"));
	if(GUI.Button(Rect(60, 65,80,30),"Back"))
	{
		Application.LoadLevel("SceneMainMenu");
	}	
	GUI.EndGroup();
}