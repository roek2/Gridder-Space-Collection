#pragma strict

//Player Script


//Inspectore Variables
var gameTime : float = 10.0;
var player : GameObject;
//Private Variables


//Constructor
function Start () {
	InvokeRepeating("countDown", 1.0, 1.0);
	//score = 0;
	player.GetComponent(scriptPlayer).lives = 3;
}

function Update () {

	if(player.GetComponent(scriptPlayer).lives <= 0)
	{
//		Application.LoadLevel("SceneLose");
	//	PlayerPrefs.SetInt("SCORE", score);
	}
	
	else if(gameTime <= 0)
	{
	//	Application.LoadLevel("SceneWin");
	//	PlayerPrefs.SetInt("SCORE", score);
	}

}

function OnGUI()
{


	GUI.Label(Rect(10, 30, 100, 50), "Lives: " + player.GetComponent(scriptPlayer).lives);
	GUI.Label(Rect(Screen.width - 70, 10, 100, 50), "Time: " + gameTime);
	GUI.Label(Rect(Screen.width - 70, Screen.height - 28, 100, 50), "Shields: " + player.GetComponent(scriptPlayer).numOfShields);
	GUI.Label(Rect(Screen.width - 70, Screen.height - 50, 100, 50), "Mines: " + player.GetComponent(scriptPlayer).numOfMines);
	GUI.Label(Rect(Screen.width - 70, Screen.height - 72, 100, 50), "Turrets: " + player.GetComponent(scriptPlayer).numOfTurrets);
		
}

function countDown()
{
	if(--gameTime == 0)
	{
		CancelInvoke("countDown");
		//yield WaitForSeconds(waitTime);
		//Application.LoadLevel("sceneScreenLose");
	}
}

