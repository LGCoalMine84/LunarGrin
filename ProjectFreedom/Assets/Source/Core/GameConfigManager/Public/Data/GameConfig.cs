
using Logging;
using System;

namespace LunarGrin.Core
{
	/// <summary>
	/// This is a data centric class that stores the save game data.
	/// </summary>
	public class GameConfig
	{
		#if LOGGING
		private ILogger Log = LogFactory.CreateLogger( typeof( GameConfig ) );
		#endif

		public static class Properties
		{
			public static readonly String Sound = "Sound";
		}

		private SoundSettings soundSettings;
		
		public GameConfig()
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin MySaveGameData()" );
			Log.Trace( "End MySaveGameData()" );
			#endif
		}

		public SoundSettings SoundSettings
		{
			get
			{
				return soundSettings;
			}
			
			set
			{
				soundSettings = value;
			}
		}
	}
}