#region File Header

// File Name:		Dragonfly.cs
// Author:			John Whitsell
// Creation Date:	2014/10/26
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

using UnityEngine;

using LunarGrin.UnitTests.PlayerFlightControlsUnitTest;

#endregion

[ExecuteInEditMode]
public class Dragonfly : MonoBehaviour
{
	private NavComputer navComputer = null;
	
	private Sensor sensor = null;
	
	private void Awake()
	{
		ShipComponent[] shipComponents = GetComponentsInChildren<ShipComponent>( true );
		
		for ( Int32 i=0; i<shipComponents.Length; ++i )
		{
			ShipComponent shipComponent = shipComponents[i];
			shipComponent.Owner = transform;
			
			if ( shipComponent is Sensor )
			{
				sensor = (Sensor)shipComponent;
				sensor.onTargetDetected += OnTargetDetected;
				sensor.onTargetLost += OnTargetLost;
			}
			else if ( shipComponent is NavComputer )
			{
				navComputer = (NavComputer)shipComponent;
			}
		}
	}
	
	private void OnTargetDetected( Collider target )
	{
		Debug.Log( "Dragonfly.OnTargetDetection - " + target.name );
		
		if ( sensor )
		{
			Debug.Log( "Dragonfly.OnTargetDetected - Now tracking " + sensor.TrackedTargets.Count + " targets." );
		}
	}
	
	private void OnTargetLost( Collider target )
	{
		Debug.Log( "Dragonfly.OnTargetLost - " + target.name );
		
		if ( sensor )
		{
			Debug.Log( "Dragonfly.OnTargetDetected - Now tracking " + sensor.TrackedTargets.Count + " targets." );
		}
	}
}