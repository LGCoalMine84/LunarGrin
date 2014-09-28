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
		
		#endregion
	}
}
