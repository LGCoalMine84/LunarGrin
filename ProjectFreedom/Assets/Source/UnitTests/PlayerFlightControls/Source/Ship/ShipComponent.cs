#region File Header

// File Name:           ShipComponent.cs
// Author:              Andy Sanchez
// Creation Date:       10/27/2014   9:33 PM
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
	/// Base information for a ship component.
	/// </summary>
	public abstract class ShipComponent : MonoBehaviour
	{
		#region Protected Fields
		
		/// <summary>
		/// The name of the ship component.
		/// </summary>
		protected String name = null;
		
		/// <summary>
		/// The mass of the ship component.
		/// </summary>
		protected Single mass = 0.0f;
		
		/// <summary>
		/// The amount of hit points of the ship component.
		/// </summary>
		protected Int32 hitPoints = 0;
		
		/// <summary>
		/// The ship that owns the ship component.
		/// </summary>
		protected Transform owner = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the name of the ship component.
		/// </summary>
		/// <value>The name of the ship component.</value>
		public String Name
		{
			get
			{
				return name;
			}
		}
		
		/// <summary>
		/// Gets the mass of the ship component.
		/// </summary>
		/// <value>The mass of the ship component.</value>
		public Single Mass
		{
			get
			{
				return mass;
			}
		}
		
		/// <summary>
		/// Gets the hit points of the ship component.
		/// </summary>
		/// <value>The hit points of the ship component.</value>
		public Int32 HitPoints
		{
			get
			{
				return hitPoints;
			}
		}
		
		/// <summary>
		/// Gets or sets the ship.
		/// </summary>
		/// <value>The ship.</value>
		public Transform Owner
		{
			get
			{
				return owner;
			}
			set
			{
				if ( owner == null )
				{
					owner = value;
				}
				else
				{
					throw new InvalidOperationException( "ShipComponent - Ship cannot be modified after being initialized." );
				}
			}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.ShipComponent"/> class.
		/// </summary>
		protected ShipComponent()
		{
			
		}
		
		#endregion
	}
}
