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

public class Dragonfly : MonoBehaviour
{
	private NavComputer navComputer = null;
	
	private Sensor sensor = null;
	
	private PropulsionControlUnit PCU = null;
	
	//	TEMP:	Putting in materials for coloring
	private Material blue = null;
	private Material green = null;
	private Material yellow = null;
	private Material red = null;
	
	private void Awake()
	{
		ShipComponent[] shipComponents = GetComponentsInChildren<ShipComponent>( true );
		
		for ( Int32 i=0; i<shipComponents.Length; ++i )
		{
			ShipComponent shipComponent = shipComponents[i];
			shipComponent.Ship = transform;
			
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
			else if ( shipComponent is PropulsionControlUnit )
			{
				PCU = (PropulsionControlUnit)shipComponent;
			}
		}
		
		//	TEMP:	Material assignment
		blue = Resources.Load( "UnitTests/Materials/Blue" ) as Material;
		green = Resources.Load( "UnitTests/Materials/Green" ) as Material;
		yellow = Resources.Load( "UnitTests/Materials/Yellow" ) as Material;
		red = Resources.Load( "UnitTests/Materials/Red" ) as Material;
	}
	
	private void OnTargetDetected( Collider target )
	{
		if ( sensor )
		{
			Vector3 toTarget = target.transform.position - transform.position;
			
			toTarget.Normalize();
			
			Single direction = Vector3.Dot( transform.forward, toTarget );
			
			//	90-60
			if ( direction > 0.86 )
			{
				//	Target is in front
				target.renderer.material = blue;
			}
			//	60-30
			else if ( direction >= 0.50f )
			{
				//	Target is to the side
				target.renderer.material = green;
			}
			//	30-0
			else if ( direction > 0 )
			{
				target.renderer.material = yellow;
			}
			else
			{
				//	Target is behind
				target.renderer.material = red;
			}
		}
	}
	
	private void OnTargetLost( Collider target )
	{
		if ( sensor )
		{
			target.renderer.material = new Material( Shader.Find( "Diffuse" ) );
		}
	}
}