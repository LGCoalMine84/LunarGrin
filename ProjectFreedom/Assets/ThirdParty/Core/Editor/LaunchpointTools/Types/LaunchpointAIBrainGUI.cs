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

using UnityEditor;

#endregion

namespace LunarGrin.Core.Tools
{
	/// <summary>
	/// Displays information of an AI brain launchpoint.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.Tools.LaunchpointGUI"/>
	public sealed class LaunchpointAIBrainGUI : LaunchpointGUI
	{
		#region Private Fields
	
		/// <summary>
		/// The type of the AI brain.
		/// </summary>
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
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointAIBrainGUI"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint object to query the data from.</param>
		/// <exception cref="ArgumentException">Unable to create an AI brain launchpoint GUI because the launchpoint object is not of type AIBrain.</exception>
		public LaunchpointAIBrainGUI( ILaunchpoint launchpointObj ) : 
			base( launchpointObj )
		{
			if( launchpointObj.Type != LaunchpointType.AIBrain || !( launchpointObj is LaunchpointAIBrain ) )
			{
				throw new ArgumentException( "Unable to create an AI brain launchpoint GUI because the launchpoint object is not of type AIBrain." );
			}
			
			brainType = ((LaunchpointAIBrain)launchpointObj).BrainType;
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Draws the launchpoint AIBrain GUI.
		/// </summary>
		/// <remarks>
		/// This method is meant to be called from within the OnGUI method in the <see cref="LunarGrin.Core.Tools.LaunchpointEditor"/> class.
		/// </remarks>
		public override void OnGUI()
		{
			base.OnGUI();

			brainType = EditorGUILayout.IntField( "Brain Type", brainType );
		}
		
		#endregion
	}
}
