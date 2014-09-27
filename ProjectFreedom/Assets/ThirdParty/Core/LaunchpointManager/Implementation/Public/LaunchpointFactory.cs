#region File Header

// File Name:           LaunchpointFactory.cs
// Author:              Andy Sanchez
// Creation Date:       9/20/2014   9:01 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
	public static class LaunchpointFactory
	{
		public static Launchpoint CreateLaunchpoint( LaunchpointType typeOfLaunchpoint, ILaunchpoint baseLaunchpoint )
		{
			switch( typeOfLaunchpoint )
			{
				case LaunchpointType.Invalid:
					return new Launchpoint();
					
				case LaunchpointType.AIBrain:
					return new LaunchpointAIBrain();	
			}
			
			return null;
		}
	}
}
