#region File Header
// File Name:		GameConfig.cs
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
#endregion

public class GameConfig
{
	private GameSoundConfig soundConfig = new GameSoundConfig();
	
	private GameVideoConfig videoConfig = new GameVideoConfig();
	
	public GameSoundConfig SoundConfig
	{
		get
		{
			return soundConfig;
		}
	}
	
	public GameVideoConfig VideoConfig
	{
		get
		{
			return videoConfig;
		}
	}
}