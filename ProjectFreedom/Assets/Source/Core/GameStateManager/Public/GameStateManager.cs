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
		
		#region IGameService
		
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
		/// Registers an event handler for when the game state manager broadcasts a game state changing event.
		/// </summary>
		/// <param name="handler">The event handler to register.</param>
		/// <exception cref="ArgumentNullException">Unable to register the event handler to the game state changing event.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void RegisterStateChangingEvent( EventHandler<GameStateChangingEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to register the event handler to the game state changing event." );
			}
			
			onStateChanging += handler;
		}
		
		/// <summary>
		/// Unregisters an event handler from when the game state manager broadcasts a game state changing event.
		/// </summary>
		/// <param name="handler">The event handler to unregister.</param>
		/// <exception cref="ArgumentNullException">Unable to unregister the event handler from the game state changing event.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void UnregisterStateChangingEvent( EventHandler<GameStateChangingEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to unregister the event handler from the game state changing event." );
			}
			
			if( onStateChanging != null )
			{
				onStateChanging -= handler;
			}
		}
		
		/// <summary>
		/// Registers an event handler for when the game state manager broadcasts a game state changed event.
		/// </summary>
		/// <param name="handler">The event handler to register.</param>
		/// <exception cref="ArgumentNullException">Unable to register the event handler to the game state changed event.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void RegisterStateChangedEvent( EventHandler<GameStateChangedEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to register the event handler to the game state changed event." );
			}
			
			onStateChanged += handler;
		}
		
		/// <summary>
		/// Unregisters an event handler from when the game state manager broadcasts a game state changed event.
		/// </summary>
		/// <param name="handler">The event handler to unregister.</param>
		/// <exception cref="ArgumentNullException">Unable to unregister the event handler from the game state changed event.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void UnregisterStateChangedEvent( EventHandler<GameStateChangedEventArgs> handler )
		{
			if( handler == null )
			{
				throw new ArgumentNullException( "Unable to unregister the event handler from the game state changed event." );
			}
			
			if( onStateChanged != null )
			{
				onStateChanged -= handler;
			}
		}
		
		/// <summary>
		/// Pushes a game state to the game state stack.
		/// </summary>
		/// <param name="state">The state to push.</param>
		/// <exception cref="ArgumentNullException">Unable to push the game state because the game state is invalid.</exception>
		/// <exception cref="NullReferenceException">Unable to push the game state because the stack is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to push the game state because failed to add the state to the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void PushState( IGameState state )
		{
			if( state == null )
			{
				throw new ArgumentNullException( "Unable to push the game state because the game state is invalid." );
			}
		
			if( gameStates == null )
			{
				throw new NullReferenceException( "Unable to push the game state because the stack is invalid." );
			}
			
			if( onStateChanging != null )
			{
				onStateChanging( this, new GameStateChangingEventArgs( ( currentState != null ) ? currentState.Name : null, state.Name ) );
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
			
			if( currentState != null )
			{
				previousState = currentState;
				previousState.OnDisabled();
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
		/// <exception cref="NullReferenceException">Unable to pop the current game state because the stack is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to pop the current game state because there are no previous game states to fallback to.</exception>
		/// <exception cref="NullReferenceException">Unable to pop the current game state because the current game state reference is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to pop the current game state because failed to remove the game state from the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void PopState()
		{
			if( gameStates == null )
			{
				throw new NullReferenceException( "Unable to pop the current game state because the stack is invalid." );
			}
		
			if( gameStates.Count < 2 || previousState == null )
			{
				throw new InvalidOperationException( "Unable to pop the current game state because there are no previous game states to fallback to." );
			}
		
			if( currentState == null )
			{
				throw new NullReferenceException( "Unable to pop the current game state because the current game state reference is invalid." );
			}
			
			if( onStateChanging != null )
			{
				onStateChanging( this, new GameStateChangingEventArgs( currentState.Name, previousState.Name ) );
      		}
      		
			IGameState stateToRemove = currentState;
      
      		try
			{
				RemoveGameStateFromStackTop();
			}
			catch( Exception ex )
			{
				currentState = stateToRemove;
			
				throw new InvalidOperationException( "Unable to pop the current game state because failed to remove the game state from the stack.", ex );
			}
			
			stateToRemove.OnExit();

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
		/// <exception cref="NullReferenceException">Unable to change to a game state because the stack is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to change the game state because failed to remove previous states from the stack.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public void ChangeState( IGameState state )
		{
			if( gameStates == null )
			{
				throw new NullReferenceException( "Unable to change to a game state because the stack is invalid." );
			}
		
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
				throw new InvalidOperationException( "Unable to change the game state because failed to remove previous states from the stack.", ex );
			}
		}	
		
		/// <summary>
		/// Checks whether the game state manager contains the game state parameter.
		/// </summary>
		/// <param name="state">The game state to check.</param>
		/// <returns><c>True</c> if state was containes.</returns>
		/// <exception cref="ArgumentNullException">Unable to find the game state because it was not found within the stack.</exception>
		/// <exception cref="NullReferenceException">Unable to find the game state because the stack is invalid.</exception>
		/// <seealso cref="LunarGrin.Core.IGameStateManager"/>
		public Boolean ContainsState( IGameState state )
		{
			if( state == null )
			{
				throw new ArgumentNullException( "Unable to find the game state because it was not found within the stack." );
			}
			
			if( gameStates == null )
			{
				throw new NullReferenceException( "Unable to find the game state because the stack is invalid." );
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
				throw new ArgumentNullException( "Unable to get the current game state because the game state is invalid." );
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
		
		#endregion
	}
}
