#region File Header

// File Name:           JsonSerialization.cs
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
using System.IO;
using System.Text;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// This class is the primary API used to deserialize/serialize a data type 
	/// to and from a String of JSON formatted data.
	/// 
	/// In order for a new type to be serialized/deserialized, a converter
	/// must be written for that type and registered with this class.  The
	/// converter must extend the JsonConverter class declared by the JSONFX
	/// 3rd party library.
	/// </summary>
	public class JsonSerialization
	{
		private static ILogger Log = LogFactory.CreateLogger( typeof( JsonSerialization ) );
		
		private JsonReaderSettings jsonReaderSettings;
		private JsonReader jsonReader;
		
		private JsonWriterSettings jsonWriterSettings;
		private JsonWriter jsonWriter;
		private StringBuilder writtenJson;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonSerialization"/> class.
		/// </summary>
		/// <param name="prettyPrint">If set to <c>true</c>, created Json is formatted/indented.</param>
		public JsonSerialization( Boolean prettyPrint = false )
		{
			Log.Trace( "Begin JsonSerialization( Boolean prettyPrint = " + prettyPrint + " )" );
			
			//reader handles Json to object instance conversions
			jsonReaderSettings = new JsonReaderSettings();
			
			jsonWriterSettings = new JsonWriterSettings();
			jsonWriterSettings.PrettyPrint = prettyPrint;
			
			//writer handles instance to Json conversions
			writtenJson = new StringBuilder();
			StringWriter stringWriter = new StringWriter( writtenJson );
			jsonWriter = new JsonWriter( stringWriter, jsonWriterSettings );
			
			Log.Trace( "End JsonSerialization( Boolean prettyPrint = " + prettyPrint + " )" );
		}
		
		/// <summary>
		/// Registers a converter with the JsonSerialization instance.
		/// </summary>
		/// <param name="converter">A converter for a particular type, as required by the JSONFX API.</param>
		public void RegisterConverter( JsonConverter converter )
		{
			Log.Trace( "Begin void RegisterConverter( JsonConverter converter )" );
			
			if( converter == null )
			{
				throw new ArgumentException( "parameter converter is required" );
			}
			
			jsonWriterSettings.AddTypeConverter( converter );
			jsonReaderSettings.AddTypeConverter( converter );
			
			Log.Trace( "End void RegisterConverter( JsonConverter converter )" );
		}
		
		/// <summary>
		/// Converts a instance into a String of Json data.
		/// </summary>
		/// <returns>A String of Json data containing data that was contained in the instance.</returns>
		/// <param name="instance">The object instance to be converted into Json.</param>
		public String ToJson( Object instance )
		{
			Log.Trace( "Begin String ToJson( Object instance )" );
			
			if( instance == null )
			{
				throw new ArgumentException( "parameter instance is required" );
			}
			
			jsonWriter.Write( instance );
			String json = writtenJson.ToString();
			writtenJson.Length = 0;
			
			Log.Trace( "End String ToJson( Object instance )" );
			
			return json;
		}
		
		/// <summary>
		/// Converts Json data into an instance.
		/// </summary>
		/// <returns>The instantiated instance populated with data from the Json String.</returns>
		/// <param name="type">The type of the instance that should be returned.</param>
		/// <param name="json">The Json data that is to be converted into an instance.</param>
		public Object FromJson( Type type, String json )
		{
			Log.Trace( "Begin Object FromJson( Type type, String json )" );
			
			if( type == null )
			{
				throw new ArgumentException( "parameter type is required" );
			}
			
			if( json == null )
			{
				throw new ArgumentException( "parameter json is required" );
			}
			
			JsonReader jsonReader = new JsonReader( json, jsonReaderSettings );
			Object instance = jsonReader.Deserialize( type );
			
			Log.Trace( "End Object FromJson( Type type, String json )" );
			
			return instance;
		}
	}
}