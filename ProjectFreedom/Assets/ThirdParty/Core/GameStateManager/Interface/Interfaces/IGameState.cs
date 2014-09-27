#region File Header

// File Name:           IGameState.cs
// Author:              Andy Sanchez
// Creation Date:       8/26/2014   9:58 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Interface to a game state.
	/// </summary>
	public interface IGameState
	{   
		#region Properties
	
		/// <summary>
		/// Gets the name of the game state.
		/// </summary>
		/// <value>The name of the game state.</value>
		String Name
		{
			get;
		}
		
		/// <summary>
		/// Gets whether the game state is enabled.
		/// </summary>
		/// <value><c>True</c> if the game state is enabled.</value>
		Boolean IsEnabled
		{
			get;
		}
		
		/// <summary>
		/// Gets whether the game state is visible.
		/// </summary>
		/// <value><c>True</c> if the game state is visible.</value>
		Boolean IsVisible
		{
			get;
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Event handler for when the game state manager throws a game state changing event.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments with the information about the game states that are changing.</param>
		void OnGameStateChanging( System.Object sender, GameStateChangingEventArgs e );
		
		/// <summary>
		/// Event handler for when the game state manager thrown a game state changed event.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments with the information about the game states that changed.</param>
		void OnGameStateChanged( System.Object sender, GameStateChangedEventArgs e );
		
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		void OnEnter();
		
		/// <summary>
		/// Raised when the game state has been popped from the top of the stack.
		/// </summary>
		void OnExit();
		
		/// <summary>
		/// Raised when the game state has been enabled by the current game state being popped from the stack.
		/// </summary>
		void OnEnabled();
		
		/// <summary>
		/// Raised when the game state has been disabled by a new game state being pushed to the stack.
		/// </summary>
		void OnDisabled();

		/// <summary>
		/// Updates the game state logic.
		/// </summary>
		/// <param name="deltaTime">The delta time.</param>
		void Update( Single deltaTime );
		
		#endregion
	}
}
