#region File Header

// File Name:		NavComputer.cs
// Author:			John Whitsell
// Creation Date:	2014/10/26
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections;

using UnityEngine;

using LunarGrin.UnitTests.PlayerFlightControlsUnitTest;

using Random = UnityEngine.Random;

#endregion

public class NavComputer : ShipComponent
{
	//	The nav computer is not responsible for moving the ship, the engines do that.  The nav computer 
	//	is responsible for calculating the route from where the ship is to where it needs to go, taking 
	//	into consideration ship capabilities.  It then directs the engines to fire in a manner to 
	//	achieve that route.

	private Vector3 destination = Vector3.zero;
	
	private Single maxSpeed = 20f;
	
	private PropulsionControlUnit PCU = null;
	
	private void Awake()
	{
		PCU = owner.GetComponent<PropulsionControlUnit>();
	}
	
	private void Start()
	{
		StartCoroutine( RandomizeDestination() );
	}
	
	private void Update()
	{
		Vector3 direction = destination - transform.position;
		
		direction.Normalize();
		
		owner.Translate( direction * maxSpeed * Time.deltaTime );
	}
	
	private IEnumerator RandomizeDestination()
	{
		while( true )
		{
			SetRandomDestination();
			
			Debug.Log( "NavComputer.RandomizeDestination = " + destination );
			
			yield return new WaitForSeconds( 6.0f );
		}
	}
	
	private void SetRandomDestination()
	{
		destination.x = Random.Range( -500f, 500f );
		destination.y = Random.Range( -100f, 100f );
		destination.z = Random.Range( -500f, 500f );
	}
}