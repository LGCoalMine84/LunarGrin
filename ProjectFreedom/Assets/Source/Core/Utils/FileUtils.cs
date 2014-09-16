using System;
using System.IO;
using Logging;

/// <summary>
/// File utility class for easing use of 
/// common file operations.
/// </summary>
public class FileUtils
{
	#if LOGGING
	private static ILogger Log = LogFactory.CreateLogger( typeof( FileUtils ) );
	#endif

	/// <summary>
	/// Reads data from a file to a string.
	/// </summary>
	/// <returns>The string data read from the file.</returns>
	/// <<param name="filePath">The path of the file to be created.</param>
	public static String ReadFileToString( String filePath )
	{
		#if LOGGING
		Log.Trace( "Begin String ReadFileToString( String filePath )" );
		#endif

		#if PARAM_CHECKING
		if( filePath == null )
		{
			throw new ArgumentException( "parameter filePath is required" );
		}
		
		if( String.IsNullOrEmpty( filePath ) )
		{
			throw new ArgumentException( "parameter filePath must be non-empty" );
		}
		#endif
		
		String data = System.IO.File.ReadAllText( filePath );

		#if LOGGING
		Log.Trace( "End String ReadFileToString( String filePath )" );
		#endif

		return data;
	}

	/// <summary>
	/// Writes string data to a file.
	/// </summary>
	/// <param name="filePath">The path of the file to be created.</param>
	/// <param name="data">The string data to be written to the file.</param>
	public static void WriteStringToFile( String filePath, String data )
	{
		#if LOGGING
		Log.Trace( "Begin void WriteStringToFile( String filePath, String data )" );
		#endif

		#if PARAM_CHECKING
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
		#endif

		StreamWriter sw = File.CreateText( filePath );
		sw.Write( data );
		sw.Close();

		#if LOGGING
		Log.Trace( "End void WriteStringToFile( String filePath, String data )" );
		#endif
	}
}