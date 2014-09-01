#region File Header

// File Name:           GameStateChangeEventArgs.cs
// Author:              Andy Sanchez
// Creation Date:       8/30/2014   7:45 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Event arguments for when a game state has been changed.
	/// </summary>
	public class GameStateChangedEventArgs : EventArgs
	{
		#region Private Fields
		
		/// <summary>
		/// The name of the previous game state.
		/// </summary>
		private String previousStateName = null;
		
		/// <summary>
		/// The name of the new game state.
		/// </summary>
		private String newStateName = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the name of the previous game state.
		/// </summary>
		/// <value>The name of the previous game state.</value>
		public String PreviousStateName
		{
			get
			{
				return previousStateName;
			}
		}
		
		/// <summary>
		/// Gets the name of the new game state.
		/// </summary>
		/// <value>The name of the new game state.</value>
		public String NewStateName
		{
			get
			{
				return newStateName;
			}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.GameStateChangedEventArgs"/> class.
		/// </summary>
		/// <param name="nameOfPreviousState">Name of previous game state.</param>
		/// <param name="nameOfNewState">Name of new game state.</param>
		public GameStateChangedEventArgs( String nameOfPreviousState, String nameOfNewState )
		{
			previousStateName = nameOfPreviousState;
			newStateName = nameOfNewState;
		}
		
		#endregion
	}
}
