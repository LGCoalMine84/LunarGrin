#region File Header

// File Name:           LaunchpointComponent.cs
// Author:              Andy Sanchez
// Creation Date:       9/13/2014   10:40 PM
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
	/// Component that is set on a level object to mark it as a launchpoint.
	/// </summary>
	/// <remarks>
	/// This class is tagged with the <see cref="UnityEngine.AddComponentMenu"/> attribute with an empty string to hide it from
	/// adding it as component through the Unity editor.
	/// </remarks>
	[AddComponentMenu( "" )]
	[ExecuteInEditMode]
	public sealed class LaunchpointComponent : MonoBehaviour
	{
		#region Private Fields
		
		/// <summary>
		/// The launchpoint data object corresponding to this component.
		/// </summary>
		[HideInInspector]
		[SerializeField]
		private Launchpoint launchpointObj = null;
		
		/// <summary>
		/// The current launchpoint type corresponding to this component.
		/// </summary>
		[HideInInspector]
		[SerializeField]
		private LaunchpointType currentType = LaunchpointType.Invalid;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the launchpoint data object.
		/// </summary>
		/// <value>The launchpoint data object.</value>
		public Launchpoint LaunchpointObj
		{
			get
			{
				return launchpointObj;
			}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.LaunchpointComponent"/> class.
		/// </summary>
		public LaunchpointComponent()
		{
			launchpointObj = new Launchpoint();
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Updates the launchpoint component.
		/// </summary>
		/// <exception cref="NullReferenceException">Unable to update the launchpoint data object because the internal launchpoint object is invalid.</exception>
		/// <exception cref="NullReferenceException">Unable to update the launchpoint data object because</exception>
		/// <remarks>
		/// This method updated the internal launchpoint object reference only if it has been changed
		/// by the launchpoint editor tool.
		/// </remarks>
		public void UpdateLaunchpoint()
		{
			if( launchpointObj == null )
			{
				throw new NullReferenceException( "Unable to update the launchpoint data object because the internal launchpoint object is invalid." );
			}
		
			if( currentType != launchpointObj.Type )
			{
				launchpointObj = LaunchpointFactory.CreateLaunchpoint( launchpointObj.Type, launchpointObj );
				
				if( launchpointObj == null || launchpointObj.Type == LaunchpointType.Invalid )
				{
					throw new NullReferenceException( "Unable to update the launchpoint data object because......" );
				}
				
				currentType = launchpointObj.Type;
			}
		}
		
		#endregion
		
		#region Private Methods
		
		#region Unity Components
		
		/// <summary>
		/// This method is called by Unity after the <see cref="LunarGrin.Core.LaunchpointComponent"/> object has been constructed and initialized.
		/// </summary>
		private void Start()
		{
			// There can only be one launchpoint component in any given game object.
			LaunchpointComponent[] components = gameObject.GetComponents<LaunchpointComponent>();
			if( components != null && components.Length > 1 )
			{
				GameObject.DestroyImmediate( this );
				
				return;
			}
		}
		
		/// <summary>
		/// This method is called by Unity when the <see cref="LunarGrin.Core.LaunchpointComponent"/> object is being destroyed.
		/// </summary>
		private void OnDestroy()
		{
			launchpointObj = null;
			currentType = LaunchpointType.Invalid;
		}
		
		#endregion
		
		#endregion
	}
}
