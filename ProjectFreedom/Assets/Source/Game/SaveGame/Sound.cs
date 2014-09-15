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

		private Byte effects;
		private Byte music;
		private Byte speech;

		public Sound()
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin Sound()" );
			Log.Trace( "End Sound()" );
			#endif
		}

		public Byte Effects
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

		public Byte Music
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

		public Byte Speech
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