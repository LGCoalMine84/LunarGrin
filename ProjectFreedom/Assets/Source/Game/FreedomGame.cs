#region File Header

// File Name:           FreedomGame.cs
// Author:              Andy Sanchez
// Creation Date:       8/31/2014   7:34 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Core;

#endregion

namespace Freedom
{
	/// <summary>
	/// Main class for the Freedom game.
	/// </summary>
	public class FreedomGame : Game
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="FreedomGame.FreedomGame"/> class.
		/// </summary>
		public FreedomGame() :
			base()
		{
			
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Initializes the game instance.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			
			MainMenuState mainMenuState = new MainMenuState( "MainMenuState" );
			
			GameServices.StateManager.PushState( mainMenuState );
		}
		
		/// <summary>
		/// Updates the main logic of the game.
		/// </summary>
		/// <param name="deltaTime"></param>
		public override void Update( Single deltaTime )
		{
			base.Update( deltaTime );
		}
		
		/// <summary>
		/// Destroys the game instance.
		/// </summary>
		public override void Destroy()
		{
			base.Destroy();
		}
		
		#endregion
	}
}
