#region File Header

// File Name:           PlayerShipControls.cs
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
	/// Player ship controls.
	/// </summary>
	/// <seealso cref="LunarGrin.Core.IControls"/>
	public sealed class PlayerShipControls : IControls
	{
		#region Private Fields
		
		/// <summary>
		/// The player controller object that owns the ship controls.
		/// </summary>
		private Player owner = null;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerShipControls"/> class.
		/// </summary>
		/// <param name="owner">The controller object that is the owner of the controls.</param>
		/// <exception cref="ArgumentNullException">Unable to create the player ship controls because the controller object owner is invalid.</exception>
		/// <exception cref="ArgumentException">Unable to create the player ship controls because the controller object owner is not of type Player.</exception>
		public PlayerShipControls( BaseController ownerController )
		{
			if( ownerController == null )
			{
				throw new ArgumentNullException( "Unable to create the player ship controls because the controller object owner is invalid." );
			}
			
			if( !( ownerController is Player ) )
			{
				throw new ArgumentException( "Unable to create the player ship controls because the controller object owner is not of type Player." );
			}
			
			owner = (Player)ownerController;
		}
		
		#endregion
		
		#region Public Methods
		
		#region IControls
		
		/// <summary>
		/// Raised when the control has been pushed to the controls stack.
		/// </summary>
		public void OnStartup()
		{
		
		}
		
		/// <summary>
		/// Raised when the control is popped off the controls stack.
		/// </summary>
		public void OnShutdown()
		{
			
		}
		
		/// <summary>
		/// Raised when the control has resumed as the top control in the controls stack.
		/// </summary>
		public void OnResume()
		{
			
		}
		
		/// <summary>
		/// Raised when the control has been suspended by another control being pushed to the controls stack.
		/// </summary>
		public void OnSuspend()
		{
		
		}

		/// <summary>
		/// Updates the control.
		/// </summary>
		public void Update()
		{
			if ( owner != null && owner.Ship != null )
			{
				if( Input.GetButtonDown( "Fire1" ) ) 
				{
					// TODO: this should be primary weapon.
					owner.Ship.StartForwardThrusters();
				}
				
				if( Input.GetButtonUp( "Fire1" ) ) 
				{
					owner.Ship.StopThrusters();	
				}
				
				if( Input.GetButtonDown( "Fire2" ) ) 
				{
					// TODO: this should be secondary weapon.
					owner.Ship.StartReverseThrusters();
				}
				
				if( Input.GetButtonUp( "Fire2" ) ) 
				{
					owner.Ship.StopThrusters();	
				}
				
				if( Input.GetKeyDown( KeyCode.B ) ) 
				{
					owner.Ship.ToggleForwardBoostThrusters();
				}
				
				if ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) )
				{
					owner.Ship.StartForwardThrusters();
				}
				
				if ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) )
				{
					// TODO: This should be back thrusters.
					owner.Ship.StartReverseThrusters();
       			}
       			
       			// TODO: Tab for space vs. earth physics. make the drag and angular drag to zero or very close to zero for space physics.
       			// Q and E for strafing.
       			// A and D for rolling.
       			// Z for stopping the ship to a halt.
       			// C for aliging the ship to the world's plane.
			}
		}
		
		#endregion
		
		#endregion
	}
}
