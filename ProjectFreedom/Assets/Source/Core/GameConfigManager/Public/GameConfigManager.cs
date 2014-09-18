#region File Header

// File Name:		GameConfigManager.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using Logging;

using System;
using System.IO;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// The Game config manager is the central access point for the game's core configuration.
	/// </summary>
	public class GameConfigManager : IGameConfigManager, IGameService
	{
		#region Constants
		
		/// <summary>
		/// The type of game service.
		/// </summary>
		private const ServiceType TypeOfGameService = ServiceType.GameConfigManager;
		
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( GameConfigManager ) );
		#endif
		
		#endregion
		
		/// <summary>
		/// The game's sound configuration.
		/// </summary>
		private GameSoundConfig sound = new GameSoundConfig();
		
		/// <summary>
		/// The game's video configuration.
		/// </summary>
		private GameVideoConfig video = new GameVideoConfig();
		
		private GameConfig gameConfig = null;
		
		#region Mocking Load Data
		public GameConfigManager()
		{
			#if LOGGING
			Log.Trace( "Begin GameConfigManager()" );
			#endif

			Load( "This is a test" );

			#if LOGGING
			Log.Trace( "End GameConfigManager()" );
			#endif
		}

		/// <summary>
		/// Load the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		public void Load( String path )
		{
			#if LOGGING
			Log.Trace( "Begin void Load( String path )" );
			#endif

			#if PARAM_CHECKING
			if( path == null || String.Empty.Equals( path ) )
			{
				throw new ArgumentException( "parameter path is required" );
			}
			#endif

			//	TODO:	Load GameConfig here
			
			gameConfig = new GameConfig();
			gameConfig.SoundSettings = new SoundSettings();
			
			sound.Load( gameConfig.SoundSettings );
			
			sound.OnSoundSettingsSave += OnGameConfigSave;

			#if LOGGING
			Log.Trace( "End void Load( String path )" );
			#endif
		}
		#endregion
		
		/// <summary>
		/// Gets the game's sound configuration.
		/// </summary>
		/// <value>The sound configuration.</value>
		public GameSoundConfig Sound
		{
			get
			{
				return sound;
			}
		}
		
		/// <summary>
		/// Gets the game's video configuration.
		/// </summary>
		/// <value>The video configuration.</value>
		public GameVideoConfig Video
		{
			get
			{
				return video;
			}
		}
		
		/// <summary>
		/// Gets the type of the game service.
		/// </summary>
		/// <value>The type of the game service.</value>
		public ServiceType GameServiceType
		{
			get
			{
				return TypeOfGameService;
			}
		}
		
		private void OnGameConfigSave()
		{
			#if LOGGING
			Log.Trace( "Begin void OnGameConfigSave()" );
			#endif

			UnityEngine.Debug.Log( "GameConfigManager.OnGameConfigSave Sound=" + Sound.EffectVolume + " | " + Sound.MusicVolume + " | " + Sound.SpeechVolume );
			
			SaveBinary();

			#if LOGGING
			Log.Trace( "End void OnGameConfigSave()" );
			#endif
		}
		
		private void SaveBinary()
		{
			#if LOGGING
			Log.Trace( "Begin void SaveBinary()" );
			#endif
			
			Stream stream = File.Open( "C:\\Users\\John\\Desktop\\Test\\ProjectFreedom.bin", FileMode.Create );
			GameConfigConverter.MySaveGameDataToStream( gameConfig, stream );
			stream.Close();
			
			#if LOGGING
			Log.Trace( "Begin void SaveBinary()" );
			#endif
		}
		
		private void SaveJson()
		{
			#if LOGGING
			Log.Trace( "Begin void SaveJson()" );
			#endif
			
			JsonSerialization serializer = createSerializer();
			String json = serializer.ToJson( gameConfig );
			
			FileUtils.WriteStringToFile( "C:\\Users\\John\\Desktop\\Test\\ProjectFreedom.json", json );
			
			#if LOGGING
			Log.Trace( "End void SaveJson()" );
			#endif
		}
		
		//	TODO:	This should probably be located in the OptionsMenuState
		private JsonSerialization createSerializer()
		{
			#if LOGGING
			Log.Trace( "Begin JsonSerialization createSerializer()" );
			#endif

			//by default, a serializer formats json compact, pass in true to make it pretty
			JsonSerialization serializer = new JsonSerialization( true );
			
			serializer.RegisterConverter( new GameConfigConverter() );
			serializer.RegisterConverter( new SoundSettingsConverter() );

			#if LOGGING
			Log.Trace( "End JsonSerialization createSerializer()" );
			#endif

			return serializer;
		}
	}
}