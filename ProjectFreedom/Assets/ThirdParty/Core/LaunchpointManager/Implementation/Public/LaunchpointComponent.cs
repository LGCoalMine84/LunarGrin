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
using System.Text;

using UnityEngine;
using UnityEditor;

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
		/// <seealso cref="LunarGrin.Core.ILaunchpoint"/>
		[HideInInspector]
		[SerializeField]
		private ILaunchpoint launchpointObj = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the <see cref="LunarGrin.Core.ILaunchpoint"/> data object.
		/// </summary>
		/// <value>The <see cref="LunarGrin.Core.ILaunchpoint"/> data object.</value>
		public ILaunchpoint LaunchpointObj
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
			
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Updates the launchpoint data object within the <see cref="LunarGrin.Core.LaunchpointComponent"/> component.
		/// </summary>
		/// <param name="newLaunchpointObj">The new launchpoint data object.</param>
		/// <exception cref="InvalidOperationException">Updating a launchpoint is not permitted while the editor is in play mode.</exception>
		/// <exception cref="ArgumentNullException">Unable to update the launchpoint data object because the new launchpoint data object is invalid.</exception>
		/// <exception cref="InvalidOperationException">Updating a launchpoint is not permitted during runtime.</exception>
		/// <remarks>
		/// This method can only be called by the editor to update the internal launchpoint data object. If it is called anywhere else, it will throw exceptions.
		/// </remarks>
		public void UpdateLaunchpoint( ILaunchpoint newLaunchpointObj )
		{
			if( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxPlayer )
			{
				if( EditorApplication.isPlaying )
				{
					throw new InvalidOperationException( "Updating a launchpoint is not permitted while the editor is in play mode." );
				}

				if( newLaunchpointObj == null )
				{
					throw new ArgumentNullException( "Unable to update the launchpoint data object because the new launchpoint data object is invalid." );
				}
				
				if( launchpointObj.Type != newLaunchpointObj.Type )
				{
					launchpointObj = null;
					launchpointObj = newLaunchpointObj;
				}
			}
			else
			{
				throw new InvalidOperationException( "Updating a launchpoint is not permitted during runtime." );
			}
		}
		
		#region System.Object
		
		/// <summary>
		/// Gets information about the <see cref="LunarGrin.Core.LaunchpointComponent"/> class.
		/// </summary>
		/// <returns>The information about the launchpoint component class.</returns>
		/// <seealso cref="System.Object"/>
		public override string ToString ()
		{
			StringBuilder strBuilder = new StringBuilder();
			
			strBuilder.AppendLine( "Launchpoint component: " );
			strBuilder.Append( ( launchpointObj != null ) ? launchpointObj.ToString() : String.Empty );
			
			return strBuilder.ToString();
		}
		
		#endregion
		
		#endregion
		
		#region Private Methods
		
		#region Unity Components
		
		/// <summary>
		/// This method is called by Unity when the <see cref="LunarGrin.Core.LaunchpointComponent"/> object has been created.
		/// </summary>
		private void Awake()
		{
			launchpointObj = new LaunchpointBase( name, transform.position, transform.rotation, transform.localScale );
		}
		
		/// <summary>
		/// This method is called by Unity after the <see cref="LunarGrin.Core.LaunchpointComponent"/> object has been constructed and initialized.
		/// </summary>
		/// <remarks>
		/// During editor mode, this method is called when the component has been created and initialized. It checks that no more than one launchpoint
		/// component can be added to the parent game object.
		/// </remarks>
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
		/// This method is called by Unity when the <see cref="LunarGrin.Core.LaunchpointComponent"/> object is being updated every frame.
		/// </summary>
		/// <remarks>
		/// During editor mode, this method is called every frame only when something in the scene has changed.
		/// </remarks>
		private void Update()
		{
			if( launchpointObj != null )
			{
				launchpointObj.Position = transform.position;
				launchpointObj.Rotation = transform.rotation;
				launchpointObj.Scale = transform.localScale;
			}
		}
		
		/// <summary>
		/// This method is called by Unity when the <see cref="LunarGrin.Core.LaunchpointComponent"/> object is being destroyed.
		/// </summary>
		/// <remarks>
		/// During editor mode, this method is called when the launchpoint component has been deleted.
		/// </remarks>
		private void OnDestroy()
		{
			launchpointObj = null;
		}
		
		#endregion
		
		#endregion
	}
}
