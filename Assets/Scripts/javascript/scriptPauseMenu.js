//#pragma strict

//var sceneManager : GameObject;
//var player : GameObject;
//var paused : boolean = false;
//var pauseInput : KeyCode;
//
//function Start () {
//
//}
//
//function Update () {
//
//	if(Input.GetKeyDown(pauseInput))
//	{
//		if(!paused)
//		{
//			Time.timeScale = 0;
//			paused = true;
//		}
//		else
//		{
//			Time.timeScale = 1;
//			paused = false;			
//		}
//	}
//
//}
//
//function OnGUI ()
//{
//	if(paused)
//		{
//		GUI.BeginGroup(Rect(Screen.width/2 - 100, Screen.height/2 - 80, 200, 175));
//		GUI.backgroundColor = Color.blue;
//		GUI.Box(Rect(0,0,100,175), "Main Menu");
//		
//		GUI.Label(Rect(10,30,80,30),"Mines       $5");
//		
//		if(GUI.Button(Rect(120,25,60,30),"Buy"))
//		{
//			if(sceneManager.GetComponent(scriptSceneManager).score >= 5)
//			{
//				player.GetComponent(scriptPlayer).numOfMines++;
//				sceneManager.GetComponent(scriptSceneManager).score -= 5;
//			}
//		}	
//		
//		GUI.Label(Rect(10,65,80,30),"Shields     $5");
//		
//		if(GUI.Button(Rect(120,60,60,30),"Buy"))
//		{
//
//			if(sceneManager.GetComponent(scriptSceneManager).score >= 5)
//			{
//				player.GetComponent(scriptPlayer).incShields();
//				sceneManager.GetComponent(scriptSceneManager).score -= 5;
//			}
//			
//		}	
//		
//		GUI.Label(Rect(10,100,80,30),"Turrets     $5");	
//		
//		if(GUI.Button(Rect(120,95,60,30),"Buy"))
//		{
//		
//			if(sceneManager.GetComponent(scriptSceneManager).score >= 5)
//			{
//				player.GetComponent(scriptPlayer).numOfTurrets++;
//				sceneManager.GetComponent(scriptSceneManager).score -= 5;
//			}
//			
//		}	
//		
//		GUI.Label(Rect(10,135,80,30),"Upgrades $5");	
//		
//		if(GUI.Button(Rect(120,130,60,30),"Buy"))
//		{
//	
//			if(sceneManager.GetComponent(scriptSceneManager).score >= 5)
//			{
//				player.GetComponent(scriptPlayer).upgrade++;
//				sceneManager.GetComponent(scriptSceneManager).score -= 5;
//			}
//			
//		}	
//		
//		GUI.EndGroup();
//
//		
//
//	}
//}




#pragma strict

var guiSkin: GUISkin;
var inStock : boolean = true;


private var windowRect : Rect = Rect (0, 0, 400, 380);
private var scrollPosition : Vector2 = Vector2.zero;


var sceneManager : GameObject;
var player : GameObject;
var paused : boolean = false;
var pauseInput : KeyCode;


function Start () 
{
  windowRect.x = (Screen.width - windowRect.width)/2;
  windowRect.y = (Screen.height - windowRect.height)/2;
}


function Update()
{
	if(Input.GetKeyDown(pauseInput))
	{
		if(!paused)
		{
			paused = true;
			Time.timeScale = 0.0;
		}
		
		else
		{
			paused = false;
			Time.timeScale = 1.0;
		}
		
	}
}


function OnGUI () 
{
	
   if(paused)
   {	
       GUI.skin = guiSkin;
   	   windowRect = GUI.Window (0, windowRect, DoMyWindow, "Store");
   }
  
  
}
	
	

function DoMyWindow (windowID : int) 
{

    
    	scrollPosition = GUI.BeginScrollView (Rect (10,15,380,360), scrollPosition, Rect (0, 0, 360, 420));
    	
		addItem("Mines", 0, 20);
		addItem("V.Mines", 1, 100);
		addItem("Shields", 2, 50);
		addItem("Turrets", 3, 300);
		addUpgrade("GunUp.I", 4, 10, 1);	
		addUpgrade("GunUp.II", 5, 10, 2);	
		addUpgrade("GunUp.III", 6, 10, 3);	
		addUpgrade("GunUp.IV", 7, 10, 4);	
		
		
		GUI.EndScrollView ();
    
			
	GUI.DragWindow (Rect (0,0,10000,10000));
}

function checkDollar(price : int)
{
    GUI.contentColor = Color.grey;
//	if(sceneManager.GetComponent(scriptSceneManager).score >= price)
	{
//		GUI.contentColor = Color.white;
	}
}

function addItem(name: String, position : int, price : int)
{
	checkDollar(price);
	GUI.Label(Rect(10,30 + (position * 50),200,30), name + ":  $" + price);
	if(GUI.Button(Rect(300,25 + (position * 50),60,30),"Buy"))
	{
	//	if(sceneManager.GetComponent(scriptSceneManager).score >= price)
		{
		
			switch (position) {
			    case 0:
			        player.GetComponent(scriptPlayer).numOfMines++;
			        break;
			    case 1:
			        player.GetComponent(scriptPlayer).numOfMines++;
			        break;
			    case 2:
			        player.GetComponent(scriptPlayer).numOfShields++;
			        break;
			    case 3:
			        player.GetComponent(scriptPlayer).numOfTurrets++;
			        break;
			} 

	//		sceneManager.GetComponent(scriptSceneManager).score -= price;
		}
	}	
}

function addUpgrade(name: String, position : int, price : int, mkV : int)
{
	if(player.GetComponent(scriptPlayer).upgrade >= mkV - 1)
	{
		checkDollar(price);
		if(player.GetComponent(scriptPlayer).upgrade >= mkV)
		{
			GUI.contentColor = Color.grey;
		}
		GUI.Label(Rect(10,30 + (position * 50),200,30), name + ":  $" + price);
		if(GUI.Button(Rect(300,25 + (position * 50),60,30),"Buy"))
		{
	//		if(sceneManager.GetComponent(scriptSceneManager).score >= price && player.GetComponent(scriptPlayer).upgrade < mkV)
			{
				player.GetComponent(scriptPlayer).upgrade++;
	//			sceneManager.GetComponent(scriptSceneManager).score -= price;
			}
		}	
	}
}
