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
	#region UI Game Objects
	public GameObject goSaveButton = null;
	
	public GameObject goCancelButton = null;
	#endregion
	
	#region UI Components
	public AdvancedSliderController effectsController = null;
	
	public AdvancedSliderController musicController = null;
	
	public AdvancedSliderController speechController = null;
	
	private Button cSaveButton = null;
	
	private Button cCancelButton = null;
	#endregion
	
	#region Unity Functions
	
	void Start()
	{
		if ( goSaveButton != null )
		{
			cSaveButton = goSaveButton.GetComponent<Button>();
		}
		if ( goCancelButton != null )
		{
			cCancelButton = goCancelButton.GetComponent<Button>();
		}
	}
	
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