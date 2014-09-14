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
using UnityEngine;
using System;
using System.Collections.Generic;
#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// The Base controller defines the basic functionality of a controller.  A controller is able to "Possess" and "Unpossess" a <see cref="Pawn"/>.  The controller uses an <see cref="IControls"/> to control the Pawn it possesses.
    /// </summary>
    public class BaseController
    {
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
            if ( target != null )
            {
                Possess( target.GetComponent<Pawn>() );
            }
        }
        
        /// <summary>
        /// Possess the specified target.
        /// </summary>
        /// <param name="target">Target.</param>
        public void Possess( Pawn target )
        {
            if ( pawn != null )
            {
                pawn.OnUnPossess();
            }
            
            pawn = target;
            
            if ( pawn != null )
            {
                pawn.OnPossess( this );
            }
        }

        /// <summary>
        /// Unpossesses the current <see cref="Pawn"/>.
        /// </summary>
        public void UnPossess()
        {
            if ( pawn != null )
            {
                pawn.OnUnPossess();
                pawn = null;
            }
        }
        
        /// <summary>
        /// Update this instance.  Update is called from the <see cref="Pawn"/> that is being possessed.  If no <see cref="Pawn"/> is being possessed, Update will not be called.
        /// </summary>
        public void Update()
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
            if ( controlsStack.Count > 0 )
            {
                return controlsStack.Peek();
            }
            
            return null;
        }

        /// <summary>
        /// Pops the top controls off the control stack.  OnShutdown will be called on the active controls.  OnResume will be called on the previously active controls, if they existed.
        /// </summary>
        protected void PopControls()
        {
            IControls activeControls = null;
            
            if ( controlsStack.Count > 0 )
            {
                activeControls = controlsStack.Pop();
                
                activeControls.OnShutdown();
                
                if ( (activeControls = GetControls()) != null )
                {
                    activeControls.OnResume();
                }
            }
        }
        
        /// <summary>
        /// Pushes the controls to the top of the stack.  OnSuspend will be called on the active controls before the new controls will be added to the stack.  OnStartup will be called on the new controls.
        /// </summary>
        /// <param name="controls">Controls.</param>
        protected void PushControls( IControls controls )
        {
            if ( controls != null )
            {
                IControls activeControls = GetControls();
                
                if ( activeControls != null )
                {
                    activeControls.OnSuspend();
                }
                
                controlsStack.Push( controls );
                
                controls.OnStartup();
            }
        }
    }
}