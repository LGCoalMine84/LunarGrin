#region File Header
// File Name:		MainMenuState.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using LunarGrin.Core;
using System;

using Object = UnityEngine.Object;
#endregion

public class MainMenuState : GameState
{
    private GameObject mainMenu = null;
    
    public MainMenuState( String stateName ) : base( stateName )
    {
    }
    
	/// <summary>
	/// Raised when the game state has been pushed to the top of the stack.
	/// </summary>
	public override void OnEnter()
	{
		Object mainMenuPrefab = Resources.Load( "Prefabs/UI/MainMenu/MainMenu" );
		
		if ( mainMenuPrefab != null )
		{
			mainMenu = (GameObject)GameObject.Instantiate( mainMenuPrefab, Vector3.zero, Quaternion.identity );
		}
	}
	
	/// <summary>
	/// Raised when the game state has been enabled by the current game state being popped from the stack.
	/// </summary>
	public override void OnEnabled()
	{
		if ( mainMenu != null )
		{
			mainMenu.SetActive( true );
		}
	}
	
	/// <summary>
	/// Raised when the game state has been disabled by a new game state being pushed to the stack.
	/// </summary>
	public override void OnDisabled()
	{
		if ( mainMenu != null )
		{
			mainMenu.SetActive( false );
		}
	}
	
	/// <summary>
	/// Raised when the game state has been popped from the top of the stack.
	/// </summary>
	public override void OnExit()
	{
		GameObject.Destroy( mainMenu );
	}
}