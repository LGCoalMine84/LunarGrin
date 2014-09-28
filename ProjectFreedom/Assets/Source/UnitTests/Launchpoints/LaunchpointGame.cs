#region File Header

// File Name:           LaunchpointGame.cs
// Author:              Andy Sanchez
// Creation Date:       9/28/2014   2:38 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using LunarGrin.Core;

#endregion

namespace LunarGrin.UnitTests.LaunchpointUnitTest
{
	/// <summary>
	/// Main class for the launchpoint unit test game.
	/// </summary>
	public sealed class LaunchpointGame : Game
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.LaunchpointUnitTest.LaunchpointGame"/> class.
		/// </summary>
		public LaunchpointGame() :
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
