#region File Header
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
using LunarGrin.Core;
#endregion

public class GameConfigManager : IGameConfigManager, IGameService
{
	#region Constants
	
	/// <summary>
	/// The type of game service.
	/// </summary>
	private const ServiceType TypeOfGameService = ServiceType.GameConfigManager;
	
	#endregion
	
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
	
	/// <summary>
	/// Gets the type of the game service.
	/// </summary>
	/// <value>The type of the game service.</value>
	public ServiceType GameServiceType
	{
		get
		{
			return TypeOfGameService;
		}
	}
}