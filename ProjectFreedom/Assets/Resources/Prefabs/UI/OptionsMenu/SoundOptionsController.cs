#region File Header
// File Name:		SoundOptions.cs
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

public class SoundOptionsController : MonoBehaviour
{
	#region UI Components
	public AdvancedSliderController effectsController = null;
	
	public AdvancedSliderController musicController = null;
	
	public AdvancedSliderController speechController = null;
	#endregion
	
	public void OnSaveClick()
	{
		//	TODO:	Commit data to the GameConfig
		gameObject.SetActive( false );
	}
	
	public void OnCancelClick()
	{
		//	TODO:	Revert game settings back to GameConfig
		gameObject.SetActive( false );
	}
}