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
	/// <seealso cref="LunarGrin.Core.IControls"/>
	public sealed class PlayerShipCamera : IControls
	{
		#region Private Fields
		
		/// <summary>
		/// The game camera that owns this control.
		/// </summary>
		private GameCamera gameCamera = null;
		
		/// <summary>
		/// The pawn that this camera follows.
		/// </summary>
		private Pawn pawn = null;
		
		/// <summary>
		/// The camera position offset.
		/// </summary>
		private Vector3 positionOffset = Vector3.zero;
		
		/// <summary>
		/// The camera position damping.
		/// </summary>
		private Single positionDamping = 3.0f;
		
		/// <summary>
		/// The camera rotation damping.
		/// </summary>
		private Single rotationDamping = 3.0f;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets the camera position offset.
		/// </summary>
		/// <value>The camera position offset.</value>
		public Vector3 PositionOffset
		{
			get
			{
				return positionOffset;
			}
			
			set
			{
				positionOffset = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the camera position damping.
		/// </summary>
		/// <value>The camera position damping.</value>
		public Single PositionDamping
		{
			get
			{
				return positionDamping;
			}
			
			set
			{
				positionDamping = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the camera rotation smoothness.
		/// </summary>
		/// <value>The camera rotation smoothness.</value>
		public Single RotationDamping
		{
			get
			{
				return rotationDamping;
			}
			
			set
			{
				rotationDamping = value;
			}
		}
		
		#endregion
	
		#region Constructors
		
		/// <summary>
		/// Default constructor initializes a new instance of the <see cref="LunarGrin.UnitTests.PlayerFlightControlsUnitTest.PlayerShipCamera"/> class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Unable to create the player ship camera because the game camera reference is invalid.</exception>
		/// <exception cref="InvalidOperationException">Unable to create the player ship because the pawn is invalid.</exception>
		public PlayerShipCamera( GameCamera camera )
		{
			if( camera == null )
			{
				throw new ArgumentNullException( "Unable to create the player ship camera because the game camera reference is invalid." );
			}
			
			if( GameServices.GameInfo.Player.Pawn == null )
			{
				throw new InvalidOperationException( "Unable to create the player ship because the pawn is invalid." );
			}
			
			gameCamera = camera;		                                         
			pawn = GameServices.GameInfo.Player.Pawn;
			
			// Default offset.
			positionOffset = new Vector3( 0.0f, 10.0f, -30.0f );
		}
		
		#endregion
		
		#region Public Methods
		
		#region IControls
		
		/// <summary>
		/// Raised when the camera control has been pushed to the controls stack.
		/// </summary>
		public void OnStartup()
		{
			
		}
		
		/// <summary>
		/// Raised when the control is popped off the controls stack.
		/// </summary>
		public void OnShutdown()
		{
			
		}
		
		/// <summary>
		/// Raised when the camera control has resumed as the top control in the controls stack.
		/// </summary>
		public void OnResume()
		{
			
		}
		
		/// <summary>
		/// Raised when the control has been suspended by another control being pushed to the controls stack.
		/// </summary>
		public void OnSuspend()
		{
			
		}
		
		/// <summary>
		/// Updates the camera control.
		/// </summary>
		public void Update()
		{
			if( gameCamera != null && pawn != null )
			{
				// Camera rotation.
				gameCamera.transform.rotation = Quaternion.Slerp( gameCamera.transform.rotation, pawn.transform.rotation, Time.deltaTime * rotationDamping );
				
				// Camera offset.
				Vector3 toVec = pawn.transform.TransformPoint( positionOffset );
				Vector3 vel = Vector3.zero;
				
				// Camera position.
				gameCamera.transform.position = Vector3.SmoothDamp( gameCamera.transform.position, toVec, ref vel, positionDamping * Time.deltaTime );
			}
		}
		
		#endregion
		
		#endregion
	}
}
