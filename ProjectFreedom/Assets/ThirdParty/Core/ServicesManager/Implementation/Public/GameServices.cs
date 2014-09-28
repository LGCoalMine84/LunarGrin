#region File Header

// File Name:           GameServices.cs
// Author:              Andy Sanchez
// Creation Date:       9/1/2014   7:25 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

#endregion

namespace LunarGrin.Core
{
	#region Globals

	/// <summary>
	/// Types of game services available in the application.
	/// </summary>
	/// <remarks>
	/// Make sure to add a service type for each service that will be registered within the
	/// game services system.
	/// </remarks>
	public enum ServiceType
	{
		Invalid = 0,
		
		GameConfigManager,
		GameInfo,
		GameStateManager,
	}
	
	#endregion

	/// <summary>
	/// Provides a static interface to game services available throughout the application.
	/// </summary>
	public static class GameServices
	{
		#region Private Fields
	
		/// <summary>
		/// Provides the game services registration and unregistration functionality.
		/// </summary>
		private static GameServicesManager servicesManager = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the game config manager.
		/// </summary>
		/// <value>The game config manager.</value>
		public static IGameConfigManager ConfigManager
		{
			get
			{
				return (IGameConfigManager)servicesManager.GetService( ServiceType.GameConfigManager );
			}
		}
		
		/// <summary>
		/// Gets the game info.
		/// </summary>
		/// <value>The game info.</value>
		public static IGameInfo GameInfo
		{
			get
			{
				return (IGameInfo)servicesManager.GetService( ServiceType.GameInfo );
			}
		}
		
		/// <summary>
		/// Gets the game state manager.
		/// </summary>
		/// <value>The game state manager.</value>
		public static IGameStateManager StateManager
		{
			get
			{
				return (IGameStateManager)servicesManager.GetService( ServiceType.GameStateManager );
      		}
    	}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Static constructor initializes the <see cref="LunarGrin.Core.GameServices"/> class.
		/// </summary>
		static GameServices()
		{
			servicesManager = new GameServicesManager();
			
			RegisterStartupServices();
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Registers a game service to the application.
		/// </summary>
		/// <param name="serviceType">The service type to register.</param>
		/// <param name="service">The game service to register.</param>
		private static void RegisterGameService( ServiceType serviceType, IGameService service )
		{
			try
			{
				servicesManager.AddService( serviceType, service );
			}
			catch( Exception )
			{
				// LOG
			}
		}

		/// <summary>
		/// Unregisters a game service from the application.
		/// </summary>
		/// <param name="serviceType">The game service type of the game service to unregister.</param>
		private static void UnregisterGameService( ServiceType serviceType )
		{
			try
			{
				servicesManager.RemoveService( serviceType );
			}
			catch( Exception )
			{
				// LOG
			}
		}
		
		/// <summary>
		/// Unregisters a game service from the application.
		/// </summary>
		/// <param name="service">The game service to unregister.</param>
		private static void UnregisterGameService( IGameService service )
		{
			try
			{
				servicesManager.RemoveService( service );
			}
			catch( Exception )
			{
				// LOG
			}
		}
		
		/// <summary>
		/// Unregisters all the game services in the application.
		/// </summary>
		private static void UnregisterAllGameServices()
		{
			try
			{
				servicesManager.RemoveAllServices();
			}
			catch( Exception )
			{
				// LOG
			}
		}
		
		/// <summary>
		/// Gets a game service from the application.
		/// </summary>
		/// <returns>The game service.</returns>
		/// <param name="serviceType">The service type bound to the desired service.</param>
		private static IGameService GetGameService( ServiceType serviceType )
		{
			try
			{
				return servicesManager.GetService( serviceType );
			}
			catch( Exception )
			{
				// LOG
			}
			
			return null;
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// Registers game services that are available to the application from startup.
		/// </summary>
		private static void RegisterStartupServices()
		{
			try
			{
				servicesManager.AddService( ServiceType.GameConfigManager, new GameConfigManager() );
				
				servicesManager.AddService( ServiceType.GameInfo, new GameInfo() );
				
				servicesManager.AddService( ServiceType.GameStateManager, new GameStateManager() );
			}
			catch( Exception )
			{
				// LOG
			}
		}
		
		#endregion
	}
}
