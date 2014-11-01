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

using UnityEngine;

#endregion

[ExecuteInEditMode]
public class Dragonfly : MonoBehaviour
{
	private NavComputer navComputer = null;
	
	private Sensor sensor = null;
	
	private void Awake()
	{
		sensor = GetComponentInChildren<Sensor>();
		
		if ( sensor )
		{
			sensor.onTargetDetected += OnTargetDetected;
			sensor.onTargetLost += OnTargetLost;
		}
		
		navComputer = GetComponentInChildren<NavComputer>();
		
		if ( navComputer )
		{
			navComputer.owner = transform;
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