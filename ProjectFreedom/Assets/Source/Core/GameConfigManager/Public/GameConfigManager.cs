#region File Header
// File Name:		GameConfigManager.cs
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
	/// The Game config manager is the central access point for the game's core configuration.
	/// </summary>
	public class GameConfigManager : IGameConfigManager, IGameService
	{
		#region Constants
		
		/// <summary>
		/// The type of game service.
		/// </summary>
		private const ServiceType TypeOfGameService = ServiceType.GameConfigManager;
		
		#endregion
		
		/// <summary>
		/// The game's sound configuration.
		/// </summary>
		private GameSoundConfig sound = new GameSoundConfig();
		
		/// <summary>
		/// The game's video configuration.
		/// </summary>
		private GameVideoConfig video = new GameVideoConfig();
		
		/// <summary>
		/// Gets the game's sound configuration.
		/// </summary>
		/// <value>The sound configuration.</value>
		public GameSoundConfig Sound
		{
			get
			{
				return sound;
			}
		}
		
		/// <summary>
		/// Gets the game's video configuration.
		/// </summary>
		/// <value>The video configuration.</value>
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
}