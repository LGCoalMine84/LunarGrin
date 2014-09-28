#region File Header

// File Name:           CoroutineManager.cs
// Author:              Andy Sanchez
// Creation Date:       9/28/2014   3:18 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace LunarGrin.Utilities
{
    /// <summary>
    /// Handles all the coroutines in the system.
    /// </summary>
    /// <remarks>
    /// This class implements the singleton pattern. See <see cref="LunarGrin.Utilities.Singleton&lt;T&gt;"/>.
    /// </remarks>
    public sealed class CoroutineManager : Singleton<CoroutineManager>
    {
        #region Constants

        /// <summary>
        /// The default id assigned to a coroutine.
        /// </summary>
        private const String CoroutineDefaultId = "Coroutine";

        #endregion

        #region Helpers Classes

        /// <summary>
        /// Represents an internal coroutine object within the manager.
        /// </summary>
        internal class Coroutine : IEquatable<Coroutine>
        {
            #region Internal Fields

            /// <summary>
            /// The id of the coroutine.
            /// </summary>
            internal String coroutineId = null;

            /// <summary>
            /// The reference to the coroutine.
            /// </summary>
            internal IEnumerator coroutine = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Explicit constructor to build the coroutine object.
            /// </summary>
            /// <param name="id">The id of the coroutine.</param>
            /// <param name="enumerator">The reference to the coroutine.</param>
            /// <exception cref="ArgumentNullException">Unable to build the coroutine object because the id parameter is invalid.</exception>
            /// <exception cref="ArgumentNullException">Unable to build the coroutine object because the routine parameter is invalid.</exception>
            internal Coroutine( String id, IEnumerator enumerator )
            {
                if( String.IsNullOrEmpty( id ) )
                {
                    throw new ArgumentNullException( "Unable to build the coroutine object because the id parameter is invalid." );
                }

                if( enumerator == null )
                {
                    throw new ArgumentNullException( "Unable to build the coroutine object because the routine parameter is invalid." );
                }

                coroutineId = id;
                coroutine = enumerator;
            }

            #endregion

            #region Internal Methods

            /// <summary>
            /// Clears the data within the coroutine.
            /// </summary>
            internal void Clear()
            {
                coroutineId = null;
                coroutine = null;
            }

            #region Overrides

            /// <summary>
            /// Determines whether the specified coroutine is equal to the current coroutine.
            /// </summary>
            /// <param name="coroutine">The coroutineto compare against.</param>
            /// <returns><c>True</c> if the content of the coroutine is equal.</returns>
            /// <seealso cref="System.IEquatable<T>"/>
            public Boolean Equals( Coroutine coroutine )
            {
                if( System.Object.ReferenceEquals( coroutine, null ) )
                {
                    return false;
                }

                if( System.Object.ReferenceEquals( this, coroutine ) )
                {
                    return true;
                }

                return ( coroutineId.Equals( coroutine.coroutineId, StringComparison.OrdinalIgnoreCase ) );
            }

            /// <summary>
            /// Determines whether the specified object is equal to the current coroutine.
            /// </summary>
            /// <param name="obj">The object to compare against.</param>
            /// <returns><c>True</c> if the content of the object is equal.</returns>
            /// <seealso cref="System.Object"/>
            public override Boolean Equals( System.Object obj )
            {
                if( obj == null || !( obj is Coroutine ) )
                {
                    return false;
                }

                return Equals( obj as Coroutine );
            }

            /// <summary>
		    /// Gets the hash value for the coroutine.
		    /// </summary>
		    /// <returns>The hash value of the coroutine.</returns>
            /// <seealso cref="System.Object"/>
            public override Int32 GetHashCode()
            {
                return coroutineId.GetHashCode() ^ coroutine.GetHashCode();
            }

            /// <summary>
            /// Gets information about the Coroutine class.
            /// </summary>
            /// <returns>The information about the Coroutine class.</returns>
            /// <seealso cref="System.Object"/>
            public override String ToString()
            {
                return ( "Coroutine Id: " + coroutineId );
            }

            #endregion

            #endregion
        }

        #endregion

        #region Private Fields

        // <summary>
        /// The current logging interface.
        /// </summary>
        private static readonly ILogger log = LogFactory.CreateLogger( typeof( CoroutineManager ) );

        /// <summary>
        /// Holds all the coroutines and their corresponding id.
        /// </summary>
        private Dictionary<String, Coroutine> coroutines = null;

        /// <summary>
        /// Holds the coroutines to update.
        /// </summary>
        private List<Coroutine> coroutinesToUpdate = null;

        /// <summary>
        /// The last available index for the unnamed coroutines.
        /// </summary>
        private Int32 coroutineIndex = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of coroutines currently being handled by the coroutine manager.
        /// </summary>
        /// <value>The amount of coroutines handled by the manager.</value>
        public Int32 Count
        {
            get
            {
                return coroutines.Count;
            }
        }

        /// <summary>
        /// Gets whether the coroutine manager is processing any coroutines.
        /// </summary>
        /// <value><c>True</c> if the coroutine manager is processing coroutines.</value>
        public Boolean IsRunning
        {
            get
            {
                return coroutines.Count > 0;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor initializes a new instance of the <see cref="LunarGrin.Utilities.CoroutineManager"/> class.
        /// </summary>
        private CoroutineManager()
        {
            coroutines = new Dictionary<String, Coroutine>();
            coroutinesToUpdate = new List<Coroutine>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts up a coroutine in the manager.
        /// </summary>
        /// <param name="coroutine">The coroutine to be handled by the manager.</param>
        /// <returns>The reference to the enumerator object to be used if the calling object needs to yield.</returns>
        /// <exception cref="ArgumentNullException">Unable to start coroutine because the enumerator parameter is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to start the coroutine because the internal coroutine map is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to start the coroutine because failed creating the internal coroutine object.</exception>
        public IEnumerator StartCoroutine( IEnumerator coroutine )
        {
            if( coroutine == null )
            {
                throw new ArgumentNullException( "Unable to start the coroutine because the enumerator parameter is invalid." );   
            }

            if( coroutines == null )
            {
                throw new InvalidOperationException( "Unable to start the coroutine because the internal coroutine map is invalid." );
            }

            Coroutine cr = null;
            String coroutineId = CoroutineDefaultId + "_" + coroutineIndex.ToString();

            try
            {
                cr = new Coroutine( coroutineId, coroutine );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to start the coroutine because failed creating the internal coroutine object.", ex );
            }

            coroutines.Add( coroutineId, cr );
            ++coroutineIndex;

            return coroutine;
        }

        /// <summary>
        /// Starts up a coroutine in the manager with a given id.
        /// </summary>
        /// <param name="coroutineId">The id assigned to the coroutine.</param>
        /// <param name="coroutine">The coroutine to be handled by the manager.</param>
        /// <returns>The reference to the enumerator object to be used if the calling object needs to yield.</returns>
        /// <exception cref="ArgumentNullException">Unable to start coroutine because the coroutine parameter id is invalid.</exception>
        /// <exception cref="ArgumentNullException">Unable to start coroutine because the coroutine parameter is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to start the coroutine because the internal coroutine map is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to start the coroutine because failed creating the internal coroutine object.</exception>
        public IEnumerator StartCoroutine( String coroutineId, IEnumerator coroutine )
        {
            if( String.IsNullOrEmpty( coroutineId ) )
            {
                throw new ArgumentNullException( "Unable to start the coroutine because the coroutine parameter id is invalid." );
            }

            if( coroutine == null )
            {
                throw new ArgumentNullException( "Unable to start the coroutine with id '" + coroutineId + "'because the coroutine parameter is invalid." );   
            }

            if( coroutines == null )
            {
                throw new InvalidOperationException( "Unable to start the coroutine with id '" + coroutineId + "' because the internal coroutine map is invalid." );
            }

            Coroutine cr = null;

            try
            {
                cr = new Coroutine( coroutineId, coroutine );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to start the coroutine with id '" + coroutineId + "' because failed creating the internal coroutine object.", ex );
            }

            coroutines.Add( coroutineId, cr );

            return coroutine;
        }

        /// <summary>
        /// Stops a coroutine by its id being processed by the coroutine manager.
        /// </summary>
        /// <exception cref="ArgumentNullException">Unable to stop the coroutine because the coroutine parameter id is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to stop the coroutine because the internal coroutine map is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to stop the coroutine because unable to find the coroutine id within the coroutine map.</exception>
        /// <exception cref="InvalidOperationException">Unable to stop the coroutine because of an error while removing it from the coroutine map.</exception>
        public void StopCoroutineById( String coroutineId )
        {
            if( String.IsNullOrEmpty( coroutineId ) )
            {
                throw new ArgumentNullException( "Unable to stop the coroutine because the coroutine parameter id is invalid." );
            }

            if( coroutines == null )
            {
                throw new InvalidOperationException( "Unable to stop the coroutine with id '" + coroutineId + "'because the internal coroutine map is invalid." );
            }

            Coroutine coroutine = null;
            if( !coroutines.TryGetValue( coroutineId, out coroutine ) )
            {
                throw new InvalidOperationException( "Unable to stop the coroutine with id '" + coroutineId + "'because unable to find the coroutine id within the coroutine map." );
            }

            coroutine.Clear();

            try
            {
                coroutines.Remove( coroutineId );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to stop the coroutine with id '" + coroutineId + "' because of an error while removing it from the coroutine map.", ex );
            }
        }
        
        /// <summary>
        /// Stops all the coroutines being processed by the coroutine manager.
        /// </summary>
        /// <exception cref="InvalidOperationException">Unable to stop all coroutines because the internal coroutine map is invalid.</exception>
        public void StopAllCoroutines()
        {
            if( coroutines == null )
            {
                throw new InvalidOperationException( "Unable to stop all coroutines because the internal coroutine map is invalid." );
            }

            foreach( KeyValuePair<String, Coroutine> coroutine in coroutines )
            {
                coroutine.Value.Clear();
            }

            coroutines.Clear();
        }

        /// <summary>
        /// Updates the coroutine manager.
        /// </summary>
        /// <remarks>
        /// This method must be called every frame.
        /// </remarks>
        public void Update()
        {
            UpdateCoroutines();
        }

        /// <summary>
        /// Destroys the coroutine manager.
        /// </summary>
        public void Destroy()
        {
            if( coroutines != null )
            {
                coroutines.Clear();
                coroutines = null;
            }

            DeleteInstance();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Updates all the coroutines in the coroutine manager.
        /// </summary>
        private void UpdateCoroutines()
        {
            if( coroutines.Count > 0 )
            {
                //Get the references to the coroutines to update.
                coroutinesToUpdate.Clear();
                foreach( KeyValuePair<String, Coroutine> coroutine in coroutines )
                {
                    coroutinesToUpdate.Add( coroutine.Value );
                }

                for( Int32 i = 0; i < coroutinesToUpdate.Count; ++i )
                {
                    // If the coroutine yielded preemptively, then no need to process the enumerator.
                    if( coroutinesToUpdate[i].coroutine == null )
                    {
                        continue;
                    }

                    if( coroutinesToUpdate[i].coroutine.Current is IEnumerator )
                    {
                        if( MoveNext( (IEnumerator)coroutinesToUpdate[i].coroutine.Current ) )
                        {
                            continue;
                        }
                    }

                    if( coroutinesToUpdate[i].coroutine != null )
                    {
                        if( !coroutinesToUpdate[i].coroutine.MoveNext() )
                        {
                            StopCoroutineById( coroutinesToUpdate[i].coroutineId );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Advances the enumerator element of IEnumerator-derived objects.
        /// </summary>
        /// <param name="coroutine">The enumerator to advance forward.</param>
        /// <returns><c>True</c> if the enumerator of the coroutine was advanced to the next element.</returns>
        private Boolean MoveNext( IEnumerator coroutine )
        {
            if( coroutine.Current is IEnumerator )
            {
                if( MoveNext( (IEnumerator)coroutine.Current ) )
                {
                    return true;
                }
            }

            return coroutine.MoveNext();
        }

        #endregion
    }
}
