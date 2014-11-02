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
	
	//	This is relative to the ship's forward.
	public Vector3 acceleration = new Vector3( 1f, 1f, 1f );
}