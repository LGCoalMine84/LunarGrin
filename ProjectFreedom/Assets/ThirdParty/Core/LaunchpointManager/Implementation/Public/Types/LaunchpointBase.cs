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
		#region Contructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointBase"/> class.
		/// </summary>
		public LaunchpointBase()
			: base( LaunchpointType.Base )
		{
		
		}
		
		#endregion
	}
}
