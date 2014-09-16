using Logging;
using System;

namespace SaveGame
{
	public class Sound
	{
		#if LOGGING
		private ILogger Log = LogFactory.CreateLogger( typeof( Sound ) );
		#endif

		/// <summary>
		/// This is a data centric class that stores the sound save game data.
		/// </summary>
		public static class Properties
		{
			public static readonly String Effects = "Effects";
			public static readonly String Music = "Music";
			public static readonly String Speech = "Speech";
		}

		private Single effects;
		private Single music;
		private Single speech;

		public Sound()
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin Sound()" );
			Log.Trace( "End Sound()" );
			#endif
		}

		public Single Effects
		{
			get
			{
				return effects;
			}
			
			set
			{
				effects = value;
			}
		}

		public Single Music
		{
			get
			{
				return music;
			}
			
			set
			{
				music = value;
			}
		}

		public Single Speech
		{
			get
			{
				return speech;
			}
			
			set
			{
				speech = value;
			}
		}
	}
}