#region File Header

// File Name:           GameState.cs
// Author:              Andy Sanchez
// Creation Date:       8/28/2014   11:00 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Base class for the game states in the application.
	/// </summary>
	/// <remarks>
	/// All game states in the application must derive from this base class.
	/// </remarks>
	/// <seealso cref="LunarGrin.Core.IGameState"/>
	public abstract class GameState : IGameState
	{
		#region Private Fields
		
		/// <summary>
		/// Name assigned to the game state.
		/// </summary>
		private String stateName = null;
	
		/// <summary>
		/// Determines whether the game state is visible.
		/// </summary>
		private Boolean isVisible = true;
		
		/// <summary>
		/// Determines whether the game state is enabled.
		/// </summary>
		private Boolean isEnabled = true;
	
		#endregion
	
		#region Properties
		
		/// <summary>
		/// Gets the name of the game state.
		/// </summary>
		/// <value>The name of the game state.</value>
		public String Name
		{
			get
			{
				return stateName;
			}
		}
		
		/// <summary>
		/// Gets whether the game state is enabled.
		/// </summary>
		/// <value><c>True</c> if the game state is enabled.</value>
		public Boolean IsEnabled
		{
			get
			{
				return isEnabled;
			}
		}
		
		/// <summary>
		/// Gets whether the game state is visible.
		/// </summary>
		/// <value><c>True</c> if the game state is visible.</value>
		public Boolean IsVisible
		{
			get
			{
				return isVisible;
			}
		}
				
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.GameState"/> class.
		/// </summary>
		public GameState()
		{
			
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.GameState"/> class.
		/// </summary>
		/// <param name="name">The game state name.</param>
		public GameState( String name )
		{
			stateName = name;
		}
		
		#endregion
		
		#region Public Methods
		
		#region IGameState
		
		/// <summary>
		/// Event handler for when the game state is changing.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The game state changing event arguments.</param>
		public virtual void OnGameStateChanging( System.Object sender, GameStateChangingEventArgs e )
		{
			
		}
		
		/// <summary>
		/// Event handler for when the game state has been changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The game state changed event arguments.</param>
		public virtual void OnGameStateChanged( System.Object sender, GameStateChangedEventArgs e )
		{
      		if( sender is IGameStateManager )
      		{
      			IGameStateManager stateManager = (IGameStateManager)sender;
				if( stateManager.GetCurrentState() != null )
				{
      				isEnabled = ( stateManager.GetCurrentState() == this );
      				isVisible = isEnabled;
				}
      		}
    	}
    	
		/// <summary>
		/// Raised when the game state has been pushed to the top of the stack.
		/// </summary>
		public virtual void OnEnter()
		{
		
		}
		
		/// <summary>
		/// Raised when the game state has been popped from the top of the stack.
		/// </summary>
		public virtual void OnExit()
		{
		
		}
		
		/// <summary>
		/// Raised when the game state has been enabled by the current game state being popped from the stack.
		/// </summary>
		public virtual void OnEnabled()
		{
		
		}
		
		/// <summary>
		/// Raised when the game state has been disabled by a new game state being pushed to the stack.
		/// </summary>
		public virtual void OnDisabled()
		{
		
		}
		
		/// <summary>
		/// Updates the game state logic.
		/// </summary>
		/// <param name="time">The delta time.</param>
		public abstract void Update( Single deltaTime );
		
		#endregion
		
		#endregion
	}
}
