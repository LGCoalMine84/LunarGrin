#region File Header

// File Name:		PlayerMoveControls.cs
// Author:			John Whitsell
// Creation Date:	2014/09/07
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using LunarGrin.Core;

using System;

using UnityEngine;

#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	/// <summary>
	/// This is an example controls implementation.
	/// </summary>
	public class PlayerMoveControls : IControls
	{
	    /// <summary>
	    /// The owner.
	    /// </summary>
	    private BaseController owner = null;
	    
	    /// <summary>
	    /// Initializes a new instance of the <see cref="PlayerMoveControls"/> class.
	    /// </summary>
	    /// <param name="owner">Owner.</param>
	    public PlayerMoveControls( BaseController owner )
	    {
	        this.owner = owner;
	        
	        //  TODO:   Throw error if owner is null
	    }
	    
		/// <summary>
		/// Raises the resume event.  OnResume is called every time the owner of the controls is set.
		/// </summary>
		public void OnResume()
		{
		}
	
		/// <summary>
		/// Raises the shutdown event.  OnShutdown is called once on destruction.
		/// </summary>
		public void OnShutdown()
		{
		}
	
	    /// <summary>
	    /// Raises the startup event.  OnStartup is called once on initialization.
	    /// </summary>
	    public void OnStartup()
	    {
	    }
	    
	    /// <summary>
	    /// Raises the suspend event.  OnSuspend is called every time the owner of the controls is cleared.
	    /// </summary>
	    public void OnSuspend()
	    {
	    }
	    
	    /// <summary>
	    /// Update this instance.  Update gets called every frame by the control's owner.
	    /// </summary>
	    public void Update()
	    {
	        if ( owner.Pawn != null )
	        {
	            //  Note:  Can cast Pawn to a specific type to extract specific object data.  If Pawn is not that type, throw an error.
	            
	            Transform transform = owner.Pawn.transform;
	            
	            if ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) )
	            {
	                transform.Translate( new Vector3( 0f, 0f, Time.deltaTime ) );
	            }
	            
	            if ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) )
	            {
	                transform.Translate( new Vector3( 0f, 0f, -Time.deltaTime ) );
	            }
	            
	            if ( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.LeftArrow ) )
	            {
	                transform.Translate( new Vector3( -Time.deltaTime, 0f, 0f ) );
	            }
	            
	            if ( Input.GetKey( KeyCode.D ) || Input.GetKey( KeyCode.RightArrow ) )
	            {
	                transform.Translate( new Vector3( Time.deltaTime, 0f, 0f ) );
	            }
	        }
	        else
	        {
	            //  TODO:   Throw an error, no pawn exists for the control scheme to update.
	        }
	    }
	}
}