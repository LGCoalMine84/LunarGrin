#region File Header

// File Name:           SpaceShipThruster.cs
// Author:              Andy Sanchez
// Creation Date:       10/18/2014   6:46 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections;

using UnityEngine;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class SpaceShipThruster
	{
		#region Private Fields
		
		private Vector3 thrusterMount = Vector3.zero;
		private Vector3 thrusterPoint = Vector3.zero;
		
		/// <summary>
		/// 
		/// </summary>
		private Rigidbody rigidBody = null;
		
		/// <summary>
		/// 
		/// </summary>
		private Single thrusterForce = 100000.0f;
		
		private Single thrusterTurbo = 0.0f;
		
		private Single turboDuration = 5000.0f; // In milliseconds.
		private Single turboCurrentTime = 0.0f;
		
		private Single turboRecharge = 2000.0f;
		private Single turboCurrentRecharge = 0.0f;
		
		
		private Single thrusterMass = 0.0f;
		
		
		
		/// <summary>
		/// Gets whether the thruster is turned on.
		/// </summary>
		private Boolean isOn = false;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the mass of the thruster.
		/// </summary>
		/// <value>The mass of the thruster.</value>
		public Single ThrusterMass
		{
			get
			{
				return thrusterMass;
			}
			
			set
			{
				thrusterMass = value;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.SpaceShipThruster"/> class.
		/// </summary>
		public SpaceShipThruster( Vector3 pointOfThrust, Rigidbody shipRigidBody )
		{
			thrusterPoint = pointOfThrust;
			thrusterPoint.Normalize();
			
			// we need to be able to set the mass and the max force.
			// Could also have a turbo-mode. This would need 2 timers. First timer would be the duration of the turbo; second timer would be how long
			// before we can do another turbo.
			// do we need a particle system here?
			
			
			rigidBody = shipRigidBody;
		}
		
		#endregion

		#region Public Methods
		
		public void ThrustOn()
		{
			isOn = true;
		}
		
		public void ThrustOff()
		{
			isOn = false;
		}
		
		public void Update(  )
		{
			
		}
		
		public void FixedUpdate( )
		{
			if( isOn )
			{
				if( rigidBody != null )
				{
					//rigidBody.AddRelativeForce( Vector3.forward * thrusterForce );
					rigidBody.AddRelativeForce( thrusterPoint * thrusterForce, ForceMode.Force );
					//rigidBody.AddForceAtPosition( rigidBody.gameObject.transform.up * thrusterForce, rigidBody.gameObject.transform.localPosition, ForceMode.Force );
				}
			}
			else
			{
				//rigidBody.AddRelativeForce( Vector3.zero );
				//rigidBody.AddRelativeForce( Vector3.zero, ForceMode.Force );
			}
		}
		
		#endregion
	}
}
