#region File Header

// File Name:           LaunchpointAIBrain.cs
// Author:              Andy Sanchez
// Creation Date:       9/14/2014   5:29 PM
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
	/// Contains data for an AI brain launchpoint.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.Launchpoint"/>
	public sealed class LaunchpointAIBrain : Launchpoint
	{
		#region Data Class
		
		/// <summary>
		/// 
		/// </summary>
		public class LaunchpointAIBrainData
		{
			public Int32 brainType;
		}
		
		#endregion
	
		#region Private Fields
		
		/// <summary>
		/// The type of the AI brain.
		/// </summary>
		[SerializeField]
		private Int32 brainType = 0;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the type of the AI brain.
		/// </summary>
		/// <value>The type of the AI brain.</value>
		public Int32 BrainType
		{
			get
			{
				return brainType;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointAIBrain"/> class.
		/// </summary>
		public LaunchpointAIBrain() 
			: base( LaunchpointType.AIBrain )
		{
			
		}
		
		/// <summary>
		/// Explicit constructor nitializes a new instance of the <see cref="LunarGrin.Core.LaunchpointAIBrain"/> class.
		/// </summary>
		/// <param name="launchpointName">The name of the launchpoint.</param>
		public LaunchpointAIBrain( String launchpointName )
			: base( LaunchpointType.AIBrain, launchpointName )
		{
			
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointAIBrain"/> class.
		/// </summary>
		/// <param name="launchpointName">The name of the launchpoint.</param>
		/// <param name="launchpointPosition">The position of the launchpoint.</param>
		/// <param name="launchpointRotation">The rotation of the launchpoint.</param>
		/// <param name="launchpointScale">The scale of the launchpoint.</param>
		public LaunchpointAIBrain( String launchpointName, Vector3 launchpointPosition, Quaternion launchpointRotation, Vector3 launchpointScale )
			: base( LaunchpointType.AIBrain, launchpointName, launchpointPosition, launchpointRotation, launchpointScale )
		{
			
		}
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointAIBrain"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint to copy from.</param>
		/// <param name="data">Optional parameter to set AI brain data.</param>
		public LaunchpointAIBrain( ILaunchpoint launchpointObj, LaunchpointAIBrainData data )
			: base( LaunchpointType.AIBrain, launchpointObj )
		{
			if( data != null )
			{
				brainType = data.brainType;
			}
		}
		
		#endregion
	}
}
