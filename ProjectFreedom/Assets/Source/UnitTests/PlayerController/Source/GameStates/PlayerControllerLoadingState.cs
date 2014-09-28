#region File Header
// File Name:		NewBehaviourScript.cs
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
	public class PlayerControllerLoadingState : GameState
	{
		public PlayerControllerLoadingState( String name ) : base( name )
		{
		}
		
		public override void OnEnter()
		{
			CreatePlayerController();
			
			CreatePlayerCamera();
			
			GameServices.StateManager.ChangeState( new PlayerControllerPlayState( "PlayerControllerPlayState" ) );
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
			
		}
		
		private void CreatePlayerController()
		{
			PlayerController playerController = GameServices.GameInfo.CreatePlayerController<PlayerController>( "Player" );
			playerController.PushControls( new PlayerMoveControls( playerController ) );
		}
		
		private void CreatePlayerCamera()
		{
			PlayerController playerController = GameServices.GameInfo.Player;
			
			GameCamera playerCamera = playerController.CreatePlayerCamera<GameCamera>();
			playerCamera.transform.position = new Vector3( 0, 1f, -10f );
			playerCamera.Controls = new CameraOrbitControls( playerCamera );
		}
	}
}