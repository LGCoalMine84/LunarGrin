#region File Header

// File Name:           SerializableDictionary.cs
// Author:              Andy Sanchez
// Creation Date:       9/28/2014   3:29 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

using UnityEngine;

#endregion

namespace LunarGrin.Utilities
{
    /// <summary>
    /// Serializable dictionary that is both supported by DotNet and Unity.
    /// </summary>
    /// <typeparam name="K">The key type in the dictionary.</typeparam>
    /// <typeparam name="V">The value type in the dictionary.</typeparam>
    /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
    /// <seealso cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>
    /// <seealso cref="System.Collections.IEnumerable."/>
    [Serializable]
    public class SerializableDictionary<K, V> : ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable
    {
        #region Helper Classes

        /// <summary>
        /// Enumerator used for the <see cref="LunarGrin.Utilities.SerializableDictionary"/> class.
        /// This structure is similar to an iterator.
        /// </summary>
        /// <typeparam name="K2">The key type in the enumerator.</typeparam>
        /// <typeparam name="V2">The value type in the enumerator.</typeparam>
        /// <seealso cref="System.Collection.Generic.IEnumerator<T>."/>
        public struct SerializableDictionaryEnumerator<K2, V2> : IEnumerator<KeyValuePair<K2, V2>>, IEnumerator, IDisposable
        {
            #region Private Fields

            /// <summary>
            /// The reference to the serializable dictionary.
            /// </summary>
            private SerializableDictionary<K2, V2> collection;

            /// <summary>
            /// The current value that the enumerator is pointing at.
            /// </summary>
            private KeyValuePair<K2, V2> currentVal;

            /// <summary>
            /// The initial amount of elements serializable dictionary.
            /// </summary>
            private Int32 initialCount;

            /// <summary>
            /// The current numerical index the enumerator is in.
            /// </summary>
            private Int32 index;

            #endregion

            #region Properties

            #region IEnumerator<T>

            /// <summary>
            /// Gets the current element the enumerator is pointing at.
            /// </summary>
            /// <value>The element the enumerator is pointing at.</value>
            public KeyValuePair<K2, V2> Current
            {
                get
                {
                    return currentVal;
                }
            }

            /// <summary>
            /// Gets the current element the enumerator is pointing at.
            /// </summary>
            /// <value>The element the enumerator is pointing at.</value>
            System.Object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            #endregion

            #endregion

            #region Constructors

            /// <summary>
			/// Explicit constructor initializes the <see cref="LunarGrin.Utilities.SerializableDictionaryEnumerator"/> structure. 
            /// </summary>
            /// <param name="dictionary">The serializable dictionary this enumerator will be bound to.</param>
            /// <exception cref="NullReferenceException">Unable to create the serializable dictionary enumerator because the dictionary reference is invalid.</exception>
            public SerializableDictionaryEnumerator( SerializableDictionary<K2, V2> dictionary )
            {
                if( dictionary == null )
                {
                    throw new NullReferenceException( "Unable to create the serializable dictionary enumerator because the dictionary reference is invalid." );
                }

                collection = dictionary;

                currentVal = default( KeyValuePair<K2, V2> );
                initialCount = dictionary.Count;
                index = -1;
            }

            #endregion

            #region Public Methods

            #region IEnumerator<T>

            /// <summary>
            /// Determines whether the enumerator can move to the next element in the collection.
            /// </summary>
            /// <returns><c>True</c> if enumerator can move to the next element in the collection.</returns>
            /// <exception cref="InvalidOperationException">The serializable dictionary was modified after the enumerator was created.</exception>
            /// <seealso cref="System.Collection.Generic.IEnumerator<T>."/>
            public Boolean MoveNext()
            {
                if( collection.Count != initialCount )
                {
                    throw new InvalidOperationException( "The serializable dictionary was modified after the enumerator was created." );
                }

                if( ++index >= collection.Count )
                {
                    return false;
                }

                currentVal = collection.GetKeyAndValueFromIndex( index );

                return true;
            }

            /// <summary>
            /// Resets the enumerator index.
            /// </summary>
            /// <seealso cref="System.Collection.Generic.IEnumerator<T>."/>
            public void Reset()
            {
                index = -1;
            }

            /// <summary>
			/// Releases all resources used by the <see cref="LunarGrin.Utilities.SerializableDictionaryEnumerator"/> class.
            /// </summary>
            /// <remarks>
			/// Unused in the <see cref="LunarGrin.Utilities.SerializableDictionaryEnumerator"/> class.
            /// </remarks>
            /// <seealso cref="System.Collection.Generic.IEnumerator<T>."/>
            public void Dispose()
            {

            }

