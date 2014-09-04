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
			
			IGameState state1 = new StartMenuGameState( "StartState" );
			IGameState state2 = new OptionsMenuGameState( "OptionsState" );
			
			GameServices.StateManager.PushState( state1 );
			GameServices.StateManager.PushState( state2 );
			GameServices.StateManager.PopState();
			GameServices.StateManager.PushState( state2 );
			
			GameServices.StateManager.ChangeState( state1 );
			
			Boolean isTrue = GameServices.StateManager.ContainsState( state1 );
			isTrue = GameServices.StateManager.ContainsState( state2 );
			
			if( !isTrue )
			{
				Debug.Log( "So far so good!" );
			}
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
