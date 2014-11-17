#region File Header

// File Name:		Sensor.cs
// Author:			John Whitsell
// Creation Date:	2014/10/25
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using LunarGrin.UnitTests.PlayerFlightControlsUnitTest;

#endregion

[Serializable]
[ExecuteInEditMode]
public class Sensor : ShipComponent
{
	public Single sensorRadius = 100f;

	[SerializeField]
	[HideInInspector]
	private SphereCollider sensor = null;
	
	//	TODO:	Triggers do not fire when a GO is destroyed... trackedTargets will have a NULL in this case.
	private List<Collider> trackedTargets = new List<Collider>();
	
	public delegate void OnTargetDetected( Collider target );
	public delegate void OnTargetLost( Collider target );
	
	public OnTargetDetected onTargetDetected;
	public OnTargetLost onTargetLost;
	
	public List<Collider> TrackedTargets
	{
		get
		{
			return trackedTargets;
		}
	}

	private void Awake()
	{
		if ( sensor == null )
		{
			sensor = gameObject.AddComponent<SphereCollider>();
			sensor.center = Vector3.zero;
			sensor.radius = sensorRadius;
			sensor.isTrigger = true;
		}
	}

	private void Update()
	{
		if ( sensor )
		{
			sensor.radius = sensorRadius;
		}
	}

	private void OnDestroy()
	{
		if ( !Application.isPlaying )
		{
			EditorApplication.delayCall += () =>
			{
				if ( Application.isEditor && !EditorApplication.isPlayingOrWillChangePlaymode )
				{
					//	Deletes the sensor when performing a 'Remove Component' in the INSPECTOR
					DestroyImmediate( sensor );
				}
			};
		}
	}
	
	private void OnTriggerEnter( Collider obj )
	{
		if ( !trackedTargets.Contains( obj ) )
		{
			trackedTargets.Add( obj );
			
			if ( onTargetDetected != null )
			{
				onTargetDetected( obj );
			}
		}
	}
	
	private void OnTriggerExit( Collider obj )
	{
		trackedTargets.Remove( obj );
	
		if ( onTargetLost != null )
		{
			onTargetLost( obj );
		}
	}
}