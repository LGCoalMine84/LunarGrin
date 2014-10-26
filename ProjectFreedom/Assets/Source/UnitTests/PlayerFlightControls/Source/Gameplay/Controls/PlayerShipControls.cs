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
	public class PlayerShipControls : IControls
	{
		#region Private Fields
		
		/// <summary>
		/// The controller object that owns the controls.
		/// </summary>
		private BaseController owner = null;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerShipControls"/> class.
		/// </summary>
		/// <param name="owner">The controller object that is the owner of the controls..</param>
		/// <exception cref="ArgumentNullException">Unable to create the player ship controls because the controller object owner is invalid.</exception>
		public PlayerShipControls( BaseController ownerController )
		{
			if( ownerController == null )
			{
				throw new ArgumentNullException( "Unable to create the player ship controls because the controller object owner is invalid." );
			}
			
			owner = ownerController;
		}
		
		#endregion
		
		#region Public Methods
		
		#region IControls
		
		/// <summary>
		/// Raises the resume event. This method is called every time the owner of the controls is set.
		/// </summary>
		public void OnResume()
		{
		
		}
		
		/// <summary>
		/// Raises the shutdown event. This method is called once on destruction.
		/// </summary>
		public void OnShutdown()
		{
		
		}
		
		/// <summary>
		/// Raises the startup event. This method is called once on initialization.
		/// </summary>
		public void OnStartup()
		{
		
		}
		
		/// <summary>
		/// Raises the suspend event. This method is called every time the owner of the controls is cleared.
		/// </summary>
		public void OnSuspend()
		{
		
		}
		
		private Single currentRoll = 0.0f;
		
		/// <summary>
		/// Update this instance. Update gets called every frame by the control's owner.
		/// </summary>
		public void Update()
		{
			if ( owner.Pawn != null )
			{
				Player player = (Player)owner;
			
				//  Note:  Can cast Pawn to a specific type to extract specific object data.  If Pawn is not that type, throw an error.
				
				Transform transform = owner.Pawn.transform;
				
				//if ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) )
				if( Input.GetButtonDown( "Fire1" ) ) 
				{
					//transform.Translate( new Vector3( 0f, 0f, Time.deltaTime * 25.0f ) );
					//owner.rigidbody.AddRelativeTorque( owner.transform.up * 10.0f );
					player.Ship.StartThrusters();
				}
				
				if( Input.GetButtonUp( "Fire1" ) ) 
				{
					player.Ship.StopThrusters();	
				}
				
				if ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) )
				{
					//transform.Translate( new Vector3( 0f, 0f, -Time.deltaTime * 25.0f ) );
					//owner.rigidbody.AddRelativeTorque( owner.transform.up * -10.0f );
					//player.Ship.StopThrusters();
					
					//owner.Pawn.transform.Rotate( owner.Pawn.transform.forward, 25.0f );
					
				}
				
				if ( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.LeftArrow ) )
				{
					//transform.Translate( new Vector3( -Time.deltaTime * 25.0f, 0f, 0f ) );
					//owner.rigidbody.AddRelativeTorque( transform.up * -10.0f );
					//owner.rigidbody.AddRelativeTorque( owner.Pawn.transform.up * -10.0f );
					//owner.rigidbody.AddRelativeTorque( owner.transform.forward * -5.0f );
					
					/*currentRoll = Mathf.Lerp( currentRoll, 25.0f, Time.deltaTime ); 
					if( currentRoll <= 25.0f )
					{
						player.transform.Rotate( player.transform.forward, currentRoll );
          			}*/
				}
				else
				{
					/*currentRoll = Mathf.Lerp( currentRoll, 0.0f, Time.deltaTime );
					if( currentRoll >= 0.0f )
					{
						player.transform.Rotate( player.transform.forward, currentRoll );
					}*/
				}
				
				if ( Input.GetKey( KeyCode.D ) || Input.GetKey( KeyCode.RightArrow ) )
				{
					//transform.Translate( new Vector3( Time.deltaTime * 25.0f, 0f, 0f ) );
					//owner.rigidbody.AddRelativeTorque( transform.up * 10.0f );
					//owner.rigidbody.AddRelativeTorque( owner.Pawn.transform.up * 10.0f );
					//owner.rigidbody.AddRelativeTorque( owner.transform.forward * 5.0f );
					
					/*currentRoll = Mathf.Lerp( currentRoll, -25.0f, Time.deltaTime ); 
					if( currentRoll >= -25.0f )
					{
						player.transform.Rotate( player.transform.forward, currentRoll );
          			}*/
       			}
        		else
				{
					/*currentRoll = Mathf.Lerp( currentRoll, 0.0f, Time.deltaTime ); 
					if( currentRoll >= 0.0f )
					{
						player.transform.Rotate( player.transform.forward, currentRoll );
          			}*/
				}
				
				if ( Input.GetKey( KeyCode.X ) )
				{
					//owner.rigidbody.AddRelativeForce( Vector3.zero );
					//owner.rigidbody.AddRelativeTorque( Vector3.zero );
					
				}
			}
			else
			{
				//  TODO:   Throw an error, no pawn exists for the control scheme to update.
			}
		}
		
		#endregion
		
		#endregion
	}
}
