#region File Header

// File Name:		Pawn.cs
// Author:			John Whitsell
// Creation Date:	2014/09/07
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using Logging;

using System;
using System.Collections.Generic;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The Pawn is the base script for all controllable game objects.
    /// </summary>
    public class Pawn : MonoBehaviour
    {
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( Pawn ) );
		#endif

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
			#if LOGGING
			Log.Trace( "Begin void OnPossess( BaseController controller )" );
			#endif

			#if PARAM_CHECKING
			if( controller == null )
			{
				throw new ArgumentException( "parameter controller is required" );
			}
			#endif

            this.controller = controller;

			#if LOGGING
			Log.Trace( "End void OnPossess( BaseController controller )" );
			#endif
        }

        /// <summary>
        /// Raises the un possess event.  OnUnPossess is called when a controller releases control of a Pawn.
        /// </summary>
        public virtual void OnUnPossess()
        {
			#if LOGGING
			Log.Trace( "Begin void OnUnPossess()" );
			#endif

            controller = null;

			#if LOGGING
			Log.Trace( "End void OnUnPossess()" );
			#endif
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