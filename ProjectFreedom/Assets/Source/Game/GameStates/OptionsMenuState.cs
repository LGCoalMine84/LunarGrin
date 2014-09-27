#region File Header
// File Name:		OptionsMenuState.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
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

namespace LunarGrin.Core
{
	/// <summary>
	/// The Options menu state displays the options menu UI.
	/// </summary>
	public class OptionsMenuState : GameState
	{
		/// <summary>
		/// The options menu UI game object.
		/// </summary>
	    private GameObject optionsMenu = null;
	    
	    /// <summary>
	    /// Initializes a new instance of the <see cref="LunarGrin.Core.OptionsMenuState"/> class.
	    /// </summary>
	    /// <param name="stateName">State name.</param>
	    public OptionsMenuState( String stateName ) : base( stateName )
	    {
	    }
	    
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		public override void OnEnter()
		{
			base.OnEnter();
			
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
			base.OnEnabled();
			
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
			base.OnDisabled();
			
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
			base.OnExit();
		
			GameObject.Destroy( optionsMenu );
		}
	}
}