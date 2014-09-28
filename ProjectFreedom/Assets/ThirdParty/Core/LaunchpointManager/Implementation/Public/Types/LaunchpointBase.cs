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
	/// Holds 
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
		
		#region Public Methods
		
		#region IEquatable<T>
		
		/// <summary>
		/// Determines whether the specified <see cref="LunarGrin.Core.ILaunchpoint"/> is equal to the current launchpoint.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint to compare with the current launchpoint.</param>
		/// <returns><c>True</c> if the specified launchpoint is equal to the current launchpoint.</returns>
		/// <seealso cref="System.IEquatable&lt;T&gt;"/>
		/*public Boolean Equals( ILaunchpoint launchpointObj )
		{
			if( ReferenceEquals( launchpointObj, null ) )
			{
				return false;
			}
			
			if( ReferenceEquals( this, launchpointObj ) )
			{
				return true;
			}
			
			return type == launchpointObj.Type &&
				   name.Equals( launchpointObj.Name ) &&
				   position == launchpointObj.Position &&
				   rotation == launchpointObj.Rotation &&
				   scale == launchpointObj.Scale;
		}*/
		
		#endregion
		
		#region System.Object
		
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current base launchpoint.
		/// </summary>
		/// <param name="obj">The object to compare with the current base launchpoint object.</param>
		/// <returns><c>True</c> if the specified object is equal to the current base launchpoint.</returns>
		/// <seealso cref="System.Object"/>
		/*public override Boolean Equals( System.Object obj )
		{
			if( ReferenceEquals( obj, null ) )
			{
				return false;
			}
			
			if( !( obj is ILaunchpoint ) )
			{
				return false;
			}

			return Equals( (ILaunchpoint)obj );
		}
		
		/// <summary>
		/// Serves as a hash function for the <see cref="LunarGrin.Core.BaseLaunchpoint"/> class.
		/// </summary>
		/// <returns>The hash code of the launchpoint.</returns>
		/// <seealso cref="System.Object"/>
		public override Int32 GetHashCode()
		{
			return base.GetHashCode();
		}
		
		/// <summary>
		/// Gets information about the <see cref="LunarGrin.Core.BaseLaunchpoint"/> class.
		/// </summary>
		/// <returns>The information about the base launchpoint class.</returns>
		/// <seealso cref="System.Object"/>
		public override String ToString ()
		{
			return base.ToString();
		}*/
		
		#endregion
		
		#endregion
	}
}
