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

using  LunarGrin.Utilities;

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
		
		private static ILogger Log = LogFactory.CreateLogger( typeof( GameConfigManager ) );
		
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
			Log.Trace( "Begin GameConfigManager()" );

			Load( "This is a test" );

			Log.Trace( "End GameConfigManager()" );
		}

		/// <summary>
		/// Load the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		public void Load( String path )
		{
			Log.Trace( "Begin void Load( String path )" );

			if( path == null || String.Empty.Equals( path ) )
			{
				throw new ArgumentException( "parameter path is required" );
			}

			//	TODO:	Load GameConfig here
			
			gameConfig = new GameConfig();
			gameConfig.SoundSettings = new SoundSettings();
			
			sound.Load( gameConfig.SoundSettings );
			
			sound.OnSoundSettingsSave += OnGameConfigSave;

			Log.Trace( "End void Load( String path )" );
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
			Log.Trace( "Begin void OnGameConfigSave()" );

			UnityEngine.Debug.Log( "GameConfigManager.OnGameConfigSave Sound=" + Sound.EffectVolume + " | " + Sound.MusicVolume + " | " + Sound.SpeechVolume );
			
			SaveBinary();

			Log.Trace( "End void OnGameConfigSave()" );
		}
		
		private void SaveBinary()
		{
			Log.Trace( "Begin void SaveBinary()" );
			
			Stream stream = File.Open( "C:\\Users\\John\\Desktop\\Test\\ProjectFreedom.bin", FileMode.Create );
			GameConfigConverter.MySaveGameDataToStream( gameConfig, stream );
			stream.Close();
			
			Log.Trace( "Begin void SaveBinary()" );
		}
		
		private void SaveJson()
		{
			Log.Trace( "Begin void SaveJson()" );
			
			JsonSerialization serializer = createSerializer();
			String json = serializer.ToJson( gameConfig );
			
			FileUtils.WriteStringToFile( "C:\\Users\\John\\Desktop\\Test\\ProjectFreedom.json", json );
			
			Log.Trace( "End void SaveJson()" );
		}
		
		//	TODO:	This should probably be located in the OptionsMenuState
		private JsonSerialization createSerializer()
		{
			Log.Trace( "Begin JsonSerialization createSerializer()" );

			//by default, a serializer formats json compact, pass in true to make it pretty
			JsonSerialization serializer = new JsonSerialization( true );
			
			serializer.RegisterConverter( new GameConfigConverter() );
			serializer.RegisterConverter( new SoundSettingsConverter() );

			Log.Trace( "End JsonSerialization createSerializer()" );

			return serializer;
		}
	}
}