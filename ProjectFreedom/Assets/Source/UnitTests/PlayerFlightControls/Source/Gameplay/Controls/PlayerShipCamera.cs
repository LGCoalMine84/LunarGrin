#region File Header

// File Name:           PlayerShipCamera.cs
// Author:              Andy Sanchez
// Creation Date:       10/25/2014   10:06 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

using LunarGrin.Core;

#endregion

namespace LunarGrin.UnitTests.PlayerFlightControlsUnitTest
{
	/// <summary>
	/// The camera of the player ship.
	/// </summary>
	public sealed class PlayerShipCamera : IControls
	{
		#region Private Fields
		
		/// <summary>
		/// The game camera that owns this control.
		/// </summary>
		private GameCamera gameCam = null;
		
		/// <summary>
		/// The pawn that this camera follows.
		/// </summary>
		private Pawn pawn = null;
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerShipCamera"/> class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Unable to create the player ship camera because the game camera reference is invalid.</exception>
		public PlayerShipCamera( GameCamera camera )
		{
			if( camera == null )
			{
				throw new ArgumentNullException( "Unable to create the player ship camera because the game camera reference is invalid." );
			}
		
			gameCam = camera;
			                                         
			pawn = GameServices.GameInfo.Player.Pawn;
		}
		
		#endregion
		
		#region Public Methods
		
		#region IControls
		
		/// <summary>
		/// Raises the resume event. This method is called every time the owner of the controls is set.
		/// </summary>
		public void OnResume()
		{
			
		}
		
		/// <summary>
		/// Raises the shutdown event. This method is called once on destruction.
		/// </summary>
		public void OnShutdown()
		{
			
		}
		
		/// <summary>
		/// Raises the startup event. This method is called once on initialization.
		/// </summary>
		public void OnStartup()
		{
			
		}
		
		/// <summary>
		/// Raises the suspend event. This method is called every time the owner of the controls is cleared.
		/// </summary>
		public void OnSuspend()
		{
			
		}
		
		/// <summary>
		/// Update this instance. Update gets called every frame by the owner of the control.
		/// </summary>
		public void Update()
		{
			// Camera offset.
			Vector3 toVec = pawn.transform.TransformPoint( 0.0f, 10.0f, -30.0f );
			
			if( gameCam != null && pawn != null )
			{
				gameCam.transform.rotation = Quaternion.Slerp( gameCam.transform.rotation, pawn.transform.rotation, Time.deltaTime * 3.0f );
				
				Vector3 vel = Vector3.zero;
				gameCam.transform.position = Vector3.SmoothDamp( gameCam.transform.position, toVec, ref vel, 3.0f * Time.deltaTime );
			}
		}
		
		#endregion
		
		#endregion
	}
}
