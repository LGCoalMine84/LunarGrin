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
		/// Gets or sets the position of the launchpoint.
		/// </summary>
		/// <value>The position of the launchpoint.</value>
		public Vector3 Position
		{
			get
			{
				return position;
			}
			
			set
			{
				position = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the rotation of the launchpoint.
		/// </summary>
		/// <value>The rotation of the launchpoint.</value>
		public Quaternion Rotation
		{
			get
			{
				return rotation;
			}
			
			set
			{
				rotation = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the scale of the launchpoint.
		/// </summary>
		/// <value>The scale of the launchpoint.</value>
		public Vector3 Scale
		{
			get
			{
				return scale;
			}
			
			set
			{
				scale = value;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		protected Launchpoint()
		{
			type = LaunchpointType.Base;
			name = "NoName";
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="launchpointType">The type of launchpoint.</param>
		protected Launchpoint( LaunchpointType launchpointType ) 
			: this( launchpointType, "NoName" )
		{
		
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="launchpointType">The type of launchpoint.</param>
		/// <param name="launchpointName">The name of the launchpoint.</param>
		/// <exception cref="ArgumentException">Unable to create the launchpoint because the launchpoint type provided is invalid.</exception>
		/// <exception cref="ArgumentNullException">Unable to create the launchpoint because the name is invalid.</exception>
		protected Launchpoint( LaunchpointType launchpointType, String launchpointName )
		{
			if( launchpointType == LaunchpointType.Invalid )
			{
				throw new ArgumentException( "Unable to create the launchpoint because the launchpoint type provided is invalid." );
			}
			
			if( String.IsNullOrEmpty( launchpointName ) )
			{
				throw new ArgumentNullException( "Unable to create the launchpoint because the name is invalid." );
			}
		
			type = launchpointType;
			name = launchpointName;
		}

		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="launchpointType">The type of the launchpoint.</param>
		/// <param name="launchpointName">The name of the launchpoint.</param>
		/// <param name="launchpointPosition">The position of the launchpoint.</param>
		/// <param name="launchpointRotation">The rotation of the launchpoint.</param>
		/// <param name="launchpointScale">The scale of the launchpoint.</param>
		/// <exception cref="ArgumentNullException">Unable to create the launchpoint because the name is invalid.</exception>
		protected Launchpoint( LaunchpointType launchpointType, String launchpointName, Vector3 launchpointPosition, Quaternion launchpointRotation, Vector3 launchpointScale )
			: this( launchpointType, launchpointName )
		{
			position = launchpointPosition;
			rotation = launchpointRotation;
			scale = launchpointScale;
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint to copy from.</param>
		/// <remarks>
		/// Copies the data from an existing launchpoint.
		/// </remarks>
		protected Launchpoint( ILaunchpoint launchpointObj )
			: this( launchpointObj.Type, launchpointObj.Name, launchpointObj.Position, launchpointObj.Rotation, launchpointObj.Scale )
		{
			
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Launchpoint"/> class.
		/// </summary>
		/// <param name="typeOfLaunchpoint">The type of launchpoint.</param>
		/// <param name="launchpointObj">The launchpoint to copy from.</param>
		/// <exception cref="ArgumentException">Unable to create the launchpoint because the type is invalid.</exception>
		/// <remarks>
		/// Copies the data from an existing launchpoint and assigns a new type to the new launchpoint.
		/// </remarks>
		protected Launchpoint( LaunchpointType typeOfLaunchpoint, ILaunchpoint launchpointObj )
			: this( launchpointObj )
		{
			if( typeOfLaunchpoint == LaunchpointType.Invalid )
			{
				throw new ArgumentException( "Unable to create the launchpoint because the type is invalid." );
			}
			
			type = typeOfLaunchpoint;
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
				   name.Equals( launchpointObj.Name, StringComparison.OrdinalIgnoreCase ) &&
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
			if( ReferenceEquals( obj, null ) || !( obj is ILaunchpoint ) )
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
