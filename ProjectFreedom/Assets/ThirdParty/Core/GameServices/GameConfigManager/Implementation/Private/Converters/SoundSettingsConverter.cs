#region File Header

// File Name:           SoundSettingsConverter.cs
// Author:              Chris Mraovich
// Creation Date:       8/26/2014   9:54 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using  LunarGrin.Utilities;

using Pathfinding.Serialization.JsonFx;

using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// This class is responsible for defining how the
	/// SoundSettings type is serialized/deserialized 
	/// to/from JSON/object forms.
	/// </summary>
	public class SoundSettingsConverter : JsonConverter
	{
		private static ILogger Log = LogFactory.CreateLogger( typeof( SoundSettingsConverter ) );

		public static SoundSettings DictoinaryToSound( Dictionary<string, object> propertyNameToValueMap )
		{
			Log.Trace( "Begin SoundSettings DictoinaryToSound( Dictionary<string, object> propertyNameToValueMap )" );

			SoundSettings soundSaveGameData = new SoundSettings();

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

			Log.Trace( "End SoundSettings DictoinaryToSound( Dictionary<string, object> propertyNameToValueMap )" );

			return soundSaveGameData;
		}

		public static Dictionary<string, object> SoundToDictionary( SoundSettings sound )
		{
			Log.Trace( "Begin Dictionary<string, object> SoundToDictionary( SoundSettings sound )" );

			Dictionary<string, object> propertyNameToValueMap = new Dictionary<string, object>();
			
			if( sound == null )
			{
				return propertyNameToValueMap;
			}
			
			propertyNameToValueMap.Add( SoundSettings.Properties.EffectVolume, sound.EffectVolume );
			propertyNameToValueMap.Add( SoundSettings.Properties.MusicVolume, sound.MusicVolume );
			propertyNameToValueMap.Add( SoundSettings.Properties.SpeechVolume, sound.SpeechVolume );

			Log.Trace( "End Dictionary<string, object> SoundToDictionary( SoundSettings sound )" );

			return propertyNameToValueMap;
		}

		/// <summary>
		/// Writes the sound save game data to the stream.
		/// </summary>
		/// <param name="saveGameData">The save game data.</param>
		/// <param name="stream">The stream to which the save game data will be written.</param>
		public static void SoundToStream( SoundSettings soundSaveGameData, Stream stream )
		{
			Log.Trace( "Begin void SoundToStream( SoundSettings soundSaveGameData, Stream stream )" );
			
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
			
			Log.Trace( "End void SoundToStream( SoundSettings soundSaveGameData, Stream stream )" );
		}

		/// <summary>
		/// Reads the sound save game data from the stream.
		/// </summary>
		/// <param name="stream">The stream from which the save game data will be read.</param>
		/// <param name="saveGameData">The save game data.</param>
		public static void StreamToSound( Stream stream, SoundSettings soundSaveGameData )
		{
			Log.Trace( "Begin void StreamToSound( Stream stream, SoundSettings soundSaveGameData )" );
			
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
			
			Log.Trace( "End void StreamToSound( Stream stream, SoundSettings soundSaveGameData )" );
		}

		/// <summary>
		/// Determines whether this instance can convert the specified type.
		/// </summary>
		/// <returns><c>true</c> if this instance can convert the specified type otherwise, <c>false</c>.</returns>
		/// <param name="t">T.</param>
		public override bool CanConvert( Type type )
		{
			Log.Trace( "Begin bool CanConvert( Type type )" );
			
			Boolean result = type == typeof( SoundSettings );
			
			Log.Trace( "End bool CanConvert( Type type )" );
			
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
			Log.Trace( "Begin Dictionary<string,object> WriteJson( Type type, object value )" );
			
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
			
			Log.Trace( "End Dictionary<string,object> WriteJson( Type type, object value )" );
			
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
			Log.Trace( "Begin object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )" );
			
			SoundSettings soundSaveGameData = null;
			
			try
			{
				soundSaveGameData = DictoinaryToSound( propertyNameToValueMap );
			}
			catch( Exception e )
			{
				Log.Error( "Unable to deserialize JSON into type " + typeof( GameConfig ).ToString() + " " + e.Message );
			}
			
			Log.Trace( "End object ReadJson( Type type, Dictionary<string,object> propertyNameToValueMap )" );
			
			return soundSaveGameData;
		}
	}
}
