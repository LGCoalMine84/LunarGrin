#region File Header
// File Name:		PlayerControllerMain.cs
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
	public class PlayerControllerMain : Main
	{
		public PlayerControllerMain()
		{
			theGame = new PlayerControllerGame();
		}
	}
}