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
	/// The game class specific to the application must derived from this class.
	/// </remarks>
	public abstract class Game
	{	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.Game"/> class.
		/// </summary>
		protected Game()
		{
			
		}
		
		#endregion
		
		#region Public Methods
	
		/// <summary>
		/// Initializes the game instance.
		/// </summary>
		public virtual void Initialize()
		{
			
		}
	
		/// <summary>
		/// Updates the main logic of the game.
		/// </summary>
		/// <param name="deltaTime"></param>
		public virtual void Update( Single deltaTime )
		{
			GameServices.StateManager.Update( deltaTime );
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
