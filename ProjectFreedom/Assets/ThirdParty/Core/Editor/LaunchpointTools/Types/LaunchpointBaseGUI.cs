#region File Header

// File Name:           LaunchpointBaseGUI.cs
// Author:              Andy Sanchez
// Creation Date:       9/14/2014   9:04 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using LunarGrin.Core;

#endregion

namespace LunarGrin.Core.Tools
{
	/// <summary>
	/// Displays information of a base launchpoint. Holds common data that is shared across all launchpoint GUIs.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.Tools.LaunchpointGUI"/>
	public sealed class LaunchpointBaseGUI : LaunchpointGUI
	{
		#region Constructors
	
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointBaseGUI"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint object to query the data from.</param>
		public LaunchpointBaseGUI( ILaunchpoint launchpointObj ) :
			base( launchpointObj )
		{
			
		}
		
		#endregion
	}
}
