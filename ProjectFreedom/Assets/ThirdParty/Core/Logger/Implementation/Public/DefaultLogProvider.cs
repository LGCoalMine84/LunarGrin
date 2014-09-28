using System;
using UnityEngine;

namespace LunarGrin.Utilities
{
	/// <summary>
	/// This is the default log provider.  This class forwards
	/// logging statements to the Unity console.
	/// </summary>
	public class DefaultLogProvider : ILogProvider, ILogger
	{
		private Type type;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultLogProvider"/> class.
		/// </summary>
		public DefaultLogProvider()
		{
		}
		
		/// <summary>
		/// Creates a logger that is associated with a particular type.
		/// </summary>
		/// <returns>The logger interface that is to be used by the specified type.</returns>
		/// <param name="type">The type of the class that is creating a logger.</param>
		public ILogger CreateLogger( Type type )
		{
			#if PARAM_CHECKING
			if( type == null )
			{
				throw new ArgumentException( "parameter type is required" );
			}
			#endif
			
			return new DefaultLogProvider( type );
		}
		
		/// <summary>
		/// Writes an error message to the logging system.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="context">An object that is associated with the context in which the error occurred.</param>
		public void Error( String message = null, object context = null )
		{
			Debug.LogError( type.ToString() + ": " + message );
		}
		
		/// <summary>
		/// Writes a trace message to the logging system.
		/// </summary>
		/// <param name="message">The trace message.</param>
		/// <param name="context">An object that is associated with the context in which the trace occurred.</param>
		public void Trace( String message = null, object context = null )
		{
			Debug.Log( type.ToString() + ": " + message );
		}
		
		/// <summary>
		/// Writes a warning message to the logging system.
		/// </summary>
		/// <param name="message">The warning message.</param>
		/// <param name="context">An object that is associated with the context in which the warning occurred.</param>
		public void Warning( String message = null, object context = null )
		{
			Debug.LogWarning( type.ToString() + ": " + message );
		}
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultLogProvider"/> class.
		/// </summary>
		/// <param name="type">The type of the class that is creating a logger.</param>
		private DefaultLogProvider( Type type )
		{
			#if PARAM_CHECKING
			if( type == null )
			{
				throw new ArgumentException( "parameter type is required" );
			}
			#endif
			
			this.type = type;
		}
	}
}