            #endregion

            #endregion
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// Internal container that holds the data in the serializable dictionary.
        /// </summary>
        private Dictionary<K, V> internalMap = null;

        /// <summary>
        /// The keys that will be serialized and deserialized within the serializable dictionary..
        /// </summary>
        [SerializeField]
        private List<K> mapKeys = null;

        /// <summary>
        /// The values that will be serialized and deserialized within the serializable dictionary..
        /// </summary>
        [SerializeField]
        private List<V> mapValues = null;

        /// <summary>
        /// Gets whether the serializable dictionary is read-only.
        /// </summary>
        private Boolean isReadOnly = false;

        #endregion

        #region Properties

        #region ICollection<T>

        /// <summary>
        /// Gets whether the serializable dictionary is read-only.
        /// </summary>
        /// <value><c>True</c> if the serializable dictionary is read-only.</value>
        /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
        public Boolean IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Gets the amount of elements in the collection.
        /// </summary>
        /// <value>The amount of elements in the collection.</value>
        public Int32 Count
        {
            get
            {
                return internalMap.Count;
            }
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Index access to the value elements given a key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>The value bound to the given key.</returns>
        /// <remarks>
        /// If using the indexer as a getter, it will return the value if they key was found; else it will return the default value for the value element type.
        /// If using the indexer as a setter, it will assigned the new value to the key if they key was found; else it will add the new key and the value specified to
        /// the serializable dictionary.
        /// </remarks>
        public V this[K key]
        {
            get
            {
                V val = default( V );
                if( internalMap != null && internalMap.TryGetValue( key, out val ) )
                {
                    return val;
                }

                return default( V );
            }

            set
            {
                V val = default( V );
                if( internalMap != null && internalMap.TryGetValue( key, out val ) )
                {
                    internalMap[key] = value;
                }
                else
                {
                    Add( key, value );
                }
            }
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
		/// Default constructor initializes the <see cref="LunarGrin.Utilities.SerializableDictionary&lt;K, V&gt;"/> class.
        /// </summary>
        public SerializableDictionary()
        {
            internalMap = new Dictionary<K, V>();

            mapKeys = new List<K>();
            mapValues = new List<V>();
        }

        /// <summary>
		/// Explicit constructor initializes the <see cref="LunarGrin.Utilities.SerializableDictionary&lt;K, V&gt;"/> class with the
        /// elements of the given dictionary collection.
        /// </summary>
        /// <param name="dictionary">Dictionary collection with the elements to fill the serializable dictionary with.</param>
        /// <exception cref="ArgumentNullException">Unable to initialize the serializable dictionary because the given data collection is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to initialize the serializable dictionary because the internal map failed to initialize."</exception>
        /// <exception cref="InvalidOperationException">Unable to initialize the serializable dictionary because failed when populating the internal lists.</exception>
        public SerializableDictionary( IDictionary<K, V> dictionary )
        {
            if( dictionary == null )
            {
                throw new ArgumentNullException( "Unable to initialize the serializable dictionary because the given data collection is invalid." );
            }

            try
            {
                internalMap = new Dictionary<K, V>( dictionary );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to initialize the serializable dictionary because the internal map failed to initialize.", ex );	
            }

            mapKeys = new List<K>();
            mapValues = new List<V>();

            try
            {
                PopulateListsFromInternalMap();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to initialize the serializable dictionary because failed when populating the internal lists.", ex );
            }
        }

        #endregion

        #region Public Methods 

        #region ICollection<T>

        #region Public Implementation

        /// <summary>
        /// Adds a key and its corresponding value to the dictionary through a key and value pair.
        /// </summary>
        /// <param name="pair">The key and value pair to add.</param>
        /// <exception cref="InvalidOperationException">Unable to add to the serializable dictionary.</exception>
        /// <remarks>
        /// This method must be public because the internal DotNet IXMLSerializable interface requires it.
        /// </remarks>
        /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
        public void Add( KeyValuePair<K, V> pair )
        {
            try
            {
                Add( pair.Key, pair.Value );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to add to the serializable dictionary.", ex );
            }
        }

        /// <summary>
        /// Clears the data in the serializable dictionary.
        /// </summary>
        /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
        public void Clear()
        {
            if( internalMap != null )
            {
                internalMap.Clear();
            }

            if( mapKeys != null )
            {
                mapKeys.Clear();
            }

            if( mapValues != null )
            {
                mapValues.Clear();
            }
        }

        #endregion

        #region Hidden Implementation

        /// <summary>
        /// Removes a key and its corresponding value from the dictionary through a key and value pair.
        /// </summary>
        /// <param name="pair">The key and value pair to remove.</param>
        /// <returns><c>True</c> if the key and value were succesfully removed from the dictionary.</returns>
        /// <exception cref="InvalidOperationException">Unable to remove a key and value pair from the serializable dictionary.</exception>
        /// <exception cref="InvalidOperationException">Unable to remove the key and value pair from the serializable dictionary because of an internal map failure.</exception>
        /// <remarks>
        /// This method has been explicitly declared through its interface to hide it from serializable dictionary user.
        /// </remarks>
        /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
        Boolean ICollection<KeyValuePair<K, V>>.Remove( KeyValuePair<K, V> pair )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to remove a key and value pair from the serializable dictionary.", ex );
            }

            ICollection<KeyValuePair<K,V>> collection = (ICollection<KeyValuePair<K,V>>)internalMap;

            try
            {
                return collection.Remove( pair );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to remove the key and value pair from the serializable dictionary because of an internal map failure.", ex );
            }
        }
    
