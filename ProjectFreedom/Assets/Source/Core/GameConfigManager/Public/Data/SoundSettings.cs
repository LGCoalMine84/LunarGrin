using Logging;
using System;

namespace LunarGrin.Core
{
	public class SoundSettings
	{
		#if LOGGING
		private ILogger Log = LogFactory.CreateLogger( typeof( SoundSettings ) );
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