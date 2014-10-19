using System;
using System.IO;

namespace LunarGrin.Utilities
{
	/// <summary>
	/// File utility class for easing use of 
	/// common file operations.
	/// </summary>
	public static class FileUtils
	{
		private static ILogger Log = LogFactory.CreateLogger( typeof( FileUtils ) );
	
		/// <summary>
		/// Reads data from a file to a string.
		/// </summary>
		/// <returns>The string data read from the file.</returns>
		/// <<param name="filePath">The path of the file to be created.</param>
		public static String ReadFileToString( String filePath )
		{
			Log.Trace( "Begin String ReadFileToString( String filePath )" );
	
			if( filePath == null )
			{
				throw new ArgumentException( "parameter filePath is required" );
			}
			
			if( String.IsNullOrEmpty( filePath ) )
			{
				throw new ArgumentException( "parameter filePath must be non-empty" );
			}
			
			String data = System.IO.File.ReadAllText( filePath );
	
			Log.Trace( "End String ReadFileToString( String filePath )" );
	
			return data;
		}
	
		/// <summary>
		/// Writes string data to a file.
		/// </summary>
		/// <param name="filePath">The path of the file to be created.</param>
		/// <param name="data">The string data to be written to the file.</param>
		public static void WriteStringToFile( String filePath, String data )
		{
			Log.Trace( "Begin void WriteStringToFile( String filePath, String data )" );

			if( filePath == null )
			{
				throw new ArgumentException( "parameter filePath is required" );
			}
	
			if( String.IsNullOrEmpty( filePath ) )
			{
				throw new ArgumentException( "parameter filePath must be non-empty" );
			}
	
			if( data == null )
			{
				throw new ArgumentException( "parameter data is required" );
			}
	
			StreamWriter sw = File.CreateText( filePath );
			sw.Write( data );
			sw.Close();
	
			Log.Trace( "End void WriteStringToFile( String filePath, String data )" );
		}
	}
}
