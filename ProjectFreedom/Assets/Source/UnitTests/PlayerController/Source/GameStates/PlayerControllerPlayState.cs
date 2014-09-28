#region File Header
// File Name:		PlayerControllerPlayState.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using System;

using UnityEngine;

using LunarGrin.Core;
#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	public class PlayerControllerPlayState : GameState
	{
		public PlayerControllerPlayState( String name ) : base( name )
		{
		}
		
		public override void OnEnter()
		{
			
		}
		
		public override void OnExit()
		{
			
		}
		
		public override void OnEnabled()
		{
			
		}
		
		public override void OnDisabled()
		{
			
		}
		
		public override void Update( Single deltaTime )
		{
			CheckInput();
		}
		
		private void CheckInput()
		{
			GameObject pawn = null;
			
			PlayerController playerController = GameServices.GameInfo.Player;
		
			if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
			{
				pawn = GameObject.Find( "Red" );
				
				GameServices.GameInfo.Player.Possess( pawn );
				
				playerController.PlayerCamera.Target = pawn.transform;
			}
			if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
			{
				pawn = GameObject.Find( "Green" );
				
				GameServices.GameInfo.Player.Possess( pawn );
				
				playerController.PlayerCamera.Target = pawn.transform;
			}
			if ( Input.GetKeyDown( KeyCode.Alpha3 ) )
			{
				pawn = GameObject.Find( "Blue" );
				
				GameServices.GameInfo.Player.Possess( pawn );
				
				playerController.PlayerCamera.Target = pawn.transform;
			}
			if ( Input.GetKeyDown( KeyCode.Alpha0 ) )
			{
				GameServices.GameInfo.Player.UnPossess();
				
				playerController.PlayerCamera.Target = null;
			}
		}
	}
}