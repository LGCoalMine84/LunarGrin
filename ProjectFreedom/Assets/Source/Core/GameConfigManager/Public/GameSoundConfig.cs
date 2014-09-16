#region File Header
// File Name:		GameSoundConfig.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using System;
#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// The GameSoundConfig manages the currently used sound settings as well as the previously saved sound settings.  This allows the user to change various sound settings and still revert back to a previous setting at a later time.
	/// </summary>
	public class GameSoundConfig
	{
		public Action OnSoundSettingsSave;
	
		/// <summary>
		/// The active sound settings.
		/// </summary>
		private SoundSettings activeSettings = new SoundSettings();
		
		/// <summary>
		/// The last saved sound settings.
		/// </summary>
		private SoundSettings savedSettings = new SoundSettings();
		
		/// <summary>
		/// Gets the effect volume.
		/// </summary>
		/// <value>The effect volume.</value>
		public Single EffectVolume
		{
			get
			{
				return activeSettings.effectVolume;
			}
		}
		
		/// <summary>
		/// Gets the music volume.
		/// </summary>
		/// <value>The music volume.</value>
		public Single MusicVolume
		{
			get
			{
				return activeSettings.musicVolume;
			}
		}
		
		/// <summary>
		/// Gets the speech volume.
		/// </summary>
		/// <value>The speech volume.</value>
		public Single SpeechVolume
		{
			get
			{
				return activeSettings.speechVolume;
			}
		}
		
		/// <summary>
		/// Sets the effect volume.
		/// </summary>
		/// <param name="value">The value to set the effect volume to.</param>
		public void SetEffectVolume( Single value )
		{
			if ( activeSettings.effectVolume != value )
			{
				activeSettings.effectVolume = value;
				
				//	TODO:	Set the effect channel to the new value.
			}
		}
		
		/// <summary>
		/// Sets the music volume.
		/// </summary>
		/// <param name="value">The value to set the music volume to.</param>
		public void SetMusicVolume( Single value )
		{
			if ( activeSettings.musicVolume != value )
			{
				activeSettings.musicVolume = value;
				
				//	TODO:	Set the music channel to the new value.
			}
		}
		
		/// <summary>
		/// Sets the speech volume.
		/// </summary>
		/// <param name="value">The value to set the speech volume to.</param>
		public void SetSpeechVolume( Single value )
		{
			if ( activeSettings.speechVolume != value )
			{
				activeSettings.speechVolume = value;
				
				//	TODO:	Set the speech channel to the new value.
			}
		}
		
		/// <summary>
		/// Load the specified soundSettings.  This will also apply the sound settings.
		/// </summary>
		/// <param name="soundSettings">Sound settings.</param>
		public void Load( ref SoundSettings soundSettings )
		{
			savedSettings = soundSettings;
			
			Revert();
		}
		
		/// <summary>
		/// Revert the active sound settings to the last saved sound settings.
		/// </summary>
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
		
		/// <summary>
		/// Save the active sound settings.
		/// </summary>
		public void Save()
		{
			savedSettings.effectVolume = activeSettings.effectVolume;
			savedSettings.musicVolume = activeSettings.musicVolume;
			savedSettings.speechVolume = activeSettings.speechVolume;
			
			if ( OnSoundSettingsSave != null )
			{
				OnSoundSettingsSave();
			}
		}
	}
}