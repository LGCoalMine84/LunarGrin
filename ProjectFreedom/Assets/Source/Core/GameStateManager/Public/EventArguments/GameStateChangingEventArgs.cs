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
		/// The name of the next game state.
		/// </summary>
		private String nextStateName = null;
		
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
		/// Gets the name of the next game state.
		/// </summary>
		/// <value>The name of the next game state.</value>
		public String NextStateName
		{
			get
			{
				return nextStateName;
			}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.Core.GameStateChangingEventArgs"/> class.
		/// </summary>
		/// <param name="nameOfCurrentState">Name of previous game state.</param>
		/// <param name="nameOfNextState">Name of next game state.</param>
		public GameStateChangingEventArgs( String nameOfCurrentState, String nameOfNextState )
		{
			currentStateName = nameOfCurrentState;
			nextStateName = nameOfNextState;
		}
		
		#endregion
	}
}
