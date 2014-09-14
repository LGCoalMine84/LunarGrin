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
using UnityEngine;
using System;
#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The GameCamera is a player's point of view in the game world.  There should only be one GameCamera per local player in the game.
    /// </summary>
    public class GameCamera : MonoBehaviour
    {
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
        /// Updates the camera's controls.  This must be performed in LateUpdate to make sure the simulation phase in the game's Update is complete.
        /// </summary>
        void LateUpdate()
        {
            if ( controls != null )
            {
                controls.Update();
            }
        }

        //  This is an example controls implementation.  One function should exist for each control type.  
        //  Each function should define any parameters that are needed to setup the controls (e.g. camera 
        //  or a colliding Pawn) so that the controls can make sure the conditions are correct to push 
        //  the new control state.
        public void SetOrbitControls()
        {
            Controls = new CameraOrbitControls( this );
        }
    }
}