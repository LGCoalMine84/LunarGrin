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
		
		private Rigidbody rigidBody = null;
		
		/// <summary>
		/// The thrusters currently attached to the space ship.
		/// </summary>
		private List<SpaceShipThruster> thrusters = null;
		
		/// <summary>
		/// The total space ship mass.
		/// </summary>
		private Single totalMass = 0.0f;
		
		private BaseController owner = null;
		
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
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.SpaceShip"/> class.
		/// </summary>
		public SpaceShip( BaseController controller, Rigidbody playerRigidBody )
		{
			rigidBody = playerRigidBody;
			int y = 0;
			rigidBody.useGravity = false;
			rigidBody.drag = 0.75f;
			rigidBody.angularDrag = 0.5f;
			rigidBody.mass = 500.0f;
			
			GameObject thrusterPoint = GameObject.Find( "ThrusterPoint" );
			
			thrusters = new List<SpaceShipThruster>();	
			thrusters.Add( new SpaceShipThruster( thrusterPoint.transform.forward, rigidBody ) );
			
			owner = controller;
		}
		
		#endregion
		
		#region Public Methods
		
		public void StartThrusters()
		{
			foreach( SpaceShipThruster thruster in thrusters )
			{
				thruster.ThrustOn();
			}
		}
		
		public void StopThrusters()
		{
			foreach( SpaceShipThruster thruster in thrusters )
			{
				thruster.ThrustOff();
      		}
    	}
    	
		private Ray worldSpaceRay;
    	public void Update()
    	{
    		RaycastHit hitInfo;
    	
    		worldSpaceRay = Camera.main.ScreenPointToRay( Input.mousePosition );
			if( Physics.Raycast( worldSpaceRay, out hitInfo, 100000, 1 << 2 ) )
    		{
				Debug.Log( "Hit something...hahahahahahahaha!" );
    			Debug.DrawLine( worldSpaceRay.origin, hitInfo.point );
    		}
    		else
    		{
				Debug.DrawRay( worldSpaceRay.origin, worldSpaceRay.direction * 10, Color.red, 0, false );
    		}
    	}
    	
		public void FixedUpdate()
		{
			if( thrusters != null )
			{
				foreach( SpaceShipThruster thruster in thrusters )
				{
					thruster.FixedUpdate();
				}
			}
			
			if( rigidBody != null )
			{
				Vector3 endPoint = worldSpaceRay.GetPoint( 10000 );
				endPoint.Normalize();
				
				Vector3 rotationVector = Vector3.RotateTowards( owner.transform.forward, endPoint, 1.0f * Time.deltaTime, 0.0f );
			
				//rigidBody.AddRelativeTorque( new Vector3( Input.GetAxis( "Vertical" ) * 10 * rigidBody.mass,
				//                                          Input.GetAxis( "Horizontal" ) * 3 * rigidBody.mass,
				//										  -Input.GetAxis( "Horizontal" ) * 10 * rigidBody.mass ), ForceMode.Force );
				//rigidBody.AddRelativeTorque( new Vector3( 0, Input.GetAxis( "Mouse X" ) * 30 * rigidBody.mass, 0 ), ForceMode.Force );
				//rigidBody.AddRelativeTorque( new Vector3( -Input.GetAxis( "Mouse Y" ) * 30 * rigidBody.mass, 0, 0 ), ForceMode.Force );
				//rigidBody.AddRelativeTorque( new Vector3( 0, 0, Input.GetAxis( "Mouse X" ) * 30 * rigidBody.mass ), ForceMode.Force );
				
				Vector3 finalVector = new Vector3( -Input.GetAxis( "Mouse Y" ) * 100 * rigidBody.mass, Input.GetAxis( "Mouse X" ) * 100 * rigidBody.mass,
				                                   -Input.GetAxis( "Mouse X" ) * rigidBody.mass * 30 * Time.deltaTime );
				finalVector = rotationVector + finalVector;

				//finalVector.z = 0.0f;
				rigidBody.AddRelativeTorque( finalVector, ForceMode.Force );
				//rigidBody.AddRelativeTorque( new Vector3( 0, Input.GetAxis( "Mouse X" ) * rotationVector.x * 100 * rigidBody.mass, 0 ), ForceMode.Force );
				//rigidBody.AddRelativeTorque( new Vector3( -Input.GetAxis( "Mouse Y" ) * rotationVector.y * 30 * rigidBody.mass, 0, 0 ), ForceMode.Force );
				
				//rotationVector.Normalize();
				//owner.transform.localRotation = Quaternion.LookRotation( rotationVector, owner.transform.up );
			}
		}
		
		#endregion
	}
}
