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
	public class PlayerShipControls : IControls
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
		public PlayerShipControls( BaseController ownerController )
		{
			if( ownerController == null )
			{
				throw new ArgumentNullException( "Unable to create the player ship controls because the controller object owner is invalid." );
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
					owner.Ship.StartThrusters();
				}
				
				if( Input.GetButtonUp( "Fire1" ) ) 
				{
					owner.Ship.StopThrusters();	
				}
				
				if ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) )
				{
					owner.Ship.StartThrusters();
				}
				
				if ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) )
				{
					owner.Ship.StopThrusters();
       			}
			}
		}
		
		#endregion
		
		#endregion
	}
}
