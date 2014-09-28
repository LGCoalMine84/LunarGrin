#region File Header
// File Name:		GhostCameraControls.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using System;

using UnityEngine;

using LunarGrin.Core;
#endregion

public class GhostCameraControls : IControls
{
	/// <summary>
	/// The game camera.
	/// </summary>
	private GameCamera gameCamera = null;
	
	private Single lookSpeed = 360f;
	
	private Single moveSpeed = 15f;
	
	private Single rotationX = 0f;
	
	private Single rotationY = 0f;
	
	public GhostCameraControls( GameCamera camera )
	{
		gameCamera = camera;
	}
	
	public void OnResume()
	{
	}

	public void OnShutdown()
	{
	}

	public void OnStartup()
	{
	}

	public void OnSuspend()
	{
	}

	public void Update()
	{
		Debug.Log( "GhostCameraControls.Update" );
	
		if ( gameCamera != null )
		{
			rotationX += Input.GetAxis("Mouse X")*lookSpeed * Time.deltaTime;
			rotationY += Input.GetAxis("Mouse Y")*lookSpeed * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, -90, 90);
			
			gameCamera.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
			gameCamera.transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
			
			gameCamera.transform.position += gameCamera.transform.forward*moveSpeed*Input.GetAxis("Vertical") * Time.deltaTime;
			gameCamera.transform.position += gameCamera.transform.right*moveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime;
		}
	}
}