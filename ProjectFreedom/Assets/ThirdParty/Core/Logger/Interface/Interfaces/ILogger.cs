
using System;

namespace LunarGrin.Utilities
{
	/// <summary>
	/// The main logging interface used by classes.  This
	/// is the interface returned from the LogFactory.  Classes
	/// call these methods and don't have to know where the logging
	/// data is actually going.
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Writes an error message to the logging system.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="context">An object that is associated with the context in which the error occurred.</param>
		void Error( String message = null, object context = null );
		
		/// <summary>
		/// Writes a trace message to the logging system.
		/// </summary>
		/// <param name="message">The trace message.</param>
		/// <param name="context">An object that is associated with the context in which the trace occurred.</param>
		void Trace( String message = null, object context = null );
		
		/// <summary>
		/// Writes a warning message to the logging system.
		/// </summary>
		/// <param name="message">The warning message.</param>
		/// <param name="context">An object that is associated with the context in which the warning occurred.</param>
		void Warning( String message = null, object context = null );
	}
}