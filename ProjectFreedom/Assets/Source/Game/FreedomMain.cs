#region File Header

// File Name:           FreedomMain.cs
// Author:              Andy Sanchez
// Creation Date:       8/26/2014   9:54 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Core;

#endregion

namespace Freedom
{
	/// <summary>
	/// Main entry point to the freedom game.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.Main"/>
	public sealed class FreedomMain : Main
	{	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.FreedomMain"/> class.
		/// </summary>
		public FreedomMain()
		{
			theGame = new FreedomGame();
		}
		
		#endregion
	}
}
