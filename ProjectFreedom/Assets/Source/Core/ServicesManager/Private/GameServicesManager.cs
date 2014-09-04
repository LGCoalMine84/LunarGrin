#region File Header

// File Name:           GameServicesManager.cs
// Author:              Andy Sanchez
// Creation Date:       8/31/2014   10:48 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Handles the global game managers available to the application.
	/// </summary>
	public sealed class GameServicesManager
	{
		#region Private Fields
		
		/// <summary>
		/// Holds all the game services in the application.
		/// </summary>
		private Dictionary<ServiceType, IGameService> services = null;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.Core.GameServices"/> class.
		/// </summary>
		public GameServicesManager()
		{
			services = new Dictionary<ServiceType, IGameService>();
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Adds a game service to the application.
		/// </summary>
		/// <param name="serviceType">The service type to add.</param>
		/// <param name="service">The game service to add.</param>
		/// <exception cref="InvalidOperationException">Unable to add a game service.</exception>
		public void AddService( ServiceType type, IGameService service )
		{
			try
			{
				AddGameService( type, service );
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to add a game service.", ex );
			}
		}

		/// <summary>
		/// Removes a game service from the application.
		/// </summary>
		/// <param name="serviceType">The game service type to remove.</param>
		/// <exception cref="InvalidOperationException">Unable to remove the game service.</exception>
		public void RemoveService( ServiceType type )
		{
			try
			{
				RemoveGameService( type );
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to remove the game service.", ex );
			}
		}
		
		/// <summary>
		/// Removes a game service by type from the application.
		/// </summary>
		/// <param name="service">The game service to remove.</param>
		/// <exception cref="InvalidOperationException">Unable to remove a game service.</exception>
		public void RemoveServiceByType( IGameService service )
		{
			try
			{
				RemoveGameServiceByType( service );
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to remove a game service.", ex );
			}
		}
		
		/// <summary>
		/// Removes all the game services from the application.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to remove the game service.</exception>
		public void RemoveAllServices()
		{
			try
			{
				RemoveAllGameServices();
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to remove all game services.", ex );
			}
		}
		
		/// <summary>
		/// Gets a game service from the application.
		/// </summary>
		/// <returns>The game service.</returns>
		/// <param name="serviceType">The service type bound to the desired service.</param>
		/// <exception cref="InvalidOperationException">Unable to get the game service.</exception>
		public IGameService GetService( ServiceType type )
		{
			try
			{
				return GetGameService( type );
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to get the game service.", ex );
			}
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// Adds a game service to the application.
		/// </summary>
		/// <param name="serviceType">The service type to add.</param>
		/// <param name="service">The game service to add.</param>
		/// <exception cref="ArgumentNullException">Unable to add a game service because the service type being added is invalid.</exception>
		/// <exception cref="ArgumentNullException">Unable to add a game service because the service object is invalid.</exception>
		/// <exception cref="NullReferenceException">Unable to add a game service because the services container is invalid.</exception>
		private void AddGameService( ServiceType serviceType, IGameService service )
		{
			if( serviceType == ServiceType.Invalid )
			{
				throw new ArgumentNullException( "Unable to add a game service because the service type being added is invalid." );
			}
			
			if( service == null )
			{
				throw new ArgumentNullException( "Unable to add a game service because the service object is invalid." );
			}
			
			if( services == null )
			{
				throw new NullReferenceException( "Unable to add a game service because the services container is invalid." );
			}
			
			services.Add( serviceType, service );
		}
		
		/// <summary>
		/// Removes a game service from the application.
		/// </summary>
		/// <param name="serviceType">The game service type to remove.</param>
		/// <exception cref="ArgumentNullException">Unable to remove the game service because the service type is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to remove the game service because the service type was not found within the service container.</exception>
		private void RemoveGameService( ServiceType serviceType )
		{
			if( serviceType == ServiceType.Invalid )
			{
				throw new ArgumentNullException( "Unable to remove the game service because the service type is invalid." );
      		}
      		
			if( !services.Remove( serviceType ) )
			{
				throw new InvalidOperationException( "Unable to remove the game service because the '" + serviceType.ToString() + "' service type was not found within the service container." );
			}
		}
		
		/// <summary>
		/// Removes a game servie by type from the application.
		/// </summary>
		/// <param name="service">The game service to remove.</param>
		/// <exception cref="ArgumentNullException">Unable to remove the game service because the service is invalid.</exception>
		/// <exception cref="ArgumentException">Unable to remove the game service because the service type within the service is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to remove the game service because the service type was not found within the service container.</exception>
		private void RemoveGameServiceByType( IGameService service )
		{
			if( service == null )
			{
				throw new ArgumentNullException( "Unable to remove the game service because the service is invalid." );
			}
			
			if( service.GameServiceType == ServiceType.Invalid )
			{
				throw new ArgumentException( "Unable to remove the game service because the service type within the service is invalid." );
			}
			
			if( !services.Remove( service.GameServiceType ) )
			{
				throw new InvalidOperationException( "Unable to remove the game service because the '" + service.GameServiceType.ToString() + "' service type was not found within the service container." );
			}
		}
    
    	/// <summary>
    	/// Removes all game services from the application.
    	/// </summary>
		/// <exception cref="NullReferenceException">Unable to remove all game services because the service container is invalid.</exception>
		private void RemoveAllGameServices()
		{
			if( services == null )
			{
				throw new NullReferenceException( "Unable to remove all game services because the service container is invalid." );
			}
			
			services.Clear();
		}
		
		/// <summary>
		/// Gets a game service from the application.
		/// </summary>
		/// <returns>The game service.</returns>
		/// <param name="serviceType">The service type bound to the desired service.</param>
		/// <exception cref="ArgumentNullException">Unable to get the game service because the service type is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to get the game service because the service type was not found within the service container.</exception>
		private IGameService GetGameService( ServiceType serviceType )
		{
			if( serviceType == ServiceType.Invalid )
			{
				throw new ArgumentNullException( "Unable to get the game service because the service type is invalid." );
			}
			
			IGameService service = null;
			if( !services.TryGetValue( serviceType, out service ) )
			{
				throw new InvalidOperationException( "Unable to get the game service because the '" + serviceType.ToString() + "' service type was not found within the service container." );
			}
			
			return service;
		}
		
		#endregion
	}
}
