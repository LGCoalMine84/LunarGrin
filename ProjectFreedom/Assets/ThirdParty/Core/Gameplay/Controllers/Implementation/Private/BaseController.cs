#region File Header

// File Name:		BaseController.cs
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
    /// The Base controller defines the basic functionality of a controller.  A controller is 
	/// able to "Possess" and "Unpossess" a <see cref="Pawn"/>.  The controller uses an <see cref="IControls"/> to control the Pawn it possesses.
    /// </summary>
    public class BaseController : MonoBehaviour
    {
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( BaseController ) );
		#endif

        /// <summary>
        /// The pawn the controller is possessing.
        /// </summary>
        private Pawn pawn = null;
        
        /// <summary>
        /// The controls stack used to control the Pawn.  Only the top control is active.
        /// </summary>
        private Stack<IControls> controlsStack = new Stack<IControls>();
        
        /// <summary>
        /// Gets the pawn the controller is possessing.
        /// </summary>
        /// <value>The pawn.</value>
        public Pawn Pawn
        {
            get
            {
                return pawn;
            }
        }
        
        /// <summary>
        /// Possess the specified target.  The target must have a <see cref="Pawn"/> script attached.
        /// </summary>
        /// <param name="target">Target.</param>
        public void Possess( GameObject target )
        {
			#if LOGGING
			Log.Trace( "Begin void Possess( GameObject target )" );
			#endif

            if ( target != null )
            {
                Possess( target.GetComponent<Pawn>() );
            }

			#if LOGGING
			Log.Trace( "End void Possess( GameObject target )" );
			#endif
        }
        
        /// <summary>
        /// Possess the specified target.
        /// </summary>
        /// <param name="target">Target.</param>
        public void Possess( Pawn target )
        {
			#if LOGGING
			Log.Trace( "Begin void Possess( Pawn target )" );
			#endif

			#if PARAM_CHECKING
			if( target == null )
			{
				throw new ArgumentException( "parameter target is required" );
			}
			#endif

            if ( pawn != null )
            {
                pawn.OnUnPossess();
            }
            
            pawn = target;
			pawn.OnPossess( this );

			#if LOGGING
			Log.Trace( "End void Possess( Pawn target )" );
			#endif
        }

        /// <summary>
        /// Unpossesses the current <see cref="Pawn"/>.
        /// </summary>
        public void UnPossess()
        {
			#if LOGGING
			Log.Trace( "Begin void UnPossess()" );
			#endif

            if ( pawn != null )
            {
                pawn.OnUnPossess();

                pawn = null;
            }

			#if LOGGING
			Log.Trace( "End void UnPossess()" );
			#endif
        }
        
        /// <summary>
        /// Update this instance.  Update is called from the <see cref="Pawn"/> that is being possessed.  If no <see cref="Pawn"/> is being possessed, Update will not be called.
        /// </summary>
        protected void Update()
        {
			#if LOGGING
			Log.Trace( "Begin void Update()" );
			#endif

            IControls activeControls = GetControls();
            
            if ( activeControls != null )
            {
                activeControls.Update();
            }

			#if LOGGING
			Log.Trace( "End void Update()" );
			#endif
        }

        /// <summary>
        /// Gets the controls at the top of the control stack.
        /// </summary>
        /// <returns>The controls.</returns>
        protected IControls GetControls()
        {
			#if LOGGING
			Log.Trace( "Begin IControls GetControls()" );
			#endif

			IControls controls = null;

            if ( controlsStack.Count > 0 )
            {
				controls = controlsStack.Peek();
            }
            
			#if LOGGING
			Log.Trace( "End IControls GetControls()" );
			#endif

			return controls;
        }

        /// <summary>
        /// Pops the top controls off the control stack.  OnShutdown will be called on the active controls.  OnResume will be called on the previously active controls, if they existed.
        /// </summary>
		public void PopControls()
        {
			#if LOGGING
			Log.Trace( "Begin void PopControls()" );
			#endif
            
            if ( controlsStack.Count > 0 )
            {
				IControls activeControls = controlsStack.Pop();
                
                activeControls.OnShutdown();
                
                if ( (activeControls = GetControls()) != null )
                {
                    activeControls.OnResume();
                }
            }

			#if LOGGING
			Log.Trace( "End void PopControls()" );
			#endif
        }
        
        /// <summary>
        /// Pushes the controls to the top of the stack.  OnSuspend will be called on the active controls before 
		/// the new controls will be added to the stack.  OnStartup will be called on the new controls.
        /// </summary>
        /// <param name="controls">Controls.</param>
        public void PushControls( IControls controls )
        {
			#if LOGGING
			Log.Trace( "Begin void PushControls( IControls controls )" );
			#endif

			#if PARAM_CHECKING
			if( controls == null )
			{
				throw new ArgumentException( "parameter controls is required" );
			}
			#endif

			IControls activeControls = GetControls();
			
			if ( activeControls != null )
			{
				activeControls.OnSuspend();
			}
			
			controlsStack.Push( controls );
			
			controls.OnStartup();

			#if LOGGING
			Log.Trace( "End void PushControls( IControls controls )" );
			#endif
        }
    }
}