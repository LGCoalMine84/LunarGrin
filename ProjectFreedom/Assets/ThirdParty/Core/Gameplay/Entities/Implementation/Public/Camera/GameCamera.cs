#region File Header

// File Name:		CameraManager.cs
// Author:			John Whitsell
// Creation Date:	2014/09/07
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using  LunarGrin.Utilities;

using System;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The GameCamera is a player's point of view in the game world.  There should only be one GameCamera per local player in the game.
    /// </summary>
    public class GameCamera : MonoBehaviour
    {
		//private static ILogger Log = LogFactory.CreateLogger( typeof( GameCamera ) );
		
		/// <summary>
		/// A flag that determines whether or not the camera is physics based.  A camera should be physics based if its target uses the physics engine to change its position or rotation.
		/// </summary>
		public Boolean isPhysicsCamera = false;

        /// <summary>
        /// The camera's controls.
        /// </summary>
        private IControls controls = null;
    
        /// <summary>
        /// The camera's target.
        /// </summary>
        private Transform target = null;
        
        /// <summary>
        /// A value indicating whether this camera is active.  If the camera is not active it will not update its controls.
        /// </summary>
        private Boolean isActive = false;
        
        /// <summary>
        /// Gets or sets the camera's controls.
        /// </summary>
        /// <value>The controls.</value>
        public IControls Controls
        {
            get
            {
                return controls;
            }
            set
            {
                if ( controls != null )
                {
                    controls.OnShutdown();
                }
                if ( value != null )
                {
                    controls = value;
                    
                    controls.OnStartup();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the camera's target.
        /// </summary>
        /// <value>The target.</value>
        public Transform Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
            }
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether this camera is active.  If the camera is not active it will not update its controls.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public Boolean IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                if ( isActive != value )
                {
                    isActive = value;
                    
                    if ( controls != null )
                    {
                        if ( isActive )
                        {
                            controls.OnResume();
                        }
                        else
                        {
                            controls.OnSuspend();
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Updates the camera's controls.  This update will only occur if the camera is physics based.
        /// </summary>
		void FixedUpdate()
		{
			if ( isPhysicsCamera && controls != null )
			{
				controls.Update();
			}
		}
        
        /// <summary>
        /// Updates the camera's controls.  This update will only occur if the camear is not physics based.
        /// </summary>
		void LateUpdate()
		{
			if ( !isPhysicsCamera && controls != null )
			{
				controls.Update();
			}
		}
    }
}