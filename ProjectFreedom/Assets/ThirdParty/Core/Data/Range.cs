#region File Header

// File Name:		Range.cs
// Author:			John Whitsell
// Creation Date:	2015/11/16
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Defines a range between a minimum and maximum value.
	/// </summary>
	public class Range<T> where T : IComparable<T>
	{
		/// <summary>
		/// The minimum value of the range.
		/// </summary>
		public T minimum;
		
		/// <summary>
		/// The maximum value of the range.
		/// </summary>
		public T maximum;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LunarGrin.Core.Range`1"/> class.
		/// </summary>
		public Range()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LunarGrin.Core.Range`1"/> class.
		/// </summary>
		/// <param name="minimum">The minimum value of the range.</param>
		/// <param name="maximum">The maximum value of the range.</param>
		public Range( T minimum, T maximum )
		{
			this.minimum = minimum;
			this.maximum = maximum;
		}
		
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LunarGrin.Core.Range`1"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="LunarGrin.Core.Range`1"/>.</returns>
		public override string ToString ()
		{
			return String.Format( "[{0} to {1]]", minimum, maximum );
		}
		
		/// <summary>
		/// Determines whether this instance is valid.
		/// </summary>
		/// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
		public Boolean IsValid()
		{
			return minimum.CompareTo( maximum ) <= 0;
		}
		
		/// <summary>
		/// Determines whether this instance contains the value.
		/// </summary>
		/// <returns><c>true</c>, if value was contained, <c>false</c> otherwise.</returns>
		/// <param name="value">The value to compare.</param>
		public Boolean ContainsValue( T value )
		{
			return minimum.CompareTo( value ) <= 0 && value.CompareTo( maximum ) <= 0;
		}
		
		/// <summary>
		/// Determines whether this instance is inside the specified range.
		/// </summary>
		/// <returns><c>true</c> if this instance is inside the specified range; otherwise, <c>false</c>.</returns>
		/// <param name="range">The range to compare.</param>
		public Boolean IsInsideRange( Range<T> range )
		{
			return IsValid() && range.IsValid() && range.ContainsValue( minimum ) && range.ContainsValue( maximum );
		}
		
		/// <summary>
		/// Determines whether the specified range is inside this instance.
		/// </summary>
		/// <returns><c>true</c>, if the specified range was contained, <c>false</c> otherwise.</returns>
		/// <param name="range">The range to compare.</param>
		public Boolean ContainsRange( Range<T> range )
		{
			return IsValid() && range.IsValid() && ContainsValue( range.minimum ) && ContainsValue( range.maximum );
		}
	}
}