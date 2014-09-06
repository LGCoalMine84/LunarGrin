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
using LunarGrin.Core;
#endregion

public class SoundOptionsController : MonoBehaviour
{
	#region UI Components
	public AdvancedSliderController effectsController = null;
	
	public AdvancedSliderController musicController = null;
	
	public AdvancedSliderController speechController = null;
	#endregion
	
	#region Unity Functions

	void OnDisable()
	{
		RemoveListeners();
	}
	
	void OnEnable()
	{
		InitializeUI();
	}
	
	#endregion
	
	#region Event Handlers
	
	private void OnEffectVolumeChange( Single value )
	{
		GameServices.ConfigManager.Sound.SetEffectVolume( value );
	}
	
	private void OnMusicVolumeChange( Single value )
	{
		GameServices.ConfigManager.Sound.SetMusicVolume( value );
	}
	
	private void OnSpeechVolumeChange( Single value )
	{
		GameServices.ConfigManager.Sound.SetSpeechVolume( value );
	}
	
	#endregion
	
	public void OnSaveClick()
	{
		GameServices.ConfigManager.Sound.Save();
		
		gameObject.SetActive( false );
	}
	
	public void OnCancelClick()
	{
		GameServices.ConfigManager.Sound.Revert();
		
		gameObject.SetActive( false );
	}
	
	private void InitializeUI()
	{
		if ( effectsController != null )
		{
			effectsController.Value = GameServices.ConfigManager.Sound.EffectVolume;
			effectsController.OnValueChange += OnEffectVolumeChange;
		}
		
		if ( musicController != null )
		{
			musicController.Value = GameServices.ConfigManager.Sound.MusicVolume;
			musicController.OnValueChange += OnMusicVolumeChange;
		}
		
		if ( speechController != null )
		{
			speechController.Value = GameServices.ConfigManager.Sound.SpeechVolume;
			musicController.OnValueChange += OnSpeechVolumeChange;
		}
	}
	
	private void RemoveListeners()
	{
		if ( effectsController != null )
		{
			effectsController.OnValueChange -= OnEffectVolumeChange;
		}
		
		if ( musicController != null )
		{
			musicController.OnValueChange -= OnMusicVolumeChange;
		}
		
		if ( speechController != null )
		{
			speechController.OnValueChange -= OnSpeechVolumeChange;
		}
	}
}