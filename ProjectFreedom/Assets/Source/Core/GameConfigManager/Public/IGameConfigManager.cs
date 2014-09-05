#region File Header
// File Name:		IGameConfigManager.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using System;
#endregion

public interface IGameConfigManager
{
	GameSoundConfig Sound
	{
		get;
	}
	
	GameVideoConfig Video
	{
		get;
	}
}