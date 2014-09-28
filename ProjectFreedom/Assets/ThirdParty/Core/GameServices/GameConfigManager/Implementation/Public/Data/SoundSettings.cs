#region File Header

// File Name:           SoundSettings.cs
// Author:              Chris Mraovich
// Creation Date:       8/26/2014   9:54 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using  LunarGrin.Utilities;

using System;

#endregion

namespace LunarGrin.Core
{
	public class SoundSettings
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( SoundSettings ) );
		#endif

		/// <summary>
		/// This is a data centric class that stores the sound save game data.
		/// </summary>
		public static class Properties
		{
			public static readonly String EffectVolume = "EffectVolume";
			public static readonly String MusicVolume = "MusicVolume";
			public static readonly String SpeechVolume = "SpeechVolume";
		}

		private Single effectVolume = 1f;
		private Single musicVolume = 1f;
		private Single speechVolume = 1f;

		public SoundSettings()
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin SoundSettings()" );
			Log.Trace( "End SoundSettings()" );
			#endif
		}

		/// <summary>
		/// Gets or sets the effect volume.
		/// </summary>
		/// <value>The effect volume.</value>
		public Single EffectVolume
		{
			get
			{
				return effectVolume;
			}
			
			set
			{
				effectVolume = value;
			}
		}

		/// <summary>
		/// Gets or sets the music volume.
		/// </summary>
		/// <value>The music volume.</value>
		public Single MusicVolume
		{
			get
			{
				return musicVolume;
			}
			
			set
			{
				musicVolume = value;
			}
		}

		/// <summary>
		/// Gets or sets the speech volume.
		/// </summary>
		/// <value>The speech volume.</value>
		public Single SpeechVolume
		{
			get
			{
				return speechVolume;
			}
			
			set
			{
				speechVolume = value;
			}
		}
	}
}