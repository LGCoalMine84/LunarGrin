#region File Header
// File Name:		GameSoundConfig.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using System;
#endregion

public class GameSoundConfig
{
	private SoundSettings activeSettings = new SoundSettings();
	
	private SoundSettings savedSettings = new SoundSettings();
	
	public void SetEffectVolume( Single value )
	{
		if ( activeSettings.effectVolume != value )
		{
			activeSettings.effectVolume = value;
			
			//	TODO:	Set the effect channel to the new value.
		}
	}
	
	public void SetMusicVolume( Single value )
	{
		if ( activeSettings.musicVolume != value )
		{
			activeSettings.musicVolume = value;
			
			//	TODO:	Set the music channel to the new value.
		}
	}
	
	public void SetSpeechVolume( Single value )
	{
		if ( activeSettings.speechVolume != value )
		{
			activeSettings.speechVolume = value;
			
			//	TODO:	Set the speech channel to the new value.
		}
	}
	
	public void Load( SoundSettings soundSettings )
	{
		savedSettings = soundSettings;
		
		Revert();
	}
	
	public void Revert()
	{
		if ( activeSettings.effectVolume != savedSettings.effectVolume )
		{
			SetEffectVolume( savedSettings.effectVolume );
		}
		
		if ( activeSettings.musicVolume != savedSettings.effectVolume )
		{
			SetMusicVolume( savedSettings.musicVolume );
		}
		
		if ( activeSettings.speechVolume != savedSettings.speechVolume )
		{
			SetSpeechVolume( savedSettings.speechVolume );
		}
	}
}