#region File Header
// File Name:		OptionsMenuController.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System;
using UnityEngine.UI;
using LunarGrin.Core;
#endregion

namespace LunarGrin.UI
{
	/// <summary>
	/// Options menu controller handles the navigation events on the options menu.
	/// </summary>
	public class OptionsMenuController : MonoBehaviour
	{
		#region UI Game Objects
		/// <summary>
		/// The sound config UI.
		/// </summary>
		public GameObject goSoundConfig = null;
		
		/// <summary>
		/// The video config UI.
		/// </summary>
		public GameObject goVideoConfig = null;
		#endregion
		
		/// <summary>
		/// Handles the sound click by displaying the sound config panel.
		/// </summary>
	    public void OnSoundClick()
	    {
	        SetVisibility( goVideoConfig, false );
	        
	        ToggleVisibility( goSoundConfig );
	    }
	    
	    /// <summary>
	    ///	Handles the video click by displaying the video config panel.
	    /// </summary>
	    public void OnVideoClick()
	    {
			SetVisibility( goSoundConfig, false );
			
			ToggleVisibility( goVideoConfig );
	    }
	    
	    /// <summary>
	    /// Handles the back click by returning to the main menu game state.
	    /// </summary>
	    public void OnBackClick()
	    {
	        SetVisibility( goSoundConfig, false );
	        
	        SetVisibility( goVideoConfig, false );
	        
	        GameServices.StateManager.PopState();
	    }
	    
	    /// <summary>
	    /// Sets the visibility of the given game object.
	    /// </summary>
	    /// <param name="go">The game object to change visiblity for.</param>
	    /// <param name="isVisible">If set to <c>true</c> is visible.</param>
	    private void SetVisibility( GameObject go, Boolean isVisible )
	    {
	    	if ( go != null && go.activeSelf != isVisible )
	    	{
	    		go.SetActive( isVisible );
	    	}
	    }
	    
	    /// <summary>
	    /// Toggles the visibility of the given game object.
	    /// </summary>
	    /// <param name="go">Go.</param>
	    private void ToggleVisibility( GameObject go )
	    {
	    	if ( go != null )
	    	{
	    		go.SetActive( !go.activeSelf );
	    	}
	    }
	}
}