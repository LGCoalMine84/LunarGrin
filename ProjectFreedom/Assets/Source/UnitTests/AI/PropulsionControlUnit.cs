#region File Header

// File Name:		PropulsionControlUnity.cs
// Author:			John Whitsell
// Creation Date:	2014/11/01
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.UnitTests.PlayerFlightControlsUnitTest;

#endregion

public class PropulsionControlUnit : ShipComponent
{
	public Vector3 velocity = Vector3.zero;
	
	private ThrustCapability thrustCapability = new ThrustCapability();
	
	private Vector3 thrustInput = Vector3.zero;
	
	//owner.Translate( direction * maxSpeed * Time.deltaTime );
	public void SetEngineThrust( Single x, Single y, Single z )
	{
		thrustInput.x = Mathf.Clamp( x, -1f, 1f );
		thrustInput.y = Mathf.Clamp( y, -1f, 1f );
		thrustInput.z = Mathf.Clamp( z, -1f, 1f );
	}
	
	private void Update()
	{
		thrustInput.Normalize();
		
		
	}
}

public class ThrustCapability
{
	//public ThrustRange forward = new ThrustRange( -20f, 20f );
	//public ThrustRange right = new ThrustRange( -20f, 20f );
	//public ThrustRange up = new ThrustRange( -20f, 20f );
}

public class ThrustRange
{
	public Single minimum;
	public Single maximum;
}