        /// <summary>
        /// Determines whether the serializable dictionary contains a specific key and value pair.
        /// </summary>
        /// <param name="pair">The key and value to search for.</param>
        /// <returns><c>True</c> if the key and value are found within the dictionary.</returns>
        /// <exception cref="InvalidOperationException">Unable to search key and value pair from the serializable dictionary.</exception>
        /// <exception cref="InvalidOperationException">Unable to search the key and value pair from the serializable dictionary because of an internal map failure.</exception>
        /// <remarks>
        /// This method has been explicitly declared through its interface to hide it from serializable dictionary user.
        /// </remarks>
        /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
        Boolean ICollection<KeyValuePair<K, V>>.Contains( KeyValuePair<K, V> pair )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to search key and value pair from the serializable dictionary.", ex );
            }


            ICollection<KeyValuePair<K, V>> collection = (ICollection<KeyValuePair<K, V>>)internalMap;

            try
            {
                return collection.Contains( pair );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to search the key and value pair from the serializable dictionary because of an internal map failure.", ex );
            }
        }

        /// <summary>
        /// Copies the contents of the serializable dictionary into an array.
        /// </summary>
        /// <param name="array">The array to copy the keys and their corresponding values to.</param>
        /// <param name="index">The index at which copying begins.</param>
        /// <exception cref="InvalidOperationException">Unable to copy key and value pairs from the serializable dictionary."</exception>
        /// <exception cref="ArgumentNullException">Unable to copy the data from the serializable dictionary to an array because the array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Unable to copy the data from the serializable dictionary to an array because the index if less than zero.</exception>
        /// <exception cref="ArgumentException">Unable to copy the data from the serializable dictionary to an array because the internal map count is greater than the length of the array.</exception>
        /// <remarks>
        /// This method has been explicitly declared through its interface to hide it from serializable dictionary user.
        /// </remarks>
        /// <seealso cref="System.Collections.Generic.ICollection&lt;T&gt;"/>
        void ICollection<KeyValuePair<K, V>>.CopyTo( KeyValuePair<K, V>[] array, Int32 index )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to copy key and value pairs from the serializable dictionary.", ex );
            }

            if( array == null )
            {
                throw new ArgumentNullException( "Unable to copy the data from the serializable dictionary to an array because the array is null." );
            }

            if( index < 0 )
            {
                throw new ArgumentOutOfRangeException( "Unable to copy the data from the serializable dictionary to an array because the index if less than zero." );
            }

            if( array.Length < internalMap.Count )
            {
                throw new ArgumentException( "Unable to copy the data from the serializable dictionary to an array because the internal map count is greater than the length of the array." );
            }

            ICollection<KeyValuePair<K, V>> collection = (ICollection<KeyValuePair<K, V>>)internalMap;
            collection.CopyTo( array, index );
        }

        #endregion

        #endregion

        #region IEnumerable<T>

        /// <summary>
        /// Gets the enumerator/iterator of the serializable dictionary.
        /// </summary>
        /// <returns>The serializable dictionary enumerator.</returns>
        /// <seealso cref="System.Collections.Generic.IEnumerable&lt;T&gt;."/>
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return new SerializableDictionaryEnumerator<K, V>( this );
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// Gets the enumerator/iterator of the serializable dictionary.
        /// </summary>
        /// <returns>The serializable dictionary enumerator.</returns>
        /// <seealso cref="System.Collections.IEnumerable."/>
        /// <remarks>
        /// This method has been explicitly declared through its interface to hide it from serializable dictionary user.
        /// </remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SerializableDictionaryEnumerator<K, V>( this );
        }

        #endregion

        #region Add, Remove and Contains Helpers

        /// <summary>
        /// Adds a key and its corresponding value to the dictionary.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        /// <exception cref="InvalidOperationException">Unable to add a key and value pair to the serializable dictionary.</exception>
        /// <exception cref="ArgumentNullException">Unable to add the element to the serializable dictionary because the given key is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to add to the serializable dictionary because of an internal map failure.</exception>
        public void Add( K key, V value )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to add a key and value pair to the serializable dictionary.", ex );
            }

            if( key == null )
            {
                throw new ArgumentNullException( "Unable to add the element to the serializable dictionary because the given key is invalid." );
            }

            try
            {
                internalMap.Add( key, value );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to add to the serializable dictionary because of an internal map failure.", ex );
            }

            mapKeys.Add( key );
            mapValues.Add( value );
        }

        /// <summary>
        /// Removes a key and its corresponding value from the dictionary.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns><c>True</c> if the key and its corresponding value were removed from the dictionary. Will return <c>false</c> if the key was not found.</returns>
        /// <exception cref="InvalidOperationException">Unable to remove a key and value pair from the serializable dictionary.</exception>
        /// <exception cref="ArgumentNullException">Unable to remove the element from the serializable dictionary because the given key is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to remove from the serializable dictionary because of an internal map failure.</exception>
        public Boolean Remove( K key )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to remove a key and value pair from the serializable dictionary.", ex );
            }

            if( key == null )
            {
                throw new ArgumentNullException( "Unable to remove the element from the serializable dictionary because the given key is invalid." );
            }

            Boolean success = false;
            V value = default( V );

            try
            {
                if( internalMap.TryGetValue( key, out value ) )
                {
                    success = internalMap.Remove( key );

                    if( success )
                    {
                        success = mapKeys.Remove( key );
                    }

                    if( success )
                    {
                        success = mapValues.Remove( value );
                    }
                }
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to remove from the serializable dictionary because of an internal map failure.", ex );
            }

            return success;
        }

        /// <summary>
        /// Determines whether the serializable dictionary contains a specific key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns><c>True</c> if the key was found within the serializable dictionary.</returns>
        /// <exception cref="InvalidOperationException">Unable to search for a key and value pair from the serializable dictionary.</exception>
        /// <exception cref="ArgumentNullException">Unable to find the key within the serializable dictionary because the key is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to find the key within the serializable dictionary.</exception>
        public Boolean ContainsKey( K key )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to search for a key and value pair from the serializable dictionary.", ex );
            }

            if( key == null )
            {
                throw new ArgumentNullException( "Unable to find the key within the serializable dictionary because the key is invalid." );
            }

            try
            {
                return internalMap.ContainsKey( key );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to find the key within the serializable dictionary.", ex );
            }
        }

        /// <summary>
        /// Determines whether the serializable dictionary contains a specific value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns><c>True</c> if the value was found within the serializable dictionary.</returns>
        /// <exception cref="InvalidOperationException">Unable to search for a key and value pair from the serializable dictionary.</exception>
        /// <exception cref="ArgumentNullException">Unable to find the value within the serializable dictionary because the value is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to find the value within the serializable dictionary.</exception>
        public Boolean ContainsValue( V value )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to search for a key and value pair from the serializable dictionary.", ex );
            }

            if( value == null )
            {
                throw new ArgumentNullException( "Unable to find the value within the serializable dictionary because the value is invalid." );
            }

            try
            {
                return internalMap.ContainsValue( value );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to find the value within the serializable dictionary.", ex );
            }
        }

        #endregion

        #region Miscellaneous Methods

        /// <summary>
        /// Gets the key and value from serializable dictionary given an index.
        /// </summary>
        /// <param name="index">The index to search the key and value with.</param>
        /// <returns>The key and value at the position specified by the index.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the the key and corresponding value from the serializable dictionary.</exception>
        /// <exception cref="IndexOutOfRangeException">Unable to get the key and value from the serializable dictionary because the index is past the end of the internal map.</exception>
        public KeyValuePair<K, V> GetKeyAndValueFromIndex( Int32 index )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the the key and corresponding value from the serializable dictionary.", ex );
            }

            if( index >= internalMap.Count )
            {
                throw new IndexOutOfRangeException( "Unable to get the key and value from the serializable dictionary because the index is past the end of the internal map." );
            }

            return GetKeyValueByIndex( index );
        }

        /// <summary>
        /// Gets a key from serializable dictionary given an index.
        /// </summary>
        /// <param name="index">The index to search the key with.</param>
        /// <returns>The key at the position specified by the index.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the the key from the serializable dictionary.</exception>
        public K GetKeyFromIndex( Int32 index )
        {
            KeyValuePair<K, V> pair;
            try
            {
                pair = GetKeyAndValueFromIndex( index );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the the key from the serializable dictionary.", ex );
            }

            return pair.Key;
        }

        /// <summary>
        /// Gets a value from serializable dictionary given an index.
        /// </summary>
        /// <param name="index">The index to search the value with.</param>
        /// <returns>The value at the position specified by the index.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the the value from the serializable dictionary.</exception>
        public V GetValueFromIndex( Int32 index )
        {
            KeyValuePair<K, V> pair;
            try
            {
                pair = GetKeyAndValueFromIndex( index );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the the value from the serializable dictionary.", ex );
            }

            return pair.Value;
        }

        /// <summary>
        /// Gets a value associated with the given key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">If the key is found, this out parameter will contain the value associated with the specified key.</param>
        /// <returns><c>True</c> if successfully obtained the value from the dictionary.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the the value from the serializable dictionary.</exception>
        /// <exception cref="ArgumentNullException">Unable to get the value from the serializable dictionary because the given key is invalid.</exception>
        /// <exception cref="InvalidOperationException">Unable to get the value from the serializable dictionary because of an internal map failure.</exception>
        /// <remarks>
        /// If the key is not found within the internal map, the out parameter value will contain the default value for the type of the value.
        /// </remarks>
        public Boolean TryGetValue( K key, out V value )
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the the value from the serializable dictionary.", ex );
            }

            value = default( V );

            if( key == null )
            {
                throw new ArgumentNullException( "Unable to get the value from the serializable dictionary because the given key is invalid." );
            }

            try
            {
                return internalMap.TryGetValue( key, out value );
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the value from the serializable dictionary because of an internal map failure.", ex );
            }
        }

        /// <summary>
        /// Gets an array of all the keys in the serializable dictionary.
        /// </summary>
        /// <returns>The keys in the serializable dictionary as an array.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the keys array from the serializable dictionary.</exception>
        public K[] GetKeysAsArray()
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the keys array from the serializable dictionary.", ex );
            }

            return mapKeys.ToArray();
        }

        /// <summary>
        /// Gets an array of all the values in the serializable dictionary.
        /// </summary>
        /// <returns>The values in the serializable dictionary as an array.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the values array from the serializable dictionary.</exception>
        public V[] GetValuesAsArray()
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the values array from the serializable dictionary.", ex );
            }

            return mapValues.ToArray();
        }

        /// <summary>
        /// Gets a DotNet dictionary with a copy of the contents of the serializable dictionary.
        /// </summary>
        /// <returns>A DotNet dictionary with the copy of the contents of the serializable dictionary.</returns>
        /// <exception cref="InvalidOperationException">Unable to get the DotNet dictionary from the serializable dictionary.</exception>
        /// <exception cref="InvalidOperationException">Unable to get the DotNet dictionary because failed to add the serializable dictionary elements to it.</exception>
        public IDictionary<K, V> ToDictionary()
        {
            try
            {
                CheckForValidContainers();
                CheckForMapAndListSynchronization();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the DotNet dictionary from the serializable dictionary.", ex );
            }

            Dictionary<K, V> toReturn = null;

            try
            {
                toReturn = new Dictionary<K, V>( internalMap.Count );

                foreach( KeyValuePair<K, V> entry in internalMap )
                {
                    toReturn.Add( entry.Key, entry.Value );
                }
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to get the DotNet dictionary because failed to add the serializable dictionary elements to it.", ex );
            }

            return toReturn;
        }

        #endregion

        #region Overrides

        /// <summary>
		/// Gets information about the <see cref="LunarGrin.Utilities.SerializableDictionary"/> class.
        /// </summary>
		/// <returns>The information about the <see cref="LunarGrin.Utilities.SerializableDictionary"/> class.</returns>
        /// <seealso cref="System.Object"/>
        public override String ToString()
        {
            if( internalMap != null )
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Append( "Serializable Dictionary: " );

                strBuilder.AppendLine();

                foreach( KeyValuePair<K, V> entry in internalMap )
                {
                    strBuilder.Append( "Key: " );
                    strBuilder.Append( entry.Key );
                    strBuilder.AppendLine();

                    strBuilder.Append( "Value: " );
                    strBuilder.Append( entry.Value );
                    strBuilder.AppendLine();
                }

                return strBuilder.ToString();
            }

            return String.Empty;
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks the the internal map and lists are valid.
        /// </summary>
        /// <exception cref="NullReferenceException">The internal map in the serializable dictionary is invalid.</exception>
        /// <exception cref="NullReferenceException">The internal key list in the serializable dictionary is invalid.</exception>
        /// <exception cref="NullReferenceException">The internal value list in the serializable dictionary is invalid.</exception>
        private void CheckForValidContainers()
        {
            if( internalMap == null )
            {
                throw new NullReferenceException( "The internal map in the serializable dictionary is invalid." );
            }

            if( mapKeys == null )
            {
                throw new NullReferenceException( "The internal key list in the serializable dictionary is invalid." );
            }

            if( mapValues == null )
            {
                throw new NullReferenceException( "The internal value list in the serializable dictionary is invalid." );
            }
        }

        /// <summary>
        /// Checks that the internal map and lists are synchronized.
        /// </summary>
        /// <exception cref="InvalidOperationException">The internal map count does not match the internal key list count.</exception>
        /// <exception cref="InvalidOperationException">The internal map count does not match the internal value list count.</exception>
        /// <exception cref="InvalidOperationException">The internal key list count does not match the internal value list count.</exception>
        private void CheckForMapAndListSynchronization()
        {
            if( internalMap.Count != mapKeys.Count )
            {
                throw new InvalidOperationException( "The internal map count does not match the internal key list count." );
            }

            if( internalMap.Count != mapValues.Count )
            {
                throw new InvalidOperationException( "The internal map count does not match the internal value list count." );
            }

            if( mapKeys.Count != mapValues.Count )
            {
                throw new InvalidOperationException( "The internal key list count does not match the internal value list count." );
            }
        }

        /// <summary>
        /// Populates the internal map based on the contents of the internal lists.
        /// </summary>
        /// <exception cref="InvalidOperationException">Unable to populate the internal map in the serializable dictionary.</exception>
        /// <exception cref="InvalidOperationException">Unable to populate the internal map in the serializable dictionary because the internal lists counts are not equal.</exception>
        /// <exception cref="InvalidOperationException">Unable to populate the internal map in the serializable dictionary because of an internal map failure.</exception>
        private void PopulateInternalMapFromLists()
        {
            try
            {
                CheckForValidContainers();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to populate the internal map in the serializable dictionary.", ex );
            }

            if( mapKeys.Count != mapValues.Count )
            {
                throw new InvalidOperationException( "Unable to populate the internal map in the serializable dictionary because the internal lists counts are not equal." );
            }

            internalMap.Clear();

            try
            {
                for( Int32 i = 0; i < mapKeys.Count; ++i )
                {
                    internalMap.Add( mapKeys[i], mapValues[i] );
                }
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to populate the internal map in the serializable dictionary because of an internal map failure.", ex );
            }
        }

        /// <summary>
        /// Populates the internal lists from the content in the internal map.
        /// </summary>
        /// <exception cref="InvalidOperationException">Unable to populate the internal lists in the serializable dictionary."</exception>
        private void PopulateListsFromInternalMap()
        {
            try
            {
                CheckForValidContainers();
            }
            catch( Exception ex )
            {
                throw new InvalidOperationException( "Unable to populate the internal lists in the serializable dictionary.", ex );
            }

            mapKeys.Clear();
            mapValues.Clear();

            foreach( KeyValuePair<K, V> entry in internalMap )
            {
                mapKeys.Add( entry.Key );
                mapValues.Add( entry.Value );
            }
        }
        
        /// <summary>
        /// Gets a key and a value pair from the internal map given an index.
        /// </summary>
        /// <param name="index">The index to search the value with.</param>
        /// <returns>The key and value pair filled with the data at the specified index.</returns>
        private KeyValuePair<K, V> GetKeyValueByIndex( Int32 index )
        {
            if( index >= mapKeys.Count )
            {
                return default( KeyValuePair<K, V> );
            }

            K key = mapKeys[index];
            
            V value = default( V );
            if( !internalMap.TryGetValue( key, out value ) )
            {
                return default( KeyValuePair<K, V> );
            }

            return new KeyValuePair<K, V>( key, value );
        }

        #endregion
    }
}
