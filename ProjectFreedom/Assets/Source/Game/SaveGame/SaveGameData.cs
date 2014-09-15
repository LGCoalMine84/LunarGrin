using Logging;
using System;

namespace SaveGame
{
	/// <summary>
	/// This is a data centric class that stores the save game data.
	/// </summary>
	public class SaveGameData
	{
		#if LOGGING
		private ILogger Log = LogFactory.CreateLogger( typeof( SaveGameData ) );
		#endif

		public static class Properties
		{
			public static readonly String Sound = "Sound";
		}

		private Boolean isActive;

		private Sound sound;
		
		public SaveGameData()
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin MySaveGameData()" );
			Log.Trace( "End MySaveGameData()" );
			#endif
		}

		public Sound Sound
		{
			get
			{
				return sound;
			}
			
			set
			{
				sound = value;
			}
		}
	}
}