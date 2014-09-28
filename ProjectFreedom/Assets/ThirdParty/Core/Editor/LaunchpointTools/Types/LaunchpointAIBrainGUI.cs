#region File Header

// File Name:           LaunchpointAIBrain.cs
// Author:              Andy Sanchez
// Creation Date:       9/14/2014   9:10 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;
using UnityEditor;

#endregion

namespace LunarGrin.Core.Tools
{
	/// <summary>
	/// Launchpoint AI brain GU.
	/// </summary>
	public sealed class LaunchpointAIBrainGUI : LaunchpointBaseGUI
	{
		public Int32 brainType = 0;
	
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointAIBrainGUI"/> class.
		/// </summary>
		/// <param name="lpBrain"></param>
		public LaunchpointAIBrainGUI( ILaunchpoint lpBrain ) : base( lpBrain )
		{
			brainType = ((LaunchpointAIBrain)lpBrain).BrainType;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void OnGUI()
		{
			base.OnGUI();
			
			/*if( baseLaunchpoint.Type == LaunchpointType.AIBrain )
			{
				LaunchpointAIBrain brain = (LaunchpointAIBrain)baseLaunchpoint;
				
				brain.BrainType = EditorGUILayout.IntField( "Brain Type", brain.BrainType );
			}*/
			
			if( currentType == LaunchpointType.AIBrain )
			{
				brainType = EditorGUILayout.IntField( "Brain Type", brainType );
			}
		}
	}
}
