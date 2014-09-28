#region File Header
// File Name:		PlayerControllerGame.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System;

using LunarGrin.Core;
#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	public class PlayerControllerGame : Game
	{
		/// <summary>
		/// Initializes the game instance.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			
			GameServices.StateManager.PushState( new PlayerControllerLoadingState( "PlayerControllerLoadingState" ) );
		}
	}
}