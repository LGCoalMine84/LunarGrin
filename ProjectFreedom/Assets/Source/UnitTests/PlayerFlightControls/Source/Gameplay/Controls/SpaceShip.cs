#region File Header

// File Name:           SpaceShip.cs
// Author:              Andy Sanchez
// Creation Date:       10/18/2014   7:33 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

using UnityEngine;

using LunarGrin.Core;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// The player space ship.
	/// </summary>
	public sealed class SpaceShip
	{
		#region Private Fields
		
		/// <summary>
		/// The player controller object that owns the space ship.
		/// </summary>
		private Player player = null;
		
		/// <summary>
		/// The rigid body component of the space ship.
		/// </summary>
		private Rigidbody rigidBody = null;
		
		/// <summary>
		/// The thrusters currently attached to the space ship.
		/// </summary>
		private List<ShipEngineComponent> thrusters = null;
		
		/// <summary>
		/// The world point to which to move the space ship.
		/// </summary>
		private Vector3 worldPoint = Vector3.zero;
		
		/// <summary>
		/// The total mass of the space ship.
		/// </summary>
		private Single totalMass = 0.0f;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the total mass of the space ship.
		/// </summary>
		/// <value>The total mass of the space ship.</value>
		public Single TotalMass
		{
			get
			{
				return totalMass;
			}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Explicit constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.SpaceShip"/> class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Unable to create the space ship because the player controller is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to create the space ship because failed to initialize the internal components of the ship.</exception>
		public SpaceShip( Player controller )
		{
			if( controller == null )
			{
				throw new ArgumentNullException( "Unable to create the space ship because the player controller is invalid." );
			}
			
			player = controller;
			
			// Space ship control scheme.
			player.PushControls( new PlayerShipControls( player ) );
			
			try
			{
				InitializeRigidBody();
				InitializeEngines();
				CalculateCenterOfMass();
			}
			catch( Exception ex )
			{
				throw new InvalidOperationException( "Unable to create the space ship because failed to initialize the internal components of the ship.", ex );
			}
		}
		
		#endregion
		
		#region Public Methods
		
		#region Thrusters
		
		/// <summary>
		/// Starts the forward thrusting of the ship engine components.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to start the forward thrusting of the space ship because no engines component was found.</exception>
		public void StartForwardThrusters()
		{
			if( thrusters == null || thrusters.Count <= 0 )
			{
				throw new InvalidOperationException( "Unable to start the forward thrusting of the space ship because no engines component was found." );
			}
		
			foreach( ShipEngineComponent thruster in thrusters )
			{
				thruster.ForwardThrustOn();
			}
		}
		
		/// <summary>
		/// Starts the reverse thrusting of the ship engine components.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to start the reverse thrusting of the space ship because no engines component was found.</exception>
		public void StartReverseThrusters()
		{
			if( thrusters == null || thrusters.Count <= 0 )
			{
				throw new InvalidOperationException( "Unable to start the reverse thrusting of the space ship because no engines component was found." );
			}
			
			foreach( ShipEngineComponent thruster in thrusters )
			{
				thruster.ReverseThrustOn();
			}
		}
		
		/// <summary>
		/// Toogles the boost thrusting of the ship engine components.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to toggle the forward boost thrusting of the space ship because no engines component was found.</exception>
		public void ToggleForwardBoostThrusters()
		{
			if( thrusters == null || thrusters.Count <= 0 )
			{
				throw new InvalidOperationException( "Unable to toggle the forward boost thrusting of the space ship because no engines component was found." );
			}
			
			foreach( ShipEngineComponent thruster in thrusters )
			{
				if( !thruster.BoostForwardThrusting )
				{
					thruster.ForwardBoostThrustOn();
				}
				else
				{
					thruster.ForwardBoostThrustOff();
				}
			}
		}
		
		/// <summary>
		/// Stops the thrusting of the ship engine components.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to stop the thrusters of the space ship because no engine components was found.</exception>
		public void StopThrusters()
		{
			if( thrusters == null || thrusters.Count <= 0 )
			{
				throw new InvalidOperationException( "Unable to stop the thrusters of the space ship because no engine components was found." );
			}
		
			foreach( ShipEngineComponent thruster in thrusters )
			{
				thruster.ThrustOff();
      		}
    	}
    	
    	#endregion
    	
		#region Update

		/// <summary>
		/// Updates the space ship every frame.
		/// </summary>
    	public void Update()
    	{
			if( player != null && player.PlayerCamera != null && player.PlayerCamera.camera != null )
			{
				worldPoint = player.PlayerCamera.camera.ScreenToWorldPoint( Input.mousePosition );
			}
    	}
    	
    	/// <summary>
    	/// Updates the physics functionality of the space ship.
    	/// </summary>
		public void FixedUpdate()
		{
			Vector3 totalForce = Vector3.zero;
		
			// Update the thrusters.
			if( thrusters != null )
			{
				foreach( ShipEngineComponent thruster in thrusters )
				{
					//thruster.FixedUpdate();
				}
			}
			
			if( rigidBody != null )
			{
				Vector3 rotationVector = Vector3.RotateTowards( player.Pawn.transform.forward, worldPoint, /*3.0f*/1.0f * Time.deltaTime, 0.0f );
				
				Vector3 finalVector = new Vector3( -Input.GetAxis( "Mouse Y" ) * 100.0f * rigidBody.mass, Input.GetAxis( "Mouse X" ) * 100.0f * rigidBody.mass,
				                                   -Input.GetAxis( "Mouse X" ) * 3.0f * rigidBody.mass );                              
				                                   
				finalVector = rotationVector + finalVector;
				
				rigidBody.AddRelativeTorque( finalVector, ForceMode.Force );
				
				// Drag simulation. Let's use Unity's rigid body drag instead of this.
				//Vector3 drag = -rigidBody.velocity * 0.75f * Time.fixedDeltaTime;
				//rigidBody.velocity += drag;
				
				// Angular drag.
				//drag = -rigidBody.angularVelocity * 0.5f * Time.fixedDeltaTime;
				//rigidBody.angularVelocity += drag;	
			}
		}
		
		#endregion
		
		#region Debug
		
		/// <summary>
		/// Used to draw gizmos to the unity game scene.
		/// </summary>
		public void OnDrawGizmos()
		{
			
		}
		
		#endregion
		
		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// Initializes the rigid body component of the space ship.
		/// </summary>
		/// <exception cref="NullReferenceException">Unable to initialize the rigid body component because the player controller is invalid.</exception>
		/// <exception cref="NullReferenceException">Unable to initialize the rigid body component because the pawn object is invalid.</exception>
		private void InitializeRigidBody()
		{
			if( player == null )
			{
				throw new NullReferenceException( "Unable to initialize the rigid body component because the player controller is invalid." );
			}
			
			if( player.Pawn == null )
			{
				throw new NullReferenceException( "Unable to initialize the rigid body component because the pawn object is invalid." );
			}
		
			// The rigid body component of the pawn of the space ship.
			rigidBody = player.Pawn.gameObject.GetComponent<Rigidbody>();
			if( rigidBody == null )
			{
				rigidBody = player.Pawn.gameObject.AddComponent<Rigidbody>();
			}
			
			rigidBody.useGravity = false;
			rigidBody.isKinematic = false;
			rigidBody.drag = 0.75f;
			rigidBody.angularDrag = 0.5f;
			rigidBody.SetDensity( 1.0f );
			rigidBody.mass = 4.0f;
		}
		
		/// <summary>
		/// Initializes the engines component of the space ship.
		/// </summary>
		/// <exception cref="NullReferenceException">Unable to initialize the engine component because the player controller is invalid.</exception>
		/// <exception cref="NullReferenceException">Unable to initialize the engine component because the pawn object is invalid.</exception>
		/// <exception cref="NullReferenceException">Unable to initialize the engine component because the engines component was not found.</exception>
		private void InitializeEngines()
		{
			if( player == null )
			{
				throw new NullReferenceException( "Unable to initialize the engine component because the player controller is invalid." );
			}
			
			if( player.Pawn == null || player.Pawn.gameObject == null )
			{
				throw new NullReferenceException( "Unable to initialize the engine component because the pawn object is invalid." );
			}
		
			ShipEngineComponent[] engineComponents = player.Pawn.gameObject.GetComponentsInChildren<ShipEngineComponent>();
			
			if( engineComponents == null || engineComponents.Length <= 0 )
			{
				throw new NullReferenceException( "Unable to initialize the engine component because the engines component was not found." );
			}
			
			foreach( ShipEngineComponent engineComponent in engineComponents )
			{
				engineComponent.Ship = player.Pawn.transform;
				
				engineComponent.MaxForwardThrustForce = 100000.0f;
				engineComponent.MaxReverseThrustForce = 30000.0f;
				engineComponent.Mass = 800.0f;
				
				engineComponent.MaxForwardThrustForceBoost = 100000.0f;
				engineComponent.BoostThrustDuration = 10.0f;
				engineComponent.BoostThrustCooldownDuration = 3.0f;
				
				rigidBody.mass += engineComponent.Mass;
			}
			
			thrusters = new List<ShipEngineComponent>();	
			thrusters.AddRange( engineComponents );
		}
		
		/// <summary>
		/// Calculates the center of mass of all the parts in the space ship.
		/// </summary>
		/// <exception cref="NullReferenceException">Unable to calculate the center of mass of the space ship because the rigid body is invalid.</exception>
		private void CalculateCenterOfMass()
		{
			if( rigidBody == null )
			{
				throw new NullReferenceException( "Unable to calculate the center of mass of the space ship because the rigid body is invalid." );
			}
		
			Vector3 newCenterOfMass = Vector3.zero;
			
			// Engine components.
			foreach( ShipEngineComponent thruster in thrusters )
			{
				newCenterOfMass += thruster.transform.position * thruster.Mass;
				totalMass += thruster.Mass;
			}
			
			// Space ship component.
			newCenterOfMass += rigidBody.worldCenterOfMass * rigidBody.mass;
			totalMass += rigidBody.mass;
			
			newCenterOfMass /= totalMass;
			
			rigidBody.centerOfMass = newCenterOfMass;
		}
		
		#endregion
	}
}
