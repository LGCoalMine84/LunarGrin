﻿#region File Header
// File Name:		GameConfigManager.cs
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

public class GameConfigManager : IGameConfigManager
{
	private GameSoundConfig sound = new GameSoundConfig();
	
	private GameVideoConfig video = new GameVideoConfig();
	
	public GameSoundConfig Sound
	{
		get
		{
			return sound;
		}
	}
	
	public GameVideoConfig Video
	{
		get
		{
			return video;
		}
	}
}