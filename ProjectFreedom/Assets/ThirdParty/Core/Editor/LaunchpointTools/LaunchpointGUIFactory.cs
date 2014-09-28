#region File Header

// File Name:           LaunchpointGUIFactory.cs
// Author:              Andy Sanchez
// Creation Date:       9/27/2014   7:31 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

#endregion

namespace LunarGrin.Core.Tools
{
	/// <summary>
	/// 
	/// </summary>
	public static class LaunchpointGUIFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// <param name="launchpointObj"></param>
		public static LaunchpointBaseGUI CreateLaunchpointGUI( ILaunchpoint launchpointObj )
		{
			if( launchpointObj == null )
			{
				throw new ArgumentNullException( "Unable to create a launchpoint GUI because the launchpoint object is invalid. " );
			}
		
			switch( launchpointObj.Type )
			{
				case LaunchpointType.Base:
					return new LaunchpointBaseGUI( launchpointObj );
					
				case LaunchpointType.AIBrain:
					return new LaunchpointAIBrainGUI( launchpointObj );
				
				default:
					// log error.
					break;
			}
			
			return null;
		}
	}
}
