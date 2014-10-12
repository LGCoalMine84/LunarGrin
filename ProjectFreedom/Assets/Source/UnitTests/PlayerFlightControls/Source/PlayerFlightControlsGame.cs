#region File Header

// File Name:           PlayerFlightControlsGame.cs
// Author:              Andy Sanchez
// Creation Date:       10/11/2014   10:39 PM
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

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// Player flight controls game.
	/// </summary>
	public sealed class PlayerFlightControlsGame : Game
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerFlightControlsGame"/> class.
		/// </summary>
		public PlayerFlightControlsGame() :
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
			
			GameServices.StateManager.PushState( new GameplayState( "TODO: Change this state to the unit test one!" ) );
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
