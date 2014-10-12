#region File Header

// File Name:           PlayerFlightControlsMain.cs
// Author:              Andy Sanchez
// Creation Date:       10/11/2014   10:29 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using LunarGrin.Core;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// Main entry point to the player flight controls unit test.
	/// </summary>
	public sealed class PlayerFlightControlsMain : Main
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerFlightControlsMain"/> class.
		/// </summary>
		public PlayerFlightControlsMain()
		{
			theGame = new PlayerFlightControlsGame();
		}
    
    #endregion
	}
}
