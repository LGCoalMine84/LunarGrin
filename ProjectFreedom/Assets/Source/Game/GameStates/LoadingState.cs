#region File Header
// File Name:		LoadingState.cs
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
	public class LoadingState : GameState
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( JsonSerialization ) );
		#endif
		
		private Boolean isLoadingComplete = false;
	
		public LoadingState( String stateName ) : base( stateName )
		{
		}
		
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		public override void OnEnter()
		{
			#if LOGGING
			Log.Trace( "LoadingState.OnEnter" );
			#endif
			
			base.OnEnter();
			
			GameServices.StateManager.PushState( new IntroCinematicState( "IntroCinematicState" ) );
			
			//	TODO:	Start a coroutine to start loading anything in the game that needs to be loaded at the start of the application.
			
			isLoadingComplete = true;
			
			//	Make sure this state is enabled before transitioning to a different state.
			if ( IsEnabled )
			{
				FinishLoading();
			}
		}
		
		/// <summary>
		/// Raised when the game state has been enabled by the current game state being popped from the stack.
		/// </summary>
		public override void OnEnabled()
		{
			base.OnEnabled();
			
			//	Make sure loading is complete before transitioning to a different state.
			if ( isLoadingComplete )
			{
				FinishLoading();
			}
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
			Log.Trace( "LoadingState.OnExit" );
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
		}
		
		private void BeginLoading()
		{
			
		}
		
		private void FinishLoading()
		{
			GameServices.StateManager.ChangeState( new MainMenuState( "MainMenuState" ) );
		}
	}
}