#region File Header

// File Name:           BaseLaunchpoint.cs
// Author:              Andy Sanchez
// Creation Date:       9/14/2014   9:04 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;
using UnityEditor;

using LunarGrin.Core;

#endregion

namespace LunarGrin.Core.Tools
{
	/// <summary>
	/// Base launchpoint.
	/// </summary>
	public class LaunchpointBaseGUI
	{
		#region Private Fields
		
		/// <summary>
		/// The launchpoint object correspnding to this GUI.
		/// </summary>
		protected Launchpoint baseLaunchpoint = null;
		
		/// <summary>
		/// The type of the current launchpoint object.
		/// </summary>
		protected LaunchpointType currentType = LaunchpointType.Invalid;
		
		public String name = null;
		public LaunchpointType type = LaunchpointType.Invalid;
		
		#endregion
		public Boolean changedType = false;
	
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointBaseGUI"/> class.
		/// </summary>
		/// <param name="baseLp">Base lp</param>
		public LaunchpointBaseGUI( Launchpoint baseLp )
		{
			baseLaunchpoint = baseLp;
			
			name = baseLp.Name;
			type = baseLp.Type;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public virtual void OnGUI()
		{
			if( baseLaunchpoint == null )
			{
				// log.
				return;
			}
			
			//baseLaunchpoint.Name = EditorGUILayout.TextField( "Name", baseLaunchpoint.Name );
			
			//baseLaunchpoint.Type = (LaunchpointType)EditorGUILayout.EnumPopup( "Type", baseLaunchpoint.Type );
			
			if( baseLaunchpoint.Type != currentType )
			{
				currentType = baseLaunchpoint.Type;
				changedType = true;
			}
		}
	}
}
