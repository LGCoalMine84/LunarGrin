#region File Header

// File Name:           Singleton.cs
// Author:              Andy Sanchez
// Creation Date:       9/28/2014   3:20 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

#endregion

namespace LunarGrin.Utilities
{
    /// <summary>
    /// Abstract class that assists inheriting classes to implement a singleton pattern.
    /// </summary>
    /// <remarks>
    /// Make sure that classes deriving from this class implement their constructors either private or protected.
    /// </remarks>
    /// <typeparam name="T">The inheriting class type that will be implemented as a singleton.</typeparam>
    public abstract class Singleton<T>
    {
        #region Private Fields

        /// <summary>
        /// The object instance to the singleton-derived class.
        /// </summary>
        private static T instance = default( T );

        /// <summary>
        /// The critical section lock object.
        /// </summary>
        private static Object lockObj = new Object();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor initializes a new instance of the <see cref="LunarGrin.Utilities.Singleton&lt;T&gt;"/> class.
		/// </summary>
        protected Singleton()
	    {
            
	    }
		
		#endregion

        #region Public Methods

        /// <summary>
        /// Gets the singleton instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The instance to the singleton of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">Unable to create the instance to the singleton object of type <typeparamref name="T"/>.</exception>
        /// <exception cref="InvalidOperationException">Unable to get the instance to the singleton object of type <typeparamref name="T"/>.</exception>
        public static T GetInstance()
        {
            if( instance == null )
            {
                lock( lockObj )
                {
                    try
                    {
                        instance = (T)Activator.CreateInstance( typeof( T ), true );
                    }
                    catch( Exception ex )
                    {
                        throw new InvalidOperationException( "Unable to create the instance to the singleton object of type '" + typeof( T ) + "'.", ex );
                    }
                }
            }

            if( instance == null )
            {
                throw new InvalidOperationException( "Unable to get the instance to the singleton object of type '" + typeof( T ) + "'." );
            }

            return instance;
        }

        /// <summary>
        /// Deletes the singleton class instance.
        /// </summary>
        public static void DeleteInstance()
        {
            lock( lockObj )
            {
                instance = default( T );
            }
        }

        #region Overrides

        /// <summary>
        /// Gets information about the Singleton class.
        /// </summary>
        /// <returns>The information about the Singleton class.</returns>
        /// <seealso cref="System.Object"/>
        public override String ToString()
        {
            return "Singleton: " + typeof( T ).ToString();
        }

        #endregion

        #endregion
    }
}
