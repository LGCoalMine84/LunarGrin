#region File Header

// File Name:		Player.cs
// Author:			John Whitsell
// Creation Date:	2014/09/13
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Core;
using LunarGrin.Utilities;

#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
    /// <summary>
    /// <para>This is an example implementation of the Player class, derived from PlayerController.</para>
    /// <para>The Player Controller that represents the player's will in the game.  The Player Controller can possess
	/// a <see cref="Pawn"/> in the game world and control it using various types of <see cref="IControls"/>.  The 
	/// Player Controller also uses a <see cref="GameCamera"/> to control the player's point of view in the game world.</para>
    /// </summary>
    public class ExamplePlayer : PlayerController
    {
		private static ILogger Log = LogFactory.CreateLogger( typeof( ExamplePlayer ) );

        /// <summary>
        /// Sets the player move controls.
        /// </summary>
        public void SetPlayerMoveControls()
        {
			Log.Trace( "Begin void SetPlayerMoveControls()" );

            if ( Pawn != null )
            {
                PlayerMoveControls moveControls = new PlayerMoveControls( this );
               
                PushControls( moveControls );
            }

			Log.Trace( "End void SetPlayerMoveControls()" );
        }
    }
}