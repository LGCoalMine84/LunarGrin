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

using System.Collections;

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
		private Pawn pawn = null;
	
		private GameCamera gameCam = null;
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerShipCamera"/> class.
		/// </summary>
		public PlayerShipCamera( GameCamera camera )
		{
			gameCam = camera;
			
			gameCam.transform.position = new Vector3( gameCam.transform.position.x,
			                                         gameCam.transform.position.y + 20.0f,
			                                         gameCam.transform.position.z - 40.0f );
			                                         
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
		/// Update this instance. Update gets called every frame by the control's owner.
		/// </summary>
		public void Update()
		{
			Vector3 toVec = pawn.transform.TransformPoint( 0.0f, 10.0f, -30.0f );
		
			Vector3 vel = Vector3.zero;
			if( gameCam != null )
			{
				gameCam.transform.rotation = Quaternion.Slerp( gameCam.transform.rotation, pawn.transform.rotation, Time.deltaTime * 3.0f );
				//gameCam.transform.position = Vector3.Lerp( gameCam.transform.position, toVec, Time.deltaTime );
				gameCam.transform.position = Vector3.SmoothDamp( gameCam.transform.position, toVec, ref vel, 3.0f * Time.deltaTime );
			}
		}
		
		#endregion
		
		#endregion
	}
}
