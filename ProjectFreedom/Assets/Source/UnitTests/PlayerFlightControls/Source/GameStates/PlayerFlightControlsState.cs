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
	public class PlayerFlightControlsState : GameState
	{
		#region Private Fields
		
		/// <summary>
		/// The logger.
		/// </summary>
		private static readonly ILogger Log = LogFactory.CreateLogger( typeof( GameplayState ) );
		
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
		
		#region Public Methods
		
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		public override void OnEnter()
		{
			Log.Trace( "PlayerFlightControlsState.OnEnter" );
			
			base.OnEnter();
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
			
		}
		
		#endregion
	}
}