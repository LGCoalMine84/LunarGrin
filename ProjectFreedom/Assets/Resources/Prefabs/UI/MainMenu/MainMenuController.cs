#region File Header
// File Name:		MainMenuController.cs
// Author:			John Whitsell
// Creation Date:	
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

public class MainMenuController : MonoBehaviour
{
    #region User Interaction
    
    public void OnStartClick()
    {
        Debug.Log( "MainMenuController.OnStartClick" );
    }
    
    public void OnOptionsClick()
    {
        Debug.Log( "MainMenuController.OnOptionsClick" );
        
        OptionsMenuState optionsMenuState = new OptionsMenuState( "OptionsMenu" );
        
        GameServices.StateManager.PushState( optionsMenuState );
    }
    
    public void OnCreditsClick()
    {
        Debug.Log( "MainMenuController.OnCreditsClick" );
    }
    
    public void OnQuitClick()
    {
        Debug.Log( "MainMenuController.OnQuitClick" );
        
        Application.Quit();
        
        //  TODO:   Wrap this in an editor-only macro
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
    #endregion
}