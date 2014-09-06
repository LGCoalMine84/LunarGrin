#region File Header
// File Name:		MainMenuController.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System.Collections;
using LunarGrin.Core;
#endregion

namespace LunarGrin.UI
{
	/// <summary>
	/// Main menu controller handles the navigation events on the main menu.
	/// </summary>
	public class MainMenuController : MonoBehaviour
	{
	    #region User Interaction
	    
	    /// <summary>
	    /// Handles start click by pushing the start game state onto the game state manager.
	    /// </summary>
	    public void OnStartClick()
	    {
	        Debug.Log( "MainMenuController.OnStartClick" );
	    }
	    
	    /// <summary>
	    /// Handles options click by pushing the options state onto the game state manager.
	    /// </summary>
	    public void OnOptionsClick()
	    {
	        OptionsMenuState optionsMenuState = new OptionsMenuState( "OptionsMenu" );
	        
	        GameServices.StateManager.PushState( optionsMenuState );
	    }
	    
	    /// <summary>
	    ///	Handles credits click by pushing the credits state onto the game state manager.
	    /// </summary>
	    public void OnCreditsClick()
	    {
	        Debug.Log( "MainMenuController.OnCreditsClick" );
	    }
	    
	    /// <summary>
	    /// Handles the quit click by exiting the application.
	    /// </summary>
	    public void OnQuitClick()
	    {
	        Debug.Log( "MainMenuController.OnQuitClick" );
	        
	        Application.Quit();
	        
	        //  TODO:   Wrap this in an editor-only macro
	        UnityEditor.EditorApplication.isPlaying = false;
	    }
	    
	    #endregion
	}
}