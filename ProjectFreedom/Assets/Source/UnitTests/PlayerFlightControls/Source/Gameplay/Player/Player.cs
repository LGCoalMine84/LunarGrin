#region File Header

// File Name:           Player.cs
// Author:              Andy Sanchez
// Creation Date:       10/12/2014   10:07 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Core;
using LunarGrin.Utilities;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// The local player controller.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.PlayerController"/>
	public sealed class Player : PlayerController
	{
		#region Private Fields
		
		/// <summary>
		/// The logger.
		/// </summary>
		private static readonly ILogger Log = LogFactory.CreateLogger( typeof( Player ) );
		
		/// <summary>
		/// The player ship.
		/// </summary>
		private SpaceShip playerShip = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the player ship.
		/// </summary>
		/// <value>The player ship.</value>
		public SpaceShip Ship
		{
			get
			{
				return playerShip;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.Player"/> class.
		/// </summary>
		public Player()
		{
			
		}
		
		#endregion
		
		#region Public Methods
		
		#region Base Controller
		
		/// <summary>
		/// Possesses the specified pawn or model object.
		/// </summary>
		/// <param name="pawn">The pawn or model object being possessed by the player.</param>
		public override void Possess( Pawn pawn )
		{
			try
			{
				base.Possess( pawn );
				
				// Handles the internal implementation of the player space ship.
				playerShip = new SpaceShip( this );	
			}
			catch( Exception ex )
			{
				Log.Error( ex.Message );
			}
		}
		
		#endregion
		
		#endregion
		
		#region Private Methods
		
		#region Unity Components
		
		/// <summary>
		/// Called by Unity when this object has been created.
		/// </summary>
		private void Awake()
		{

		}
		
		/// <summary>
		/// Called by Unity when this object has been started.
		/// </summary>
		private void Start()
		{
		
		}
		
		/// <summary>
		/// Called by Unity to update this object every frame.
		/// </summary>
		private void Update()
		{
			base.Update();
		
			if( playerShip != null )
			{
				playerShip.Update();
			}
		}
		
		/// <summary>
		/// Called by Unity to update the physics functionality of this object.
		/// </summary>
		private void FixedUpdate()
		{
			if( playerShip != null )
			{
				playerShip.FixedUpdate();
			}
		}
		
		#endregion
		
		#region Debug
		
		/// <summary>
		/// Raised when gizmos are drawn in the scene view in Unity.
		/// </summary>
		private void OnDrawGizmos()
		{
			if( playerShip != null )
			{
				playerShip.OnDrawGizmos();
			}
		}
		
		#endregion
		
		#endregion
	}
}
