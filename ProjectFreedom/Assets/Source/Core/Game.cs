#region File Header

// File Name:           Game.cs
// Author:              Andy Sanchez
// Creation Date:       8/31/2014   5:59 PM
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
	/// The main game class.
	/// </summary>
	/// <remarks>
	/// All game classes must derive from this base class.
	/// </remarks>
	public abstract class Game
	{
		#region Protected Fields
		
		/// <summary>
		/// Manages the game states of the application.
		/// </summary>
		protected IGameStateManager stateManager = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the game state manager.
		/// </summary>
		/// <value>The game state manager.</value>
		public IGameStateManager StateManager
		{
			get
			{
				return stateManager;
			}
		}
		
		#endregion
		
		#region Constructors
		
		protected Game()
		{
			stateManager = new GameStateManager();
		}
		
		#endregion
		
		#region Public Methods
	
		/// <summary>
		/// Initializes the game instance.
		/// </summary>
		public virtual void Initialization()
		{
			
		}
	
		/// <summary>
		/// Updates the main logic of the game.
		/// </summary>
		/// <param name="deltaTime"></param>
		public virtual void Update( Single deltaTime )
		{
			if( stateManager != null )
			{
				stateManager.Update( deltaTime );
			}
		}
		
		/// <summary>
		/// Destroys the game instance.
		/// </summary>
		public virtual void Destroy()
		{
		
		}
		
		#endregion
	}
}
