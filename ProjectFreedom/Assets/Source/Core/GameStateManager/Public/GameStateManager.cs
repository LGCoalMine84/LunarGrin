#region File Header

// File Name:           GameStateManager.cs
// Author:              Andy Sanchez
// Creation Date:       8/28/2014   9:54 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Handles the game states in the application.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
	public sealed class GameStateManager : IGameStateManager
	{
		#region Constants
	
		/// <summary>
		/// The type of game service.
		/// </summary>
		private const ServiceType TypeOfGameService = ServiceType.GameStateManager;
		
		#endregion
	
		#region Private Fields
	    	
	    /// <summary>
	    /// Events that triggers when in transition from the current game state to a new game state.
	    /// </summary>
	    private event EventHandler<GameStateChangingEventArgs> onStateChanging = null;
	    	
		/// <summary>
		/// Event that triggers once the application has fully transitioned to a new game state.
		/// </summary>
		private event EventHandler<GameStateChangedEventArgs> onStateChanged = null;
	
		/// <summary>
		/// The stack of game states in the application.
		/// </summary>
		private Stack<IGameState> gameStates = null;
		
		/// <summary>
		/// The current and topmost game state in the stack.
		/// </summary>
		private IGameState currentState = null;
		
		/// <summary>
		/// The game state prior to the current game state.
		/// </summary>
		private IGameState previousState = null;

		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the type of the game service.
		/// </summary>
		/// <value>The type of the game service.</value>
		public ServiceType GameServiceType
		{
			get
			{
				return TypeOfGameService;
			}
		}
		
		#endregion

		#region Constructor
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.GameStateManager"/> class.
		/// </summary>
		public GameStateManager()
		{
			gameStates = new Stack<IGameState>();
		}

		#endregion

		#region Public Methods
		
		#region IGameStateManager

		/// <summary>
		/// Registers a game state changing handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changing event handler to add.</param>
		/// <exception cref="ArgumentNullException">Unable to register the game state changing handler because the handler is invalid.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void RegisterStateChangingEvent( EventHandler<GameStateChangingEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to register the game state changing handler because the handler is invalid." );
			}
			
			onStateChanging += handler;
		}
		
		/// <summary>
		/// Unregisters a game state changing handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changing event handler to remove.</param>
		/// <exception cref="ArgumentNullException">Unable to unregister the game state changing handler because the handler is invalid.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void UnregisterStateChangingEvent( EventHandler<GameStateChangingEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to unregister the game state changing handler because the handler is invalid." );
			}
			
			onStateChanging -= handler;
		}

		/// <summary>
		/// Registers a game state changed handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changed event handler to register.</param>
		/// <exception cref="ArgumentNullException">Unable to register the game state changed handler because the handler is invalid.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void RegisterStateChangedEvent( EventHandler<GameStateChangedEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to register the game state changed handler because the handler is invalid." );
			}
			
			onStateChanged += handler;
		}
		
		/// <summary>
		/// Unregisters a game state changed handler to the game state manager.
		/// </summary>
		/// <param name="handler">The game state changed event handler to unregister.</param>
		/// <exception cref="ArgumentNullException">Unable to unregister the game state changed handler because the handler is invalid.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void UnregisterStateChangedEvent( EventHandler<GameStateChangedEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to unregister the game state changed handler because the handler is invalid." );
			}
			
			onStateChanged -= handler;
		}
		
		/// <summary>
		/// Pushes a game state to the game state stack.
		/// </summary>
		/// <param name="state">The state to push.</param>
		/// <exception cref="InvalidOperationException">Unable to push the game state because failed to add the state to the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void PushState( IGameState state )
		{
			if( currentState != null )
			{
				previousState = currentState;
				previousState.OnDisabled();
				
				if( onStateChanging != null )
				{
					onStateChanging( this, new GameStateChangingEventArgs( currentState.Name, state.Name ) );
				}
			}

			try
			{
				AddGameStateToStackTop( state );
			}
			catch( Exception ex )
			{
				currentState = previousState;
			
				throw new InvalidOperationException( "Unable to push the game state because failed to add the state to the stack.", ex );
			}
			
			currentState = state;
			currentState.OnEnter();
			
			if( onStateChanged != null )
			{
				onStateChanged( this, new GameStateChangedEventArgs( ( previousState != null ) ? previousState.Name : null, currentState.Name ) );
			}
		}
		
		/// <summary>
		/// Pops the current game state from the stack.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to pop the current game state because there are no previous game states to fallback to.</exception>
		/// <exception cref="NullReferenceException">Unable to pop the current game state because the current game state reference is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to pop the current game state because failed to remove the game state from the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void PopState()
		{
			if( !IsGameStatePopValid() )
			{
				throw new InvalidOperationException( "Unable to pop the current game state because there are no previous game states to fallback to." );
			}
		
			if( currentState == null )
			{
				throw new NullReferenceException( "Unable to pop the current game state because the current game state reference is invalid." );
			}
		
			IGameState stateToRemove = currentState;
			stateToRemove.OnExit();
			
			if( onStateChanging != null )
			{
				onStateChanging( this, new GameStateChangingEventArgs( currentState.Name, previousState.Name ) );
      		}
      
      		try
			{
				RemoveGameStateFromStackTop();
			}
			catch( Exception ex )
			{
				currentState = stateToRemove;
			
				throw new InvalidOperationException( "Unable to pop the current game state because failed to remove the game state from the stack.", ex );
			}	

			currentState = previousState;
			currentState.OnEnabled();
			
			try
			{
				previousState = GetPreviousGameState();
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to pop the current game state because failed to get a valid previous state from the stack.", ex );
			}
			
			if( onStateChanged != null )
			{
				onStateChanged( this, new GameStateChangedEventArgs( stateToRemove.Name, currentState.Name ) );
			}
		}

		/// <summary>
		/// Removes all previous game states and adds a new game state to the stack.
		/// </summary>
		/// <param name="state">The new game state to add.</param>
		/// <exception cref="InvalidOperationException">Unable to change the state because failed to remove previous states from the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void ChangeState( IGameState state )
		{
			try
			{
				while( gameStates.Count > 0 )
				{
					RemoveGameStateFromStackTop();
				}
				
				PushState( state );
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to change the state because failed to remove previous states from the stack.", ex );
			}
		}	
		
		/// <summary>
		/// Checks whether the game state manager contains the game state parameter.
		/// </summary>
		/// <param name="state">The game state to check.</param>
		/// <returns><c>True</c> if state was containes.</returns>
		/// <exception cref="ArgumentNullException">Unable to find the game state because it was not found within the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public Boolean ContainsState( IGameState state )
		{
			if( state == null )
			{
				throw new ArgumentNullException( "Unable to find the game state because it was not found within the stack." );
			}

			return gameStates.Contains( state );
		}
		
		/// <summary>
		/// Gets the current game state.
		/// </summary>
		/// <returns>The current game state.</returns>
		/// <exception cref="ArgumentNullException">Unable to get the current game state because the game state is invalid.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public IGameState GetCurrentState()
		{
			if( currentState == null )
			{
				//throw new ArgumentNullException( "Unable to get the current game state because the game state is invalid." );
			}
			
			return currentState;
		}
		
		/// <summary>
		/// Gets the previous game state.
		/// </summary>
		/// <returns>The previous game state.</returns>
		/// <remarks>
		/// Will return <c>null</c> if the previous state does not exist.
		/// </remarks>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public IGameState GetPreviousState()
		{
			return previousState;
		}
		
		/// <summary>
		/// Update the game state manager logic. This method will update the current game state.
		/// </summary>
		/// <param name="deltaTime">The delta time.</param>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void Update( Single deltaTime )
		{
			if( currentState != null )
			{
				currentState.Update( deltaTime );
			}
		}
		
		/// <summary>
		/// Cleans up the game state manager.
		/// </summary>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void Destroy()
		{
			onStateChanging = null;
			onStateChanged = null;
			
			if( gameStates != null )
			{
				gameStates.Clear();
				gameStates = null;
			}
			
			currentState = null;
			previousState = null;
		}

		#endregion

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// Adds the state to the top of the stack.
		/// </summary>
		/// <param name="state">The game state to add.</param>
		/// <exception cref="ArgumentNullException">Unable to add the state to the top of the stack because the state is invalid.</exception>
		private void AddGameStateToStackTop( IGameState state )
		{
			if( state == null )
			{
				throw new ArgumentNullException( "Unable to add the state to the top of the stack because the state is invalid." );
			}
		
			gameStates.Push( state );
			
			onStateChanging += state.OnGameStateChanging;
			onStateChanged += state.OnGameStateChanged;
		}
		
		/// <summary>
		/// Removes the game state from the top of the stack.
		/// </summary>
		/// <exception cref="NullReferenceException">Unable to remove the topmost game state in the stack because the state in the stack is invalid.</exception>
		private void RemoveGameStateFromStackTop()
		{
			IGameState stateToRemove = null;
			
			try
			{
				stateToRemove = gameStates.Pop();
			}
			catch( Exception ex )
			{
				throw new NullReferenceException( "Unable to remove the topmost game state in the stack because the state in the stack is invalid.", ex );
			}
			
			if( onStateChanging != null )
			{
				onStateChanging -= stateToRemove.OnGameStateChanging;
			}
			
			if( onStateChanged != null )
			{
				onStateChanged -= stateToRemove.OnGameStateChanged;
			}
		}
		
		/// <summary>
		/// Gets the topmost game state in the stack.
		/// </summary>
		/// <returns>The current game state.</returns>
		/// <exception cref="NullReferenceException">Unable to get the current game state because the topmost state in the stack is invalid.</exception>
		private IGameState GetCurrentGameState()
		{
			IGameState currentState = null;
			
			try
			{
				currentState = gameStates.Peek();
			}
			catch( Exception ex )
			{
				throw new NullReferenceException( "Unable to get the current game state because the topmost state in the stack is invalid.", ex );
			}
			
			return currentState;
		}
		
		/// <summary>
		/// Gets the prior to current game state in the stack.
		/// </summary>
		/// <returns>The previous game state.</returns>
		/// <exception cref="InvalidOperationException">Unable to get the previous game state because the stack is invalid.</exception>
		private IGameState GetPreviousGameState()
		{
			IGameState[] states = gameStates.ToArray();
			if( states == null )
			{
				throw new InvalidOperationException( "Unable to get the previous game state because the stack is invalid." );
			}
			
			previousState = ( states.Length >= 2 ) ? states[states.Length - 2] : null;
			
			return previousState;
		}
		
		/// <summary>
		/// Determines whether is valid to pop a game state from the stack.
		/// </summary>
		/// <returns><c>True</c> if it is valid to pop a game from the stack.</returns>
		private Boolean IsGameStatePopValid()
		{
			return gameStates.Count >= 2;
		}
		
		#endregion
	}
}
