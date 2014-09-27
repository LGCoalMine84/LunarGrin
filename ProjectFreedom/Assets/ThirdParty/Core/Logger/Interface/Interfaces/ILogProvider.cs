using System;

namespace Logging
{
	/// <summary>
	/// A log provider interface.  Different classes can
	/// implement this interface and be instanced in the LogFactory
	/// in order to forward the logging statements to a given target
	/// (file on file system, default unity console log, network, etc).
	/// </summary>
	public interface ILogProvider
	{
		/// <summary>
		/// Creates a logger that is associated with a particular type.
		/// </summary>
		/// <returns>The logger interface that is to be used by the specified type.</returns>
		/// <param name="type">The type of the class that is creating the logger.</param>
		ILogger CreateLogger( Type type );
	}
}