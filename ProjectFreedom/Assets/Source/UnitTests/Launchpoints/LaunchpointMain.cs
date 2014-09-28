#region File Header

// File Name:           LaunchpointMain.cs
// Author:              Andy Sanchez
// Creation Date:       9/28/2014   2:30 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using LunarGrin.Core;

#endregion

namespace LunarGrin.UnitTests.LaunchpointUnitTest
{
	/// <summary>
	/// Main entry point to the launchpoints unit test.
	/// </summary>
	public sealed class LaunchpointMain : Main
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.LaunchpointUnitTest.LaunchpointTest"/> class.
		/// </summary>
		public LaunchpointMain()
		{
			theGame = new LaunchpointGame();
		}
		
		#endregion
	}
}
