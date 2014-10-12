#region File Header

// File Name:           LaunchpointEditor.cs
// Author:              Andy Sanchez
// Creation Date:       9/13/2014   6:42 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

#endregion

namespace LunarGrin.Core.Tools
{
	/// <summary>
	/// Launchpoint editor.
	/// </summary>
	public sealed class LaunchpointEditor : EditorWindow
	{
		#region Private Fields
		
		#region Window Handle
		
		/// <summary>
		/// The instance to the <see cref="LunarGrin.Core.Tools.LaunchpointEditor"/> window.
		/// </summary>
		private static LaunchpointEditor windowHandle = null;
		
		#endregion
		
		private LaunchpointGUI activeGUI = null;
		
		private GameObject selectedObject = null;
		private Boolean selectionDirty = false;
		
		//Dictionary<Int32, LaunchpointComponent> launchpoints = null;
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.Tools.LaunchpointEditor"/> class.
		/// </summary>
		public LaunchpointEditor()
		{
			//launchpoints = new Dictionary<Int32, LaunchpointComponent>();
		}
		
		#endregion
		
		#region Public Methods
		
		
		
		#endregion
		
		#region Private Fields
		
		#region GUI
		
		private void OnGUI()
		{
			EditorGUILayout.BeginHorizontal();
			
			if( GUILayout.Button( "Add Launchpoint" ) )
			{
				AddSelectedLaunchpoints();
			}
			
			if( GUILayout.Button( "Remove Launchpoint" ) )
			{
				RemoveSelectedLaunchpoints();
      		}
      		
			if( GUILayout.Button( "Apply Changes" ) )
			{
				ApplyChanges();
			}
      		
      		EditorGUILayout.EndHorizontal();
			
			if( Selection.activeGameObject != selectedObject )
			{
				selectionDirty = true;
				SelectedLaunchpointInfo();
			}
			
			if( activeGUI != null )
			{	
				if( activeGUI.isTypeChanged )
				{
					ApplyChanges();
					
					ChangeGUI();
				}
				
				activeGUI.OnGUI();
			}
		}
		
		#endregion		
		
		#region Launchpoint Add and Remove
		
		/// <summary>
		/// Tags the selected game objects in the level as launchpoints.
		/// </summary>
		private void AddSelectedLaunchpoints()
		{
			if( Selection.transforms.Length > 0 )
			{
				for( Int32 i = 0; i < Selection.transforms.Length; ++i )
				{
					if( Selection.transforms[i].gameObject != null )
					{
						Selection.transforms[i].gameObject.AddComponent<LaunchpointComponent>();
					}
				}
			}
			else
			{
				// Log that there are no selected game objects to add a launchpoint tag to.
			}
		}
		
		/// <summary>
		/// Removes the launchpoint tag from the selected game objects in the level.
		/// </summary>
		private void RemoveSelectedLaunchpoints()
		{
			if( Selection.transforms.Length > 0 )
			{
				LaunchpointComponent tempComp = null;
				
				for( Int32 i = 0; i < Selection.transforms.Length; ++i )
				{
					if( Selection.transforms[i].gameObject != null )
					{
						tempComp = Selection.transforms[i].gameObject.GetComponent<LaunchpointComponent>();
						if( tempComp != null )
						{
							GameObject.DestroyImmediate( tempComp );
						}
					}
				}
			}
			else
			{
				// Log that there are no selected game objects to remove the launchpoint tag from.
			}
		}
		
		#endregion
		
		#region Launchpoint Information
		
		private void SelectedLaunchpointInfo()
		{
			if( selectionDirty )
			{
				// Can only select one launchpoint game object at a time.
				if( Selection.objects.Length > 1 )
				{
					return;
				}
				
				if( Selection.activeGameObject != null )
				{
					// Check the selected game object for launchpoint information.
					LaunchpointComponent lpTag = Selection.activeGameObject.GetComponent<LaunchpointComponent>();
					if( lpTag != null )
					{
						selectedObject = Selection.activeGameObject;
						
						activeGUI = LaunchpointGUIFactory.CreateLaunchpointGUI( lpTag.LaunchpointObj );
					}
				}
				else
				{
					selectedObject = null;
					activeGUI = null;
				}
				
				selectionDirty = false;
			}
		}
		
		
		private void ChangeGUI()
		{
			LaunchpointComponent lpTag = Selection.activeGameObject.GetComponent<LaunchpointComponent>();
			
			if( activeGUI.CurrentType == LaunchpointType.AIBrain )
			{
				lpTag.UpdateLaunchpoint( new LaunchpointAIBrain( lpTag.LaunchpointObj, null ) );
				
				activeGUI = null;
				activeGUI = new LaunchpointAIBrainGUI( lpTag.LaunchpointObj );
			}
			else
	    	{
	    		// No good Jim!
	    	}
    	}
    	
    	private void ApplyChanges()
    	{
			LaunchpointComponent lpComp = Selection.activeGameObject.GetComponent<LaunchpointComponent>();
			if( lpComp != null )
			{
				//lpComp.UpdateLaunchpoint( activeGUI.LaunchpointData );
			}
    	}
    	
    	#endregion
    	
		#region Exporter
		
		private void ExportLaunchpoints()
		{
			
		}
		
		#endregion
    
		#region Show Window
		
		/// <summary>
		/// Creates and displays the launchpoint editor window.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to open the launchpoint editor tool because the handle to the window is invalid.</exception>
		[MenuItem( "LunarGrin/Lauchpoint Editor" )]
		private static void ShowWindow()
		{
			if( windowHandle != null )
			{
				windowHandle.Close();
				windowHandle = null;
			}
		
			windowHandle = EditorWindow.GetWindow<LaunchpointEditor>();
			
			if( windowHandle == null )
			{
				throw new InvalidOperationException( "Unable to open the Launchpoint Editor tool because the handle to the window is invalid." );
			}
			
			windowHandle.Show();
    	}
		
		#endregion
		
		#endregion
	}
}
