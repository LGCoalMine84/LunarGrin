#region File Header

// File Name:           Launchpoint.cs
// Author:              Andy Sanchez
// Creation Date:       9/13/2014   5:41 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Text;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Default information of a launchpoint. Holds common data that is shared across all launchpoints.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.ILaunchpoint"/>
	[Serializable]
	public abstract class Launchpoint : ILaunchpoint
	{
		#region Protected Fields
		
		/// <summary>
		/// The type of the launchpoint.
		/// </summary>
		[SerializeField]
		protected LaunchpointType type = LaunchpointType.Invalid;
		
		/// <summary>
		/// The name of the launchpoint.
		/// </summary>
		[SerializeField]
		protected String name = null;
		
		/// <summary>
		/// The position of the launchpoint.
		/// </summary>
		[SerializeField]
		protected Vector3 position = Vector3.zero;
		
		/// <summary>
		/// The rotation of the launchpoint.
		/// </summary>
		[SerializeField]
		protected Quaternion rotation = Quaternion.identity;
		
		/// <summary>
		/// The scale of the launchpoint.
		/// </summary>
		[SerializeField]
		protected Vector3 scale = Vector3.one;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the type of the launchpoint.
		/// </summary>
		/// <value>The type of the launchpoint.</value>
		public LaunchpointType Type
		{
			get
			{
				return type;
			}
		}
		
		/// <summary>
		/// Gets the name of the launchpoint.
		/// </summary>
		/// <value>The name of the launchpoint.</value>
		public String Name
		{
			get
			{
				return name;
			}
		}
		
		/// <summary>
		/// Gets the position of the launchpoint.
		/// </summary>
		/// <value>The position of the launchpoint.</value>
		public Vector3 Position
		{
			get
			{
				return position;
			}
		}
		
		/// <summary>
		/// Gets the rotation of the launchpoint.
		/// </summary>
		/// <value>The rotation of the launchpoint.</value>
		public Quaternion Rotation
		{
			get
			{
				return rotation;
			}
		}
		
		/// <summary>
		/// Gets the scale of the launchpoint.
		/// </summary>
		/// <value>The scale of the launchpoint.</value>
		public Vector3 Scale
		{
			get
			{
				return scale;
			}
		}
		
		#endregion
	
		#region Contructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		protected Launchpoint()
		{
		
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="lpType">The type of launchpoint to create.</param>
		/// <exception cref="ArgumentException">Unable to create the base launchpoint because the launchpoint type provided is invalid.</exception>
		protected Launchpoint( LaunchpointType lpType )
		{
			if( lpType == LaunchpointType.Invalid )
			{
				throw new ArgumentException( "Unable to create the base launchpoint because the launchpoint type provided is invalid." );
			}
		
			type = lpType;
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="lpType">The type of the launchpoint.</param>
		/// <param name="lpName">The name of the launchpoint.</param>
		/// <param name="lpPosition">The position of the launchpoint.</param>
		/// <param name="lpRotation">The rotation of the launchpoint.</param>
		/// <param name="lpScale">The scale of the launchpoint.</param>
		/// <exception cref="ArgumentException">Unable to create the base launchpoint because the launchpoint type provided is invalid.</exception>
		/// <exception cref="ArgumentNullException">Unable to create the base launchpoint because the name is invalid.</exception>
		protected Launchpoint( LaunchpointType lpType, String lpName, Vector3 lpPosition, Quaternion lpRotation, Vector3 lpScale )
		{
			if( lpType == LaunchpointType.Invalid )
			{
				throw new ArgumentException( "Unable to create the base launchpoint because the launchpoint type provided is invalid." );
			}
			
			if( String.IsNullOrEmpty( lpName ) )
			{
				throw new ArgumentNullException( "Unable to create the base launchpoint because the name is invalid." );
			}
			
			type = lpType;
			name = lpName;
			
			position = lpPosition;
			rotation = lpRotation;
			scale = lpScale;
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint to copy from.</param>
		/// <exception cref="ArgumentNullException">Unable to create the base launchpoint because the launchpoint to copy from is invalid.</exception>
		/// <exception cref="ArgumentException">Unable to create the base launchpoint because the launchpoint object has an invalid type.</exception>
		/// <exception cref="NullReferenceException">Unable to create the base launchpoint because the launchpoint object has an invalid name.</exception>
		protected Launchpoint( ILaunchpoint launchpointObj )
		{
			if( launchpointObj == null )
			{
				throw new ArgumentNullException( "Unable to create the base launchpoint because the launchpoint to copy from is invalid." );
			}
			
			if( launchpointObj.Type == LaunchpointType.Invalid )
			{
				throw new ArgumentException( "Unable to create the base launchpoint because the launchpoint object has an invalid type." );
			}
			
			if( String.IsNullOrEmpty( launchpointObj.Name ) )
			{
				throw new NullReferenceException( "Unable to create the base launchpoint because the launchpoint object has an invalid name." );
			}
			
			type = launchpointObj.Type;
			name = launchpointObj.Name;
			
			position = launchpointObj.Position;
			rotation = launchpointObj.Rotation;
			scale = launchpointObj.Scale;
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
		public Boolean Equals( ILaunchpoint launchpointObj )
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
		}
		
		#endregion
		
		#region System.Object
		
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current base launchpoint.
		/// </summary>
		/// <param name="obj">The object to compare with the current base launchpoint object.</param>
		/// <returns><c>True</c> if the specified object is equal to the current base launchpoint.</returns>
		/// <seealso cref="System.Object"/>
		public override Boolean Equals( System.Object obj )
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
		/// Serves as a hash function for the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <returns>The hash code of the launchpoint.</returns>
		/// <seealso cref="System.Object"/>
		public override Int32 GetHashCode()
		{
			return type.ToString().GetHashCode() ^
				   name.GetHashCode() ^
				   position.x.GetHashCode() ^
				   position.y.GetHashCode() ^
				   position.z.GetHashCode() ^
				   rotation.eulerAngles.x.GetHashCode() ^
				   rotation.eulerAngles.y.GetHashCode() ^
				   rotation.eulerAngles.z.GetHashCode() ^
				   scale.x.GetHashCode() ^
				   scale.y.GetHashCode() ^
				   scale.z.GetHashCode();
		}
		
		/// <summary>
		/// Gets information about the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <returns>The information about the base launchpoint class.</returns>
		/// <seealso cref="System.Object"/>
		public override String ToString ()
		{
			StringBuilder strBuilder = new StringBuilder();
			
			strBuilder.Append( "Launchpoint Type: " );
			strBuilder.Append( type.ToString() );
			strBuilder.AppendLine();
			
			strBuilder.Append( "Launchpoint Name: " );
			strBuilder.Append( !String.IsNullOrEmpty( name ) ? name : String.Empty );
			strBuilder.AppendLine();
			
			strBuilder.Append( "Launchpoint Position: " );
			strBuilder.Append( position.ToString() );
			strBuilder.AppendLine();
			
			strBuilder.Append( "Launchpoint Rotation: " );
			strBuilder.Append( rotation.eulerAngles.ToString() );
			strBuilder.AppendLine();
			
			strBuilder.Append( "Launchpoint Scale: " );
			strBuilder.Append( scale.ToString() );
			strBuilder.AppendLine();
			
			return strBuilder.ToString();
		}
		
		#endregion
		
		#endregion
	}
}
