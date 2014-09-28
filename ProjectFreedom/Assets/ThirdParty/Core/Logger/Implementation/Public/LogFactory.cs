using System;

namespace LunarGrin.Utilities
{
	/// <summary>
	/// This is a factory class that creates instances
	/// that are cast to the ILogger interface.
	/// </summary>
	public class LogFactory
	{
		//The DefaultLogProvider just forwards logging statements to the Unity console
		private static ILogProvider provider = new DefaultLogProvider();
		
		/// <summary>
		/// Creates a logger that is associated with a particular type.
		/// </summary>
		/// <returns>The logger interface that is to be used by the specified type.</returns>
		/// <param name="type">The type of the class that is creating a logger.</param>
		public static ILogger CreateLogger( Type type )
		{
			#if PARAM_CHECKING
			if( type == null )
			{
				throw new ArgumentException( "parameter type is required" );
			}
			#endif
			
			return provider.CreateLogger( type );
		}
	}
}