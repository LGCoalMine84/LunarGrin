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
using UnityEngine;
using System;
#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The Player Controller that represents the player's will in the game.  The Player Controller can possess a <see cref="Pawn"/> in the game world and control it using various types of <see cref="IControls"/>.  The Player Controller also uses a <see cref="GameCamera"/> to control the player's point of view in the game world.
    /// </summary>
    public class PlayerController : BaseController
    {   
        /// <summary>
        /// The GameCamera is a player's point of view in the game world.
        /// </summary>
        public GameCamera PlayerCamera = null;
    }
}