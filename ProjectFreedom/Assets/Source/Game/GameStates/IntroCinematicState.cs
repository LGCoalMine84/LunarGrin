#region File Header
// File Name:		IntroCinematicState.cs
// Author:			John Whitsell
// Creation Date:	2014/09/24
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System;
using  LunarGrin.Utilities;
#endregion

namespace LunarGrin.Core
{
	public class IntroCinematicState : GameState
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( IntroCinematicState ) );
		#endif
	
		//	TODO:	Look into passing a video into this state so that it can just be made generic
		public IntroCinematicState( String stateName ) : base( stateName )
		{
		}
		
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		public override void OnEnter()
		{
			#if LOGGING
			Log.Trace( "IntroCinematicState.OnEnter" );
			#endif
			
			base.OnEnter();
			
			//	TODO:	Play the in-game cinematic!
			
			//	TODO:	For now use a coroutine that delays for a certain amount of time to mock a video being played.
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
			#if LOGGING
			Log.Trace( "IntroCinematicState.OnExit" );
			#endif
			
			base.OnExit();
		}
		
		/// <summary>
		/// Updates the game state logic.
		/// </summary>
		/// <param name="time">The delta time.</param>
		/// <seealso cref="LunarGrin.Core.IGameState"/>
		public override void Update( Single deltaTime )
		{
			//	TODO:	Update the coroutine manager
			
			//	TEMP:	Remove this once the coroutine manager is in
			GameServices.StateManager.PopState();
		}
	}
}