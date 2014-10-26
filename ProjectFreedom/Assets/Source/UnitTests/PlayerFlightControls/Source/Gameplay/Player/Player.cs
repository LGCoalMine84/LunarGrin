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

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// The local player controller.
	/// </summary>
	public sealed class Player : PlayerController
	{
		#region Private Fields
		
		private SpaceShip playerShip = null;
		
		private Rigidbody playerRigidBody = null;
		
		#endregion
		
		#region Properties
		
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
		
		#region Private Methods
		
		#region Setup
		
		private void Initialization()
		{
			gameObject.AddComponent<Rigidbody>();
		
			playerShip = new SpaceShip( this, rigidbody );	
			
			PushControls( new PlayerShipControls( this ) );
		}
		
		#endregion
		
		#region Unity Components
		
		private void Awake()
		{
			// No more than one rigid body.
		
			Initialization();
		}
		
		private void Update()
		{
			base.Update();
		
			if( playerShip != null )
			{
				playerShip.Update();
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void FixedUpdate()
		{
			if( playerShip != null )
			{
				playerShip.FixedUpdate();
			}
		}
		
		#endregion
		
		#endregion
	}
}
