#region File Header
// File Name:		GhostCameraControls.cs
// Author:			John Whitsell
// Creation Date:	2014/09/28
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

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	/// <summary>
	/// Ghost camera controls allow the camera to freely fly in any direction.  This is an example camera control scheme.
	/// </summary>
	public class GhostCameraControls : IControls
	{
		/// <summary>
		/// The game camera.
		/// </summary>
		private GameCamera gameCamera = null;
		
		/// <summary>
		/// The look camera speed.
		/// </summary>
		private Single lookSpeed = 360f;
		
		/// <summary>
		/// The camera move speed.
		/// </summary>
		private Single moveSpeed = 15f;
		
		/// <summary>
		/// The camera rotation x.
		/// </summary>
		private Single rotationX = 0f;
		
		/// <summary>
		/// The camera rotation y.
		/// </summary>
		private Single rotationY = 0f;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerControllerUnitTest.GhostCameraControls"/> class.
		/// </summary>
		/// <param name="camera">The camera to control.</param>
		public GhostCameraControls( GameCamera camera )
		{
			gameCamera = camera;
		}
		
		/// <summary>
		/// Raises the resume event. OnResume is called every time the owner of the controls is set.
		/// </summary>
		public void OnResume()
		{
		}
		
		/// <summary>
		/// Raises the shutdown event. OnShutdown is called once on destruction.
		/// </summary>
		public void OnShutdown()
		{
		}
	
		/// <summary>
		/// Raises the startup event. OnStartup is called once on initialization.
		/// </summary>
		public void OnStartup()
		{
		}
	
		/// <summary>
		/// Raises the suspend event. OnSuspend is called every time the owner of the controls is cleared.
		/// </summary>
		public void OnSuspend()
		{
		}
	
		/// <summary>
		/// Update this instance. Update gets called every frame by the control's owner.
		/// </summary>
		public void Update()
		{
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
}