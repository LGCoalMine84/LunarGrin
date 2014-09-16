using Pathfinding.Serialization.JsonFx;

using Logging;

using System;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

/// <summary>
/// This class is responsible for defining how the
/// MySaveGameData type is serialized/deserialized 
/// to/from JSON/object forms.
/// </summary>
namespace SaveGame
{
	public class SaveGameDataConverter : JsonConverter
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( SaveGameDataConverter ) );
		#endif
		
		/// <summary>
		/// Writes the save game data to the stream.
		/// </summary>
		/// <param name="saveGameData">The save game data.</param>
		/// <param name="stream">The stream to which the save game data will be written.</param>
		public static void MySaveGameDataToStream( GameConfig saveGameData, Stream stream )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin SaveGameToStream( MySaveGameData saveGameData, Stream stream )" );
			#endif
			
			if( saveGameData == null )
			{
				throw new ArgumentException( "parameter saveGameData is required" );
			}

			if( saveGameData == null )
			{
				throw new ArgumentException( "parameter saveGameData.Sound is required" );
			}

			if( stream == null )
			{
				throw new ArgumentException( "parameter stream is required" );
			}
			
			BinaryWriter writer = new BinaryWriter( stream );
			
			//TODO: as we add more save game data fields, they will need to be added here
			writer.Write( saveGameData.Sound.EffectVolume );
			writer.Write( saveGameData.Sound.MusicVolume );
			writer.Write( saveGameData.Sound.SpeechVolume );

			writer.Close();
			
			#if LOGGING_TRACE
			Log.Trace( "End SaveGameToStream( MySaveGameData saveGameData, Stream stream )" );
			#endif
		}
		
		/// <summary>
		/// Reads the save game data from the stream.
		/// </summary>
		/// <param name="stream">The stream from which the save game data will be read.</param>
		/// <param name="saveGameData">The save game data.</param>
		public static void StreamToMySaveGameData( Stream stream, GameConfig saveGameData )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin StreamToSaveGame( Stream stream, MySaveGameData saveGameData )" );
			#endif
			
			if( stream == null )
			{
				throw new ArgumentException( "parameter stream is required" );
			}
			
			if( saveGameData == null )
			{
				throw new ArgumentException( "parameter saveGameData is required" );
			}

			if( saveGameData.Sound == null )
			{
				saveGameData.Sound = new SoundSettings();
			}

			BinaryReader reader = new BinaryReader( stream );
			
			//TODO: as we add more save game data fields, they will need to be added here
			saveGameData.Sound.EffectVolume = reader.ReadSingle();
			saveGameData.Sound.MusicVolume = reader.ReadSingle();
			saveGameData.Sound.SpeechVolume = reader.ReadSingle();

			reader.Close();
			
			#if LOGGING_TRACE
			Log.Trace( "End StreamToSaveGame( Stream stream, MySaveGameData saveGameData )" );
			#endif
		}
		
		/// <summary>
		/// Determines whether this instance can convert the specified t.
		/// </summary>
		/// <returns><c>true</c> if this instance can convert the specified t; otherwise, <c>false</c>.</returns>
		/// <param name="t">T.</param>
		public override bool CanConvert( Type t )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin bool CanConvert( Type t )" );
			#endif
			
			Boolean result = t == typeof( GameConfig );
			
			#if LOGGING_TRACE
			Log.Trace( "End bool CanConvert( Type t )" );
			#endif
			
			return result;
		}
		
		/// <summary>
		/// Converts a MySaveGameData instance into a Dictionary so that the
		/// instance data may be converted into JSON by the JSONFX library.
		/// </summary>
		/// <returns>A Dictionary containing the data from the value parameter.</returns>
		/// <param name="type">A type parameter passed in from the JSONFX library.</param>
		/// <param name="value">A Value parameter passed in from the JSONFX library.</param>
		public override Dictionary<string,object> WriteJson( Type type, object value )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin Dictionary<string,object> WriteJson( Type type, object value )" );
			#endif
			
			Dictionary<string,object> propertyNameToValueMap = null;
			
			try
			{
				if( !( value is GameConfig ) )
				{
					Debug.Log ( "parameter value was expected to be of type " + typeof( GameConfig ).ToString() );
					return null;
				}
				
				GameConfig mySaveGameData = (GameConfig)value;
				propertyNameToValueMap = new Dictionary<string, object>();

				if( mySaveGameData.Sound == null )
				{
					throw new InvalidOperationException( typeof( GameConfig ).ToString() +  "." + 
					                                     GameConfig.Properties.Sound + " is required" );
				}

				Dictionary<string,object> soundPropertyNameToValueMap = SoundConverter.SoundToDictionary( mySaveGameData.Sound );
				propertyNameToValueMap[GameConfig.Properties.Sound] = soundPropertyNameToValueMap;
			}
			catch( Exception e )
			{
				Debug.Log( "Unable to serialize type " + typeof( GameConfig ).ToString() + " to JSON" + " " + e.Message );
			}
			
			#if LOGGING_TRACE
			Log.Trace( "E Dictionary<string,object> WriteJson( Type type, object value )" );
			#endif
			
			return propertyNameToValueMap;
		}
		
		/// <summary>
		/// Converts a Dictionary from the the JSONFX
		/// library into a MySaveGameData instance.
		/// </summary>
		/// <returns>A MySaveGameData populated with data that is
		/// cast to the object type as required by the JSONFX library.</returns>
		/// <param name="type">A type parameter passed in from the JSONFX library.</param>
		/// <param name="propertyNameToValueMap">A Dictionary parameter passed in from the JSONFX library
		/// that contains the data to be set on the MySaveGameData instance.</param>
		public override object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )" );
			#endif
			
			GameConfig mySaveGameData = null;
			
			try
			{
				mySaveGameData = new GameConfig();

				if( propertyNameToValueMap[GameConfig.Properties.Sound] is Dictionary<string, object> )
				{
					Dictionary<string, object> soundSaveGameDataMap = 
						(Dictionary<string, object>)propertyNameToValueMap[GameConfig.Properties.Sound];

					mySaveGameData.Sound = SoundConverter.DictoinaryToSound( soundSaveGameDataMap );
				}
			}
			catch( Exception e )
			{
				Debug.Log( "Unable to deserialize JSON into type " + typeof( GameConfig ).ToString() + " " + e.Message );
			}
			
			#if LOGGING_TRACE
			Log.Trace( "End object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )" );
			#endif
			
			return mySaveGameData;
		}
	}
}