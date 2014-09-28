#region File Header
// File Name:		PlayerControllerTestState.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System;

using LunarGrin.Core;
#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	public class PlayStateState : GameState
	{
		public PlayStateState( String name ) : base( name )
		{
		}

		public override void OnEnter()
		{
			base.OnEnter();
			
			CreatePlayerController( "ExamplePlayer" );
		}
		
		private void CreatePlayerController( String playerName )
		{
			/*
			GameObject goPlayerController = new GameObject( playerName );
			
			ExamplePlayer cPlayerController = goPlayerController.AddComponent<ExamplePlayer>();
			
			GameServices.GameInfo.Player = cPlayerController;
			
			if ( cPlayerController != null )
			{
				GameObject goPlayer = GameObject.CreatePrimitive( PrimitiveType.Cube );
				
				Pawn cPawn = goPlayer.AddComponent<Pawn>();
				
				cPlayerController.Possess( cPawn );
				
				cPlayerController.PushControls( new PlayerMoveControls( cPlayerController ) );
				
				cPlayerController.CreatePlayerCamera();
				
				cPlayerController.PlayerCamera.Target = cPawn.transform;
			}
			else
			{
				//	TODO:	Throw an error, controller cannot be null
			}
			*/
		}
	}
}