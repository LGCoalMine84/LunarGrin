#region File Header
// File Name:		PlayerControllerGame.cs
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

using LunarGrin.Core;
#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	/// <summary>
	/// The Player controller Unit Test.
	/// </summary>
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