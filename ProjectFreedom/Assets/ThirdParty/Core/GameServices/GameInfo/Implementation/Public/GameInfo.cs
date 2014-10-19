#region File Header
// File Name:		GameInfo.cs
// Author:			John Whitsell
// Creation Date:	2014/09/28
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using System;

using UnityEngine;

using LunarGrin.Utilities;
#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// The Game Info service is responsible for holding the player controller reference and managing it's creation and destruction.
	/// </summary>
	public class GameInfo : IGameInfo, IGameService
	{
		private static ILogger Log = LogFactory.CreateLogger( typeof( GameInfo ) );
		
		/// <summary>
		/// The type of game service.
		/// </summary>
		private const ServiceType TypeOfGameService = ServiceType.GameInfo;
		
		/// <summary>
		/// The player's controller.
		/// </summary>
		private PlayerController player = null;
		
		/// <summary>
		/// Gets the type of the game service.
		/// </summary>
		/// <value>The type of the game service.</value>
		public ServiceType GameServiceType
		{
			get
			{
				return TypeOfGameService;
			}
		}
		
		/// <summary>
		/// Gets the player's controller.
		/// </summary>
		/// <value>The player's controller.</value>
		public PlayerController Player
		{
			get
			{
				return player;
			}
		}
		
		/// <summary>
		/// Creates the player controller.
		/// </summary>
		/// <returns>The player controller.</returns>
		/// <param name="name">The name that will be assigned to the player's GameObject.</param>
		/// <typeparam name="T">The type of player controller script to assign to the player controller being created.</typeparam>
		public T CreatePlayerController<T>( String name ) where T : PlayerController
		{
			if ( player == null )
			{
				GameObject goPlayerController = new GameObject( name );
				
				T cPlayerController = goPlayerController.AddComponent<T>();
				
				if ( cPlayerController != null )
				{
					player = cPlayerController;
					
					return cPlayerController;
				}
				else
				{
					throw new InvalidOperationException( "GameInfo.CreatePlayerController - Unable to instantiate the specified player controller script." );
				}
			}
			else
			{
				throw new InvalidOperationException( "GameInfo.CreatePlayerController - The player controller has already been initialized." );
			}
			
			return null;
		}

		/// <summary>
		/// Destroys the player controller. If the player controller is still possessing a pawn, the pawn will also be destroyed.
		/// </summary>
		public void DestroyPlayerController()
		{
			if ( player != null )
			{
				if ( player.Pawn != null )
				{
					GameObject.Destroy( player.Pawn );
				}
				
				GameObject.Destroy( player );
				
				player = null;
			}
			else
			{
				Log.Warning( "GameInfo.DestroyPlayerController - Could not destroy the player controller, no player controller exists." );
			}
		}
	}
}