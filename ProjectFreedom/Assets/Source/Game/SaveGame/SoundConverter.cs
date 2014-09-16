using Logging;

using Pathfinding.Serialization.JsonFx;

using System;
using System.Collections.Generic;
using System.IO;

namespace SaveGame
{
	public class SoundConverter : JsonConverter
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( SoundConverter ) );
		#endif

		public static SoundSettings DictoinaryToSound( Dictionary<string, object> propertyNameToValueMap )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin DictoinaryToSound( Dictionary<string, object> propertyNameToValueMap )" );
			#endif

			SoundSettings soundSaveGameData = new SoundSettings();

			String type = propertyNameToValueMap [SoundSettings.Properties.EffectVolume].GetType ().ToString();

			if( propertyNameToValueMap[SoundSettings.Properties.EffectVolume] is Double )
			{
				soundSaveGameData.EffectVolume = Convert.ToSingle( propertyNameToValueMap[SoundSettings.Properties.EffectVolume] );
			}
			else
			{
				throw new InvalidOperationException( "Expected a Double for field " + typeof( SoundSettings ).ToString() + 
				                                    "." + SoundSettings.Properties.EffectVolume );
			}
			
			if( propertyNameToValueMap[SoundSettings.Properties.MusicVolume] is Double )
			{
				soundSaveGameData.MusicVolume = Convert.ToSingle( propertyNameToValueMap[SoundSettings.Properties.MusicVolume] );
			}
			else
			{
				throw new InvalidOperationException( "Expected a Double for field " + typeof( SoundSettings ).ToString() + 
				                                    "." + SoundSettings.Properties.MusicVolume );
			}
			
			if( propertyNameToValueMap[SoundSettings.Properties.SpeechVolume] is Double )
			{
				soundSaveGameData.SpeechVolume = Convert.ToSingle( propertyNameToValueMap[SoundSettings.Properties.SpeechVolume] );
			}
			else
			{
				throw new InvalidOperationException( "Expected a Double for field " + typeof( SoundSettings ).ToString() + 
				                                    "." + SoundSettings.Properties.SpeechVolume );
			}

			#if LOGGING_TRACE
			Log.Trace( "End DictoinaryToSound( Dictionary<string, object> propertyNameToValueMap )" );
			#endif

			return soundSaveGameData;
		}

		public static Dictionary<string, object> SoundToDictionary( SoundSettings sound )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin SoundToDictionary( Sound sound )" );
			#endif

			Dictionary<string, object> propertyNameToValueMap = new Dictionary<string, object>();
			
			if( sound == null )
			{
				return propertyNameToValueMap;
			}
			
			propertyNameToValueMap.Add( SoundSettings.Properties.EffectVolume, sound.EffectVolume );
			propertyNameToValueMap.Add( SoundSettings.Properties.MusicVolume, sound.MusicVolume );
			propertyNameToValueMap.Add( SoundSettings.Properties.SpeechVolume, sound.SpeechVolume );

			#if LOGGING_TRACE
			Log.Trace( "End SoundToDictionary( Sound sound )" );
			#endif

			return propertyNameToValueMap;
		}

		/// <summary>
		/// Writes the sound save game data to the stream.
		/// </summary>
		/// <param name="saveGameData">The save game data.</param>
		/// <param name="stream">The stream to which the save game data will be written.</param>
		public static void SoundToStream( SoundSettings soundSaveGameData, Stream stream )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin SoundToStream( Sound soundSaveGameData, Stream stream )" );
			#endif
			
			if( soundSaveGameData == null )
			{
				throw new ArgumentException( "parameter soundSaveGameData is required" );
			}
			
			if( stream == null )
			{
				throw new ArgumentException( "parameter stream is required" );
			}
			
			BinaryWriter writer = new BinaryWriter( stream );
			
			writer.Write( soundSaveGameData.EffectVolume );
			writer.Write( soundSaveGameData.MusicVolume );
			writer.Write( soundSaveGameData.SpeechVolume );
			
			writer.Close();
			
			#if LOGGING_TRACE
			Log.Trace( "End SoundToStream( Sound soundSaveGameData, Stream stream )" );
			#endif
		}

		/// <summary>
		/// Reads the sound save game data from the stream.
		/// </summary>
		/// <param name="stream">The stream from which the save game data will be read.</param>
		/// <param name="saveGameData">The save game data.</param>
		public static void StreamToSound( Stream stream, SoundSettings soundSaveGameData )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin treamToSound( Stream stream, Sound soundSaveGameData )" );
			#endif
			
			if( stream == null )
			{
				throw new ArgumentException( "parameter stream is required" );
			}
			
			if( soundSaveGameData == null )
			{
				throw new ArgumentException( "parameter soundSaveGameData is required" );
			}
			
			BinaryReader reader = new BinaryReader( stream );
			
			soundSaveGameData.EffectVolume = reader.ReadSingle();
			soundSaveGameData.MusicVolume = reader.ReadSingle();
			soundSaveGameData.SpeechVolume = reader.ReadSingle();
			
			reader.Close();
			
			#if LOGGING_TRACE
			Log.Trace( "End treamToSound( Stream stream, Sound soundSaveGameData )" );
			#endif
		}

		/// <summary>
		/// Determines whether this instance can convert the specified type.
		/// </summary>
		/// <returns><c>true</c> if this instance can convert the specified type otherwise, <c>false</c>.</returns>
		/// <param name="t">T.</param>
		public override bool CanConvert( Type type )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin bool CanConvert( Type type )" );
			#endif
			
			Boolean result = type == typeof( SoundSettings );
			
			#if LOGGING_TRACE
			Log.Trace( "End bool CanConvert( Type type )" );
			#endif
			
			return result;
		}

		/// <summary>
		/// Converts a Sound instance into a Dictionary so that the
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
				if( !( value is SoundSettings ) )
				{
					Log.Error( "parameter value was expected to be of type " + typeof( SoundSettings ).ToString() );
					return null;
				}
				
				SoundSettings soundSaveGameData = (SoundSettings)value;

				propertyNameToValueMap = SoundToDictionary( soundSaveGameData );
			}
			catch( Exception e )
			{
				Log.Error( "Unable to serialize type " + typeof( GameConfig ).ToString() + " to JSON" + " " + e.Message );
			}
			
			#if LOGGING_TRACE
			Log.Trace( "End Dictionary<string,object> WriteJson( Type type, object value )" );
			#endif
			
			return propertyNameToValueMap;
		}

		/// <summary>
		/// Converts a Dictionary from the the JSONFX
		/// library into a Sound instance.
		/// </summary>
		/// <returns>A Sound populated with data that is
		/// cast to the object type as required by the JSONFX library.</returns>
		/// <param name="type">A type parameter passed in from the JSONFX library.</param>
		/// <param name="propertyNameToValueMap">A Dictionary parameter passed in from the JSONFX library
		/// that contains the data to be set on the Sound instance.</param>
		public override object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )" );
			#endif
			
			SoundSettings soundSaveGameData = null;
			
			try
			{
				soundSaveGameData = DictoinaryToSound( propertyNameToValueMap );
			}
			catch( Exception e )
			{
				Log.Error( "Unable to deserialize JSON into type " + typeof( GameConfig ).ToString() + " " + e.Message );
			}
			
			#if LOGGING_TRACE
			Log.Trace( "End object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )" );
			#endif
			
			return soundSaveGameData;
		}
	}
}