#region File Header

// File Name:           GameStateChangingEventArgs.cs
// Author:              Andy Sanchez
// Creation Date:       8/30/2014   10:50 PM
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
	/// Event arguments for when a game state is changing.
	/// </summary>
	public class GameStateChangingEventArgs : EventArgs
	{
		#region Private Fields
		
		/// <summary>
		/// The name of the current game state.
		/// </summary>
		private String currentStateName = null;
		
		/// <summary>
		/// The name of the new game state.
		/// </summary>
		private String newStateName = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the name of the current game state.
		/// </summary>
		/// <value>The name of the current game state.</value>
		public String CurrentStateName
		{
			get
			{
				return currentStateName;
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
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.GameStateChangingEventArgs"/> class.
		/// </summary>
		/// <param name="nameOfCurrentState">Name of previous game state.</param>
		/// <param name="nameOfNewState">Name of new game state.</param>
		public GameStateChangingEventArgs( String nameOfCurrentState, String nameOfNewState )
		{
			currentStateName = nameOfCurrentState;
			newStateName = nameOfNewState;
		}
		
		#endregion
	}
}
