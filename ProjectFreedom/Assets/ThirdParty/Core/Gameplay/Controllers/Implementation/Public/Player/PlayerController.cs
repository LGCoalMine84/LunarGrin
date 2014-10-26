#region File Header

// File Name:		PlayerController.cs
// Author:			John Whitsell
// Creation Date:	2014/09/07
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The Player Controller that represents the player's will in the game.  The Player Controller can possess 
	/// a <see cref="Pawn"/> in the game world and control it using various types of <see cref="IControls"/>.  
	/// The Player Controller also uses a <see cref="GameCamera"/> to control the player's point of view in the game world.
    /// </summary>
    public class PlayerController : BaseController
    {   
        /// <summary>
        /// The GameCamera is a player's point of view in the game world.
        /// </summary>
        private GameCamera playerCamera = null;
        
        /// <summary>
        /// Gets the player camera.
        /// </summary>
        /// <value>The player camera.</value>
        public GameCamera PlayerCamera
        {
        	get
        	{
        		return playerCamera;
        	}
        }
        
        /// <summary>
        /// Creates the player camera.
        /// </summary>
        /// <returns>The player camera.</returns>
        /// <typeparam name="T">The camera controller script to assign to the camera.</typeparam>
        public T CreatePlayerCamera<T>() where T : GameCamera
        {
			UnityEngine.Object cameraPrefab = Resources.Load( "Prefabs/Camera/GameCamera" );
			
			if ( cameraPrefab != null )
			{
				GameObject goPlayerCamera = GameObject.Instantiate( cameraPrefab, Vector3.zero, Quaternion.identity ) as GameObject;
				
				if ( goPlayerCamera != null )
				{
					playerCamera = goPlayerCamera.AddComponent<T>();
					
					if ( PlayerCamera != null )
					{
						PlayerCamera.transform.parent = transform;

						return (T)playerCamera;
					}
					else
					{
						throw new InvalidOperationException( "PlayerController.CreatePlayerCamera - Unable to instantiate the specified camera controller script." );
					}
				}
				else
				{
					throw new InvalidOperationException( "PlayerController.CreatePlayerCamera - Unable to instantiate the camera prefab." );
				}
			}
			else
			{
				throw new InvalidOperationException( "PlayerController.CreatePlayerCamera - Unable to find the camera prefab." );
			}
        }
    }
}