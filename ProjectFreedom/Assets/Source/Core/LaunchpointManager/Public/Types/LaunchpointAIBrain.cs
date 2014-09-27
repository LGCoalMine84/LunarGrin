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
using System.Collections;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Launchpoint AI brain.
	/// </summary>
	public sealed class LaunchpointAIBrain : Launchpoint
	{
		#region Private Fields
		
		[SerializeField]
		private Int32 brainType = 0;
		
		#endregion
		
		public Int32 BrainType
		{
			get
			{
				return brainType;
			}
			
			set
			{
				brainType = value;
			}
		}
	
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
