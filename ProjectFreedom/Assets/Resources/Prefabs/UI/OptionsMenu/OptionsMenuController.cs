#region File Header
// File Name:		OptionsMenuController.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System;
using UnityEngine.UI;
#endregion

public class OptionsMenuController : MonoBehaviour
{
	#region UI Game Objects
	public GameObject goSoundConfig = null;
	
	public GameObject goVideoConfig = null;
	#endregion

    public void OnSoundClick()
    {
        SetVisibility( goVideoConfig, false );
        
        ToggleVisibility( goSoundConfig );
    }
    
    public void OnVideoClick()
    {
		SetVisibility( goSoundConfig, false );
		
		ToggleVisibility( goVideoConfig );
    }
    
    public void OnBackClick()
    {
        SetVisibility( goSoundConfig, false );
        
        SetVisibility( goVideoConfig, false );
    }
    
    private void SetVisibility( GameObject go, Boolean isVisible )
    {
    	if ( go != null && go.activeSelf != isVisible )
    	{
    		go.SetActive( isVisible );
    	}
    }
    
    private void ToggleVisibility( GameObject go )
    {
    	if ( go != null )
    	{
    		go.SetActive( !go.activeSelf );
    	}
    }
}