#region File Header

// File Name:		IGameConfigManager.cs
// Author:			John Whitsell
// Creation Date:	2014/09/06
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Interface to the <see cref="LunarGrin.Core.MainMenuState"/>.
	/// </summary>
	public interface IGameConfigManager
	{
		/// <summary>
		/// Gets the sound config.
		/// </summary>
		/// <value>The sound config.</value>
		GameSoundConfig Sound
		{
			get;
		}
		
		/// <summary>
		/// Gets the video config.
		/// </summary>
		/// <value>The video config.</value>
		GameVideoConfig Video
		{
			get;
		}
	}
}