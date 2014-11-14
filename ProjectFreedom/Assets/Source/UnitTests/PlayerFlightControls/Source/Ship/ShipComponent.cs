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
		protected String componentName = null;
		
		/// <summary>
		/// The mounting point of the ship component.
		/// </summary>
		protected Vector3 mountPoint = Vector3.zero;
		
		/// <summary>
		/// The center of mass of the ship component.
		/// </summary>
		protected Vector3 centerOfMass = Vector3.zero;
		
		/// <summary>
		/// The mass of the ship component.
		/// </summary>
		protected Single mass = 0.0f;
		
		/// <summary>
		/// The amount of hit points of the ship component.
		/// </summary>
		protected Int32 hitPoints = 0;
		
		/// <summary>
		/// The transform of the owner ship.
		/// </summary>
		protected Transform ship = null;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the name of the ship component.
		/// </summary>
		/// <value>The name of the ship component.</value>
		public String ComponentName
		{
			get
			{
				return componentName;
			}
			
			set
			{
				componentName = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the mounting point of the ship component.
		/// </summary>
		/// <value>The mounting point of the ship component.</value>
		public Vector3 MountPoint
		{
			get
			{
				return mountPoint;
			}
			
			set
			{
				mountPoint = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the center of mass of the ship component.
		/// </summary>
		/// <value>The center of mass of the ship component.</value>
		public Vector3 CenterOfMass
		{
			get
			{
				return centerOfMass;
			}
			
			set
			{
				centerOfMass = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the mass of the ship component.
		/// </summary>
		/// <value>The mass of the ship component.</value>
		public Single Mass
		{
			get
			{
				return mass;
			}
			
			set
			{
				mass = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the hit points of the ship component.
		/// </summary>
		/// <value>The hit points of the ship component.</value>
		public Int32 HitPoints
		{
			get
			{
				return hitPoints;
			}
			
			set
			{
				hitPoints = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the transforms of the ship class.
		/// </summary>
		/// <value>The transforms of the ship.</value>
		public Transform Ship
		{
			get
			{
				return ship;
			}
			
			set
			{
				if( ship == null )
				{
					ship = value;
				}
				else
				{
					throw new InvalidOperationException( "Unable to set the ship transform because it already exists within the ship engine component." );
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
