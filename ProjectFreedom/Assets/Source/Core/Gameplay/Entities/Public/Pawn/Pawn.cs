#region File Header
// File Name:		BasePawn.cs
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
using System.Collections.Generic;
#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The Pawn is the base script for all controllable game objects.
    /// </summary>
    public class Pawn : MonoBehaviour
    {
        /// <summary>
        /// The Pawn's controller.
        /// </summary>
        private BaseController controller = null;
        
        /// <summary>
        /// Raises the possess event.  OnPossess is called when a controller takes control of a Pawn.
        /// </summary>
        /// <param name="controller">The <see cref="BaseController"/> controlling the Pawn.</param>
        public virtual void OnPossess( BaseController controller )
        {
            this.controller = controller;
        }

        /// <summary>
        /// Raises the un possess event.  OnUnPossess is called when a controller releases control of a Pawn.
        /// </summary>
        public virtual void OnUnPossess()
        {
            controller = null;
        }
        
        /// <summary>
        /// Update this instance's controller.
        /// </summary>
        void Update()
        {
            if ( controller != null )
            {
                controller.Update();
            }
        }
    }
}