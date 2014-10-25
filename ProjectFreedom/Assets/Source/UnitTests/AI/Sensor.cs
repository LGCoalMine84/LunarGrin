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

using UnityEngine;

#endregion

[ExecuteInEditMode]
public class Sensor : MonoBehaviour
{
	private Single sensorRadius = 100f;

	private SphereCollider sensor = null;
	
	private Boolean sensorRadiusChanged = false;
	
	public Single SensorRadius
	{
		get
		{
			return sensorRadius;
		}
		set
		{
			if ( sensorRadius != value )
			{
				sensorRadius = value;
				sensorRadiusChanged = true;
			}
		}
	}

	private void Start()
	{
		sensor = gameObject.AddComponent<SphereCollider>();
		
		//sensor.transform.localPosition = Vector3.zero;
		//sensor.transform.localRotation = Quaternion.identity;
		//sensor.transform.localScale = Vector3.zero;
		
		sensor.radius = sensorRadius;
	}
	
	private void Update()
	{
		if ( sensorRadiusChanged )
		{
			sensor.radius = sensorRadius;
		}
	}
	
	private void OnDestroy()
	{
		#if UNITY_EDITOR
		{
			GameObject.DestroyImmediate( sensor );
		}
		#else
		{
			GameObject.Destroy( sensor );
		}
		#endif
	}
}