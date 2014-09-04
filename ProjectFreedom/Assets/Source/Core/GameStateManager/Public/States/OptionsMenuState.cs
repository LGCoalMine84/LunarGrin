#region File Header
// File Name:		OptionsMenuState.cs
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

public class OptionsMenuState : GameState
{
    private GameObject optionsMenu = null;
    
    public OptionsMenuState( String stateName ) : base( stateName )
    {
    }
    
	/// <summary>
	/// Raised when the game state has been pushed to the top of the stack.
	/// </summary>
	public override void OnEnter()
	{
		Object optionsMenuPrefab = Resources.Load( "Prefabs/UI/OptionsMenu/OptionsMenu" );
		
		if ( optionsMenuPrefab != null )
		{
			optionsMenu = (GameObject)GameObject.Instantiate( optionsMenuPrefab, Vector3.zero, Quaternion.identity );
		}
	}
	
	/// <summary>
	/// Raised when the game state has been enabled by the current game state being popped from the stack.
	/// </summary>
	public override void OnEnabled()
	{
		if ( optionsMenu != null )
		{
			optionsMenu.SetActive( true );
		}
	}
	
	/// <summary>
	/// Raised when the game state has been disabled by a new game state being pushed to the stack.
	/// </summary>
	public override void OnDisabled()
	{
		if ( optionsMenu != null )
		{
			optionsMenu.SetActive( false );
		}
	}
	
	/// <summary>
	/// Raised when the game state has been popped from the top of the stack.
	/// </summary>
	public override void OnExit()
	{
		GameObject.Destroy( optionsMenu );
	}
}