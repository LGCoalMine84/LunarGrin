#region File Header

// File Name:           ShipEngineComponent.cs
// Author:              Andy Sanchez
// Creation Date:       10/27/2014   9:40 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Utilities;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// Base information of a ship engine.
	/// </summary>
	public abstract class ShipEngineComponent : ShipComponent
	{
		#region Constants
		
		/// <summary>
		/// The states available to the engine component.
		/// </summary>
		[Flags]
		protected enum EngineState
		{
			Invalid = 0x00,
			
			Ready = ( 1 << 0 ),
			ForwardThrust = ( 1 << 1 ),
			ReverseThrust = ( 1 << 2 ),
			BoostReady = ( 1 << 3 ),
			BoostForwardThrust = ( 1 << 4 ),
			BoostRecharging = ( 1 << 5 ),
			BoostCooling = ( 1 << 6 ),
		}
		
		#endregion
	
		#region Protected Fields

		/// <summary>
		/// The forward thrust direction of the engine component.
		/// </summary>
		protected Vector3 thrustForwardDir = Vector3.zero;
		
		/// <summary>
		/// The reverse thrust direction of the engine component.
		/// </summary>
		protected Vector3 thrustReverseDir = Vector3.zero;
		
		/// <summary>
		/// The maximum forward thrust force of the engine component.
		/// </summary>
		protected Single maxForwardThrustForce = 0.0f;
		
		/// <summary>
		/// The maximum reverse thrust force of the engine component.
		/// </summary>
		protected Single maxReverseThrustForce = 0.0f;
		
		/// <summary>
		/// The maximum forward thrust force boost of the engine component.
		/// </summary>
		protected Single maxForwardThrustForceBoost = 0.0f;

		/// <summary>
		/// The total duration of the forward boost thrust.
		/// </summary>
		protected Single boostThrustDuration = 0.0f;

		/// <summary>
		/// The total duration of the forward boost thrust cooldown.
		/// </summary>
		protected Single boostThrustCooldownDuration = 0.0f;
		
		/// <summary>
		/// The state of the engine component.
		/// </summary>
		protected EngineState engineState = EngineState.Invalid;

		#endregion
		
		#region Private Fields
		
		/// <summary>
		/// The logger.
		/// </summary>
		private static readonly ILogger Log = LogFactory.CreateLogger( typeof( ShipEngineComponent ) );
		
		/// <summary>
		/// The velocity value from the last physics update.
		/// </summary>
		private Vector3 lastVelocity = Vector3.zero;
		
		/// <summary>
		/// The current thrust force of the engine component.
		/// </summary>
		private Single currentThrustForce = 0.0f;
		
		/// <summary>
		/// The duration of the current forward boost thrust.
		/// </summary>
		private Single currentBoostThrustDuration = 0.0f;
		
		/// <summary>
		/// The duration of the current forward boost thrust cooldown.
		/// </summary>
		private Single currentBoostThrustCooldown = 0.0f;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the thrust forward direction.
		/// </summary>
		/// <value>The thrust forward direction.</value>
		public Vector3 ThrustForwardDir
		{
			get
			{
				return thrustForwardDir;
			}
			
			set
			{
				thrustForwardDir = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the thrust reverse direction.
		/// </summary>
		/// <value>The thrust reverse direction.</value>
		public Vector3 ThrustReverseDir
		{
			get
			{
				return thrustReverseDir;
			}
			
			set
			{
				thrustReverseDir = value;
			}
		}

		/// <summary>
		/// Gets the current thrust force.
		/// </summary>
		/// <value>The current thrust force.</value>
		public Single CurrentThrustForce
		{
			get
			{
				return currentThrustForce;
			}
		}
		
		/// <summary>
		/// Gets or sets the maximum forward thrust force.
		/// </summary>
		/// <value>The maximum forward thrust force.</value>
		public Single MaxForwardThrustForce
		{
			get
			{
				return maxForwardThrustForce;
			}
			
			set
			{
				maxForwardThrustForce = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the maximum reverse thrust force.
		/// </summary>
		/// <value>The maximum reverse thrust force.</value>
		public Single MaxReverseThrustForce
		{
			get
			{
				return maxReverseThrustForce;
			}
			
			set
			{
				maxReverseThrustForce = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the maximum forward thrust force boost.
		/// </summary>
		///<value>The maximum forward thrust force boost.</value>
		public Single MaxForwardThrustForceBoost
		{
			get
			{
				return maxForwardThrustForceBoost;
			}
			
			set
			{
				maxForwardThrustForceBoost = value;
				currentBoostThrustDuration = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the total duration of the forward boost thrust.
		/// </summary>
		///<value>The total duration of the forward boost thrust.</value>
		public Single BoostThrustDuration
		{
			get
			{
				return boostThrustDuration;
			}
			
			set
			{
				boostThrustDuration = value;
				currentBoostThrustDuration = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the total duration of the forward boost thrust cooldown.
		/// </summary>
		/// <value>The total duration of the forward boost thrust cooldown.</value>
		public Single BoostThrustCooldownDuration
		{
			get
			{
				return boostThrustCooldownDuration;
			}
			
			set
			{
				boostThrustCooldownDuration = value;
				currentBoostThrustCooldown = value;
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the engine component is thrusting forward.
		/// </summary>
		/// <value><c>True</c> if the engine component is thrusting forward.</value>
		public Boolean ForwardThrusting
		{
			get
			{
				return ( engineState & EngineState.ForwardThrust ) != 0;
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the engine component is thrusting in reverse.
		/// </summary>
		/// <value><c>True</c> if the engine component is thrusting in reverse.</value>
		public Boolean ReverseThrusting
		{
			get
			{
				return ( engineState & EngineState.ReverseThrust ) != 0;
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the engine component is boosting forward.
		/// </summary>
		/// <value><c>True</c> if the engine component is boosting forward.</value>
		public Boolean BoostForwardThrusting
		{
			get
			{
				return ( engineState & EngineState.BoostForwardThrust ) != 0;
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the engine component is thrusting.
		/// </summary>
		/// <value><c>True</c> if the engine component is thrusting.</value>
		public Boolean IsThrusting
		{
			get
			{
				return ( ForwardThrusting || ReverseThrusting || BoostForwardThrusting );
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.ShipEngineComponent"/> class.
		/// </summary>
		protected ShipEngineComponent()
		{
			engineState |= ( EngineState.Ready | EngineState.BoostReady );
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Turns on the forward thrust in the engine component.
		/// </summary>
		public virtual void ForwardThrustOn()
		{
			engineState |= EngineState.ForwardThrust;
			engineState &= ~EngineState.ReverseThrust;
		}
		
		/// <summary>
		/// Turns on the reverse thrust in the engine component.
		/// </summary>
		public virtual void ReverseThrustOn()
		{
			engineState &= ~EngineState.ForwardThrust;
			engineState |= EngineState.ReverseThrust;
		}
		
		/// <summary>
		/// Turns on the forward boost thrust in the engine component.
		/// </summary>
		public virtual void ForwardBoostThrustOn()
		{
			if( ( engineState & EngineState.BoostReady ) != 0 )
			{
				engineState |= EngineState.BoostForwardThrust;
			}
		}
		
		/// <summary>
		/// Turns off the forward boost thrust in the engine component.
		/// </summary>
		public virtual void ForwardBoostThrustOff()
		{
			engineState &= ~EngineState.BoostForwardThrust;
		}
		
		/// <summary>
		/// Turns off the thrust in the engine component.
		/// </summary>
		public virtual void ThrustOff()
		{
			engineState &= ~( EngineState.ForwardThrust | EngineState.ReverseThrust | EngineState.BoostForwardThrust );
		}

		#endregion
		
		#region Protected Methods
		
		#region Helpers
		
		/// <summary>
		/// Sets the thruster force vectors.
		/// </summary>
		/// <exception cref="InvalidOperationException">Unable to set the thruster force vectors because 'ThrusterForwardPoint' and 'ThrusterReversePoint' game objects are not children of the engine component.</exception>
		/// <exception cref="InvalidOperationException">Unable to set the forward thruster force vector because the 'ThrusterForwardPoint' game object is not a child of the engine component.</exception>
		/// <exception cref="InvalidOperationException">Unable to set the reverse thruster force vector because the 'ThrusterReversePoint' game object is not a child of the engine component.</exception>
		protected void SetThrusterForceVectors()
		{
			if( transform.childCount == 0 )
			{
				throw new InvalidOperationException( "Unable to set the thruster force vectors because 'ThrusterForwardPoint' and 'ThrusterReversePoint' game objects are not children of the engine component." );
			}

			foreach( Transform child in transform )
			{
				if( child.name.Equals( "ThrusterForwardPoint", StringComparison.OrdinalIgnoreCase ) )
				{
					thrustForwardDir = child.transform.forward;
				}
				else if( child.name.Equals( "ThrusterReversePoint", StringComparison.OrdinalIgnoreCase ) )
				{
					thrustReverseDir = child.transform.forward;
				}
			}
			
			if( thrustForwardDir == Vector3.zero )
			{
				throw new InvalidOperationException( "Unable to set the forward thruster force vector because the 'ThrusterForwardPoint' game object is not a child of the engine component." );
			}
			
			if( thrustReverseDir == Vector3.zero )
			{
				throw new InvalidOperationException( "Unable to set the reverse thruster force vector because the 'ThrusterReversePoint' game object is not a child of the engine component." );
			}
		}
		
		protected void SetCenterOfMass()
		{
			// TODO: Does this needs to be a transform instead of a vector.
			centerOfMass = transform.localPosition;
		}
		
		/// <summary>
		/// Calculates the current thrust force of the engine component.
		/// </summary>
		protected Vector3 CalculateCurrentForce()
		{
			Vector3 curForceVec = Vector3.zero;
			
			if( Ship != null && Ship.rigidbody != null )
			{
				Vector3 curAccel = ( Ship.rigidbody.velocity - lastVelocity ) / Time.fixedDeltaTime;
				lastVelocity = Ship.rigidbody.velocity;

				curForceVec = Ship.rigidbody.mass * curAccel;
			}
			
			return curForceVec;
		}
		
		protected Vector3 GetMaxForwardForce()
		{
			return thrustForwardDir * maxForwardThrustForce;
		}
		
		#endregion
		
		#region Unity Components
		
		/// <summary>
		/// Called by Unity when this object has been created.
		/// </summary>
		protected virtual void Awake()
		{
			
		}
		
		/// <summary>
		/// Called by Unity when this object has been started.
		/// </summary>
		protected virtual void Start()
		{
			try
			{
				SetThrusterForceVectors();
				SetCenterOfMass();
			}
			catch( Exception ex )
			{
				Log.Error( ex.Message );
			}
		}
		
		/// <summary>
		/// Called by Unity to update this object every frame.
		/// </summary>
		protected virtual void Update()
		{
			// Update the boost thrust timers.
			if( ( engineState & EngineState.BoostReady ) != 0 )
			{
				if( ( engineState & EngineState.BoostForwardThrust ) != 0 )
				{				
					engineState &= ~EngineState.BoostRecharging;
					
					currentBoostThrustDuration -= Time.deltaTime;
					
					if( currentBoostThrustDuration <= 0.0f )
					{
						engineState &= ~( EngineState.BoostReady | EngineState.BoostForwardThrust );
						engineState |= EngineState.BoostCooling;
					}
				}
				else
				{
					if( currentBoostThrustDuration < boostThrustDuration )
					{
						engineState |= EngineState.BoostRecharging;
					}
				}
			}
			else
			{
				if( ( engineState & EngineState.BoostCooling ) != 0 )
				{
					currentBoostThrustCooldown -= Time.deltaTime;

					if( currentBoostThrustCooldown <= 0 )
					{
						currentBoostThrustCooldown = boostThrustCooldownDuration;
	
						engineState |= EngineState.BoostRecharging;
					}
				}
			}
			
			if( ( engineState & EngineState.BoostRecharging ) != 0 )
			{
				currentBoostThrustDuration += Time.deltaTime;

				if( currentBoostThrustDuration >= boostThrustDuration )
				{
					currentBoostThrustDuration = boostThrustDuration;
					
					engineState &= ~EngineState.BoostRecharging;
					engineState |= EngineState.BoostReady;
				}
			}
		}
		
		/// <summary>
		/// Called by Unity to update the physics functionality of this object.
		/// </summary>
		protected virtual void FixedUpdate()
		{
			if( Ship != null && Ship.rigidbody != null )
			{
				if( ForwardThrusting )
				{
					if( BoostForwardThrusting )
					{
						Ship.rigidbody.AddRelativeForce( thrustForwardDir * ( maxForwardThrustForce + maxForwardThrustForceBoost ) );
					}
					else
					{
						Ship.rigidbody.AddRelativeForce( thrustForwardDir * maxForwardThrustForce );
					}
				}
				else if( ReverseThrusting )
				{
					Ship.rigidbody.AddRelativeForce( thrustReverseDir * maxReverseThrustForce );
				}
			}
		}
		
		#endregion

		#endregion
	}
}
