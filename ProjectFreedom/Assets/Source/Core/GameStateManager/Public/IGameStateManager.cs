#region File Header

// File Name:           IGameStateManager.cs
// Author:              Andy Sanchez
// Creation Date:       8/26/2014   10:56 PM
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
	/// Interface to the game state manager that handles the game states of the application.
	/// </summary>
	public interface IGameStateManager
	{		
		#region Public Methods

		/// <summary>
		/// Registers a game state changing handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changing event handler to add.</param>
		void RegisterStateChangingEvent( EventHandler<GameStateChangingEventArgs> handler );
		
		/// <summary>
		/// Unregisters a game state changing handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changing event handler to remove.</param>
		void UnregisterStateChangingEvent( EventHandler<GameStateChangingEventArgs> handler );

		/// <summary>
		/// Registers a game state changed handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changed event handler to register.</param>
		void RegisterStateChangedEvent( EventHandler<GameStateChangedEventArgs> handler );
		
		/// <summary>
		/// Unregisters a game state changed handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changed event handler to unregister.</param>
		void UnregisterStateChangedEvent( EventHandler<GameStateChangedEventArgs> handler );

		/// <summary>
		/// Pushes a game state to the game state stack.
		/// </summary>
		/// <param name="state">The state to push.</param>
		void PushState( IGameState state );
		
		/// <summary>
		/// Pops the current game state from the stack.
		/// </summary>
		void PopState();
		
		/// <summary>
		/// Removes all previous game states and adds a new game state to the stack.
		/// </summary>
		/// <param name="state">The new game state to add.</param>
		void ChangeState( IGameState state );

		/// <summary>
		/// Checks whether the game state manager contains the game state parameter.
		/// </summary>
		/// <param name="state">The game state to check.</param>
		/// <returns><c>True</c> if state was containes.</returns>
		Boolean ContainsState( IGameState state );
		
		/// <summary>
		/// Gets the current game state.
		/// </summary>
		/// <returns>The current game state.</returns>
		IGameState GetCurrentState();
		
		/// <summary>
		/// Gets the previous game state.
		/// </summary>
		/// <returns>The previous game state.</returns>
		IGameState GetPreviousState();
		
		/// <summary>
		/// Update the game state manager logic. This method will update the current game state.
		/// </summary>
		/// <param name="deltaTime">The delta time.</param>
		void Update( Single deltaTime );
		
		/// <summary>
		/// Cleans up the game state manager.
		/// </summary>
		void Destroy();
		
		#endregion
	}
}
