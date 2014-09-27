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
	public sealed class FreedomMain : Main
	{	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Main"/> class.
		/// </summary>
		public FreedomMain()
		{
			theGame = new FreedomGame();
		}
		
		#endregion
	
		#region Private Fields
		
		#region Unity Components
		
		/// <summary>
		/// Called after all the scene components have been created.
		/// </summary>
		/*private void Start()
		{
			theGame.Initialize();
		}

		/// <summary>
		/// Updates the main logic of the game.
		/// </summary>
		private void Update()
		{
			theGame.Update( Time.deltaTime );
		}
		
		/// <summary>
		/// Called when the game has been destroyed.
		/// </summary>
		private void OnDestroy()
		{
			theGame.Destroy();
		}*/
		
		#endregion
		
		#endregion
	}
}
