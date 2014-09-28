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
		/// The type of the current launchpoint object.
		/// </summary>
		protected LaunchpointType currentType = LaunchpointType.Base;
		
		/// <summary>
		/// The name of the current.
		/// </summary>
		protected String currentName = null;
		
		/// <summary>
		/// The type of the changed.
		/// </summary>
		protected Boolean changedType = false;
		
		#endregion
		
		#region Properties
		
		public String CurrentName
		{
			get
			{
				return currentName;
			}
		}
		
		public LaunchpointType CurrentType
		{
			get
			{
				return currentType;
			}
		}
		
		public Boolean isTypeChange
		{
			get
			{
				return changedType;
			}
		}
		
		#endregion
		
		#region Constructors
	
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointBaseGUI"/> class.
		/// </summary>
		/// <param name="baseLp">Base lp</param>
		public LaunchpointBaseGUI( ILaunchpoint baseLp )
		{
			currentName = baseLp.Name;
			currentType = baseLp.Type;
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// 
		/// </summary>
		public virtual void OnGUI()
		{
			currentName = EditorGUILayout.TextField( "Name", currentName );
			
			LaunchpointType newType = (LaunchpointType)EditorGUILayout.EnumPopup( "Type", currentType );
			
			if( newType != currentType )
			{
				currentType = newType;
				changedType = true;
			}
		}
		
		#endregion
	}
}
