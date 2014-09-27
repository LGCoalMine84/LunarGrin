﻿#region File Header

// File Name:           GameConfig.cs
// Author:              Chris Mraovich
// Creation Date:       8/26/2014   9:54 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using Logging;

using System;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// This is a data centric class that stores the save game data.
	/// </summary>
	public class GameConfig
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( GameConfig ) );
		#endif

		public static class Properties
		{
			public static readonly String Sound = "Sound";
		}

		private SoundSettings soundSettings;
		
		public GameConfig()
		{
			#if LOGGING_TRACE
			Log.Trace( "Begin GameConfig()" );
			Log.Trace( "End GameConfig()" );
			#endif
		}

		/// <summary>
		/// Gets or sets the sound settings.
		/// </summary>
		/// <value>The sound settings.</value>
		public SoundSettings SoundSettings
		{
			get
			{
				return soundSettings;
			}
			
			set
			{
				soundSettings = value;
			}
		}
	}
}