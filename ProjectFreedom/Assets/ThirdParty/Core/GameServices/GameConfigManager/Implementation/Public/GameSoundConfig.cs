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

using  LunarGrin.Utilities;

using System;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// The GameSoundConfig manages the currently used sound settings as well as the previously saved sound settings.
	/// This allows the user to change various sound settings and still revert back to a previous setting at a later time.
	/// </summary>
	public class GameSoundConfig
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( GameSoundConfig ) );
		#endif

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
				return activeSettings.EffectVolume;
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
				return activeSettings.MusicVolume;
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
				return activeSettings.SpeechVolume;
			}
		}
		
		/// <summary>
		/// Sets the effect volume.
		/// </summary>
		/// <param name="value">The value to set the effect volume to.</param>
		public void SetEffectVolume( Single value )
		{
			#if LOGGING
			Log.Trace( "Begin void SetEffectVolume( Single value )" );
			#endif

			if ( activeSettings.EffectVolume != value )
			{
				activeSettings.EffectVolume = value;
				
				//	TODO:	Set the effect channel to the new value.
			}

			#if LOGGING
			Log.Trace( "End void SetEffectVolume( Single value )" );
			#endif
		}
		
		/// <summary>
		/// Sets the music volume.
		/// </summary>
		/// <param name="value">The value to set the music volume to.</param>
		public void SetMusicVolume( Single value )
		{
			#if LOGGING
			Log.Trace( "Begin void SetMusicVolume( Single value )" );
			#endif

			if ( activeSettings.MusicVolume != value )
			{
				activeSettings.MusicVolume = value;
				
				//	TODO:	Set the music channel to the new value.
			}

			#if LOGGING
			Log.Trace( "End void SetMusicVolume( Single value )" );
			#endif
		}
		
		/// <summary>
		/// Sets the speech volume.
		/// </summary>
		/// <param name="value">The value to set the speech volume to.</param>
		public void SetSpeechVolume( Single value )
		{
			#if LOGGING
			Log.Trace( "Begin void SetSpeechVolume( Single value )" );
			#endif

			if ( activeSettings.SpeechVolume != value )
			{
				activeSettings.SpeechVolume = value;
				
				//	TODO:	Set the speech channel to the new value.
			}

			#if LOGGING
			Log.Trace( "End void SetSpeechVolume( Single value )" );
			#endif
		}
		
		/// <summary>
		/// Load the specified soundSettings.  This will also apply the sound settings.
		/// </summary>
		/// <param name="soundSettings">Sound settings.</param>
		public void Load( SoundSettings soundSettings )
		{
			#if LOGGING
			Log.Trace( "Begin void Load( SoundSettings soundSettings )" );
			#endif

			#if PARAM_CHECKING
			if( soundSettings == null )
			{
				throw new ArgumentException( "parameter soundSettings is required" );
			}
			#endif

			savedSettings = soundSettings;
			
			Revert();

			#if LOGGING
			Log.Trace( "End void Load( SoundSettings soundSettings )" );
			#endif
		}
		
		/// <summary>
		/// Revert the active sound settings to the last saved sound settings.
		/// </summary>
		public void Revert()
		{
			#if LOGGING
			Log.Trace( "Begin void Revert()" );
			#endif

			if ( activeSettings.EffectVolume != savedSettings.EffectVolume )
			{
				SetEffectVolume( savedSettings.EffectVolume );
			}
			
			if ( activeSettings.MusicVolume != savedSettings.EffectVolume )
			{
				SetMusicVolume( savedSettings.MusicVolume );
			}
			
			if ( activeSettings.SpeechVolume != savedSettings.SpeechVolume )
			{
				SetSpeechVolume( savedSettings.SpeechVolume );
			}

			#if LOGGING
			Log.Trace( "End void Revert()" );
			#endif
		}
		
		/// <summary>
		/// Save the active sound settings.
		/// </summary>
		public void Save()
		{
			#if LOGGING
			Log.Trace( "Begin void Save()" );
			#endif

			savedSettings.EffectVolume = activeSettings.EffectVolume;
			savedSettings.MusicVolume = activeSettings.MusicVolume;
			savedSettings.SpeechVolume = activeSettings.SpeechVolume;
			
			if ( OnSoundSettingsSave != null )
			{
				OnSoundSettingsSave();
			}

			#if LOGGING
			Log.Trace( "End void Save()" );
			#endif
		}
	}
}