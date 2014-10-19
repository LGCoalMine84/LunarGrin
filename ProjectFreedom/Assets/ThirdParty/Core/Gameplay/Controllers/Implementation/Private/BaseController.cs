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

using  LunarGrin.Utilities;

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
		private static ILogger Log = LogFactory.CreateLogger( typeof( BaseController ) );

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
			Log.Trace( "Begin void Possess( GameObject target )" );

            if ( target != null )
            {
                Possess( target.GetComponent<Pawn>() );
            }

			Log.Trace( "End void Possess( GameObject target )" );
        }
        
        /// <summary>
        /// Possess the specified target.
        /// </summary>
        /// <param name="target">Target.</param>
        public void Possess( Pawn target )
        {
			Log.Trace( "Begin void Possess( Pawn target )" );

			if( target == null )
			{
				throw new ArgumentException( "parameter target is required" );
			}

            if ( pawn != null )
            {
                pawn.OnUnPossess();
            }
            
            pawn = target;
			pawn.OnPossess( this );

			Log.Trace( "End void Possess( Pawn target )" );
        }

        /// <summary>
        /// Unpossesses the current <see cref="Pawn"/>.
        /// </summary>
        public void UnPossess()
        {
			Log.Trace( "Begin void UnPossess()" );

            if ( pawn != null )
            {
                pawn.OnUnPossess();

                pawn = null;
            }

			Log.Trace( "End void UnPossess()" );
        }
        
        /// <summary>
        /// Update this instance.  Update is called from the <see cref="Pawn"/> that is being possessed.  If no <see cref="Pawn"/> is being possessed, Update will not be called.
        /// </summary>
        protected void Update()
        {
            IControls activeControls = GetControls();
            
            if ( activeControls != null )
            {
                activeControls.Update();
            }
        }

        /// <summary>
        /// Gets the controls at the top of the control stack.
        /// </summary>
        /// <returns>The controls.</returns>
        protected IControls GetControls()
        {
			IControls controls = null;

            if ( controlsStack.Count > 0 )
            {
				controls = controlsStack.Peek();
            }

			return controls;
        }

        /// <summary>
        /// Pops the top controls off the control stack.  OnShutdown will be called on the active controls.  OnResume will be called on the previously active controls, if they existed.
        /// </summary>
		public void PopControls()
        {
			Log.Trace( "Begin void PopControls()" );
            
            if ( controlsStack.Count > 0 )
            {
				IControls activeControls = controlsStack.Pop();
                
                activeControls.OnShutdown();
                
                if ( (activeControls = GetControls()) != null )
                {
                    activeControls.OnResume();
                }
            }

			Log.Trace( "End void PopControls()" );
        }
        
        /// <summary>
        /// Pushes the controls to the top of the stack.  OnSuspend will be called on the active controls before 
		/// the new controls will be added to the stack.  OnStartup will be called on the new controls.
        /// </summary>
        /// <param name="controls">Controls.</param>
        public void PushControls( IControls controls )
        {
			Log.Trace( "Begin void PushControls( IControls controls )" );

			if( controls == null )
			{
				throw new ArgumentException( "parameter controls is required" );
			}

			IControls activeControls = GetControls();
			
			if ( activeControls != null )
			{
				activeControls.OnSuspend();
			}
			
			controlsStack.Push( controls );
			
			controls.OnStartup();

			Log.Trace( "End void PushControls( IControls controls )" );
        }
    }
}