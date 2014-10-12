#region File Header

// File Name:           ILaunchpoint.cs
// Author:              Andy Sanchez
// Creation Date:       9/13/2014   4:07 PM
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
	/// Data that a launchpoint must provide to the application.
	/// </summary>
	/// <seealso cref="System.IEquatable&lt;T&gt;"/>
	public interface ILaunchpoint : IEquatable<ILaunchpoint>
	{
		#region Properties
		
		/// <summary>
		/// Gets the type of the launchpoint.
		/// </summary>
		/// <value>The type of the launchpoint.</value>
		LaunchpointType Type
		{
			get;
		}
		
		/// <summary>
		/// Gets the name of the launchpoint.
		/// </summary>
		/// <value>The name of the launchpoint.</value>
		String Name
		{
			get;
		}
		
		/// <summary>
		/// Gets or sets the position of the launchpoint.
		/// </summary>
		/// <value>The position of the launchpoint.</value>
		Vector3 Position
		{
			get;
			set;
		}
		
		/// <summary>
		/// Gets or sets the rotation of the launchpoint.
		/// </summary>
		/// <value>The rotation of the launchpoint.</value>
		Quaternion Rotation
		{
			get;
			set;
		}
		
		/// <summary>
		/// Gets or sets the scale of the launchpoint.
		/// </summary>
		/// <value>The scale of the launchpoint.</value>
		Vector3 Scale
		{
			get;
			set;
		}
		
		#endregion
	}
}
