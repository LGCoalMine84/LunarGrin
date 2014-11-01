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

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// Base information of a ship engine.
	/// </summary>
	public abstract class ShipEngineComponent : ShipComponent
	{
		#region Protected Fields
		
		/// <summary>
		/// Checks whether the engine is currently thrusting.
		/// </summary>
		protected Boolean thrusting = false;
		
		/// <summary>
		/// The engine mounting point.
		/// </summary>
		protected Vector3 engineMount = 	Vector3.zero;
		
		/// <summary>
		/// The engine thrust point.
		/// </summary>
		protected Vector3 thrustPoint = Vector3.zero;
		
		/// <summary>
		/// The current thrust force.
		/// </summary>
		protected Single thrustForce = 0.0f;
		
		/// <summary>
		/// The maximum thrust force.
		/// </summary>
		protected Single maxThrustForce = 0.0f;
		
		/// <summary>
		/// The charge thrust force.
		/// </summary>
		protected Single chargeThrustForce = 0.0f;
		
		protected Int32 chargeThrustDuration = 0;
		
		protected Int32 chargeThrustCurrentDuration = 0;
		
		protected Int32 chargeThrustCooldown = 0;
		
		protected Int32 chargeThrustCurrentCooldown = 0;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets a value indicating whether the engine component is thrusting.
		/// </summary>
		/// <value><c>True</c> if the engine component is thrusting.</value>
		public Boolean Thrusting
		{
			get
			{
				return thrusting;
			}
		}
		
		/// <summary>
		/// Gets the current thrust force.
		/// </summary>
		/// <value>The current thrust force.</value>
		public Single ThrustForce
		{
			get
			{
				return thrustForce;
			}
		}
		
		/// <summary>
		/// Gets the maximum thrust force.
		/// </summary>
		/// <value>The maximum thrust force.</value>
		public Single MaxThrustForce
		{
			get
			{
				return maxThrustForce;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.ShipEngineComponent"/> class.
		/// </summary>
		protected ShipEngineComponent()
		{
		
		}
		
		#endregion
		
		#region Public Methods
		
		public virtual void ThrustOn()
		{
		
		}
		
		public virtual void ThrustOff()
		{
			
		}
		
		#endregion
	}
}
