#region File Header

// File Name:           LaunchpointGUI.cs
// Author:              Andy Sanchez
// Creation Date:       9/28/2014   4:55 PM
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
	/// Displays default information of a launchpoint.
	/// </summary>
	public abstract class LaunchpointGUI
	{
		#region Protected Fields
		
		/// <summary>
		/// The type of the current launchpoint.
		/// </summary>
		protected LaunchpointType currentType = LaunchpointType.Invalid;
		
		/// <summary>
		/// The name of the current launchpoint.
		/// </summary>
		protected String currentName = null;
		
		/// <summary>
		/// Checks whether the current type has been changed.
		/// </summary>
		protected Boolean changedType = false;
		
		#endregion
	
		#region Properties
		
		/// <summary>
		/// Gets the type of the current launchpoint.
		/// </summary>
		/// <value>The type of the current launchpoint.</value>
		public LaunchpointType CurrentType
		{
			get
			{
				return currentType;
			}
		}
		
		/// <summary>
		/// Gets the name of the current launchpoint.
		/// </summary>
		/// <value>The name of the current launchpoint.</value>
		public String CurrentName
		{
			get
			{
				return currentName;
			}
		}

		/// <summary>
		/// Gets whether the type of the current launchpoint has changed.
		/// </summary>
		/// <value><c>True</c> if is type of the current launchpoint has changed.</value>
		public Boolean isTypeChanged
		{
			get
			{
				return changedType;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointGUI"/> class.
		/// </summary>
		/// <param name="launchpointObj">The launchpoint object to query the data from.</param>
		/// <exception cref="ArgumentNullException">Unable to create a launchpoint GUI because the launchpoint object is invalid.</exception>
		protected LaunchpointGUI( ILaunchpoint launchpointObj )
		{
			if( launchpointObj == null )
			{
				throw new ArgumentNullException( "Unable to create a launchpoint GUI because the launchpoint object is invalid." );
			}
		
			currentName = launchpointObj.Name;
			currentType = launchpointObj.Type;
		}
		
		#endregion
	
		#region Public Methods
	
		/// <summary>
		/// Draws the launchpoint GUI.
		/// </summary>
		/// <remarks>
		/// This method is meant to be called from within the OnGUI method in the <see cref="LunarGrin.Core.Tools.LaunchpointEditor"/> class.
		/// </remarks>
		public virtual void OnGUI()
		{
			changedType = false;
			
			currentName = EditorGUILayout.TextField( "Name", currentName );
			
			LaunchpointType newType = (LaunchpointType)EditorGUILayout.EnumPopup( "Type", currentType );
			
			if( newType != currentType )
			{
				currentType = newType;
				changedType = true;
			}
		}
		
		public abstract ILaunchpoint GetLaunchpoint();
		
		#endregion
	}
}
