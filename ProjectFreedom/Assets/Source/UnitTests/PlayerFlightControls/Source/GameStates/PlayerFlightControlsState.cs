#region File Header

// File Name:           PlayerFlightControlsState.cs
// Author:              Andy Sanchez
// Creation Date:       10/12/2014   7:30 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Core;
using LunarGrin.Utilities;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// Handles the player flight controls game state of the unit test. 
	/// </summary>
	public sealed class PlayerFlightControlsState : GameState
	{
		#region Private Fields
		
		/// <summary>
		/// The logger.
		/// </summary>
		private static readonly ILogger Log = LogFactory.CreateLogger( typeof( GameplayState ) );
		
		private GameObject cam = null;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerFlightControlsState"/> class.
		/// </summary>
		/// <param name="stateName">The name of the game state.</param>
		public PlayerFlightControlsState( String stateName ) :
			base( stateName )
		{
			
		}
		
		#endregion
		
		private void CreatePlayerCamera()
		{
			PlayerController playerController = GameServices.GameInfo.Player;
			
			GameCamera playerCamera = playerController.CreatePlayerCamera<GameCamera>();
			playerCamera.transform.position = new Vector3( 0, 1f, -10f );
			//playerCamera.Controls = new CameraOrbitControls( playerCamera );
		}
		
		#region Public Methods
		
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		public override void OnEnter()
		{
			Log.Trace( "PlayerFlightControlsState.OnEnter" );
			
			base.OnEnter();
			
			PlayerController playerController = GameServices.GameInfo.CreatePlayerController<Player>( "Player" );
			
			GameObject pawn = GameObject.Find( "MantisShip" );
			playerController.Possess( pawn );
			
			//cam = GameObject.FindGameObjectWithTag( "MainCamera" );
			//cam.transform.parent = playerController.transform;
			//cam.transform.localPosition = Vector3.zero;
			//cam.transform.localScale = Vector3.one;
			
			//CreatePlayerCamera();
		}
		
		/// <summary>
		/// Raised when the game state has been enabled by the current game state being popped from the stack.
		/// </summary>
		public override void OnEnabled()
		{
			base.OnEnabled();
		}
		
		/// <summary>
		/// Raised when the game state has been disabled by a new game state being pushed to the stack.
		/// </summary>
		public override void OnDisabled()
		{
			base.OnDisabled();
		}
		
		/// <summary>
		/// Raised when the game state has been popped from the top of the stack.
		/// </summary>
		public override void OnExit()
		{			
			base.OnExit();
		}
		
		/// <summary>
		/// Updates the game state logic.
		/// </summary>
		/// <param name="time">The delta time.</param>
		/// <seealso cref="LunarGrin.Core.IGameState"/>
		public override void Update( Single deltaTime )
		{
			if( cam != null )
			{
				//PlayerController player = GameServices.GameInfo.Player;
				//Vector3 newVec = new Vector3( player.transform.localPosition.x, player.transform.localPosition.y + 25.0f, player.transform.localPosition.z - 30.0f );
				//cam.transform.position = Vector3.Lerp( cam.transform.position, newVec, Time.deltaTime );
			}
		}
		
		#endregion
	}
}
