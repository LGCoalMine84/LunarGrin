#region File Header
// File Name:		IGameInfo.cs
// Author:			John Whitsell
// Creation Date:	
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
	/// Interface to the game info.
	/// </summary>
	public interface IGameInfo
	{
		/// <summary>
		/// Gets the player's controller.
		/// </summary>
		/// <value>The player's controller.</value>
		PlayerController Player
		{
			get;
		}
		
		/// <summary>
		/// Creates the player controller.
		/// </summary>
		/// <returns>The player controller.</returns>
		/// <param name="name">The name that will be assigned to the player's GameObject.</param>
		/// <typeparam name="T">The type of player controller script to assign to the player controller being created.</typeparam>
		T CreatePlayerController<T>( String name ) where T : PlayerController;
		
		/// <summary>
		/// Destroys the player controller.  If the player controller is still possessing a pawn, the pawn will also be destroyed.
		/// </summary>
		void DestroyPlayerController();
	}
}