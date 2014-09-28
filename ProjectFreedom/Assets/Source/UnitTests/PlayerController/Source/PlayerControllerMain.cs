#region File Header
// File Name:		PlayerControllerMain.cs
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
	/// Player controller main.
	/// </summary>
	public class PlayerControllerMain : Main
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerControllerUnitTest.PlayerControllerMain"/> class.
		/// </summary>
		public PlayerControllerMain()
		{
			theGame = new PlayerControllerGame();
		}
	}
}