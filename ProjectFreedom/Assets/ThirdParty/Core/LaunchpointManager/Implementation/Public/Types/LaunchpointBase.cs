#region File Header

// File Name:           LaunchpointBase.cs
// Author:              Andy Sanchez
// Creation Date:       9/27/2014   10:44 PM
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
	/// <summary>
	/// Represents an empty launchpoint.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.Launchpoint"/>
	public sealed class LaunchpointBase : Launchpoint
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointBase"/> class.
		/// </summary>
		public LaunchpointBase()
			: base()
		{
		
		}
		
		/// <summary>
		/// Explicit constructor nitializes a new instance of the <see cref="LunarGrin.Core.LaunchpointBase"/> class.
		/// </summary>
		/// <param name="launchpointName">The name of the launchpoint.</param>
		public LaunchpointBase( String launchpointName )
			: base( LaunchpointType.Base, launchpointName )
		{
			
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointBase"/> class.
		/// </summary>
		/// <param name="launchpointName">The name of the launchpoint.</param>
		/// <param name="launchpointPosition">The position of the launchpoint.</param>
		/// <param name="launchpointRotation">The rotation of the launchpoint.</param>
		/// <param name="launchpointScale">The scale of the launchpoint.</param>
		public LaunchpointBase( String launchpointName, Vector3 launchpointPosition, Quaternion launchpointRotation, Vector3 launchpointScale )
			: base( LaunchpointType.Base, launchpointName, launchpointPosition, launchpointRotation, launchpointScale )
		{
			
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointBase"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint to copy from.</param>
		public LaunchpointBase( ILaunchpoint launchpointObj )
			: base( LaunchpointType.Base, launchpointObj )
		{
			
		}
		
		#endregion
	}
}
