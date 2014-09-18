#region File Header

// File Name:		IInputComponent.cs
// Author:			John Whitsell
// Creation Date:	2014/09/07
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEngine;

#endregion

namespace LunarGrin.Core
{
    /// <summary>
    /// Defines the interface to controls.
    /// </summary>
    public interface IControls
    {
		/// <summary>
		/// Raises the resume event.  OnResume is called every time the owner of the controls is set.
		/// </summary>
		void OnResume();

		/// <summary>
		/// Raises the shutdown event.  OnShutdown is called once on destruction.
		/// </summary>
		void OnShutdown();

        /// <summary>
        /// Raises the startup event.  OnStartup is called once on initialization.
        /// </summary>
        void OnStartup();

        /// <summary>
        /// Raises the suspend event.  OnSuspend is called every time the owner of the controls is cleared.
        /// </summary>
        void OnSuspend();

        /// <summary>
        /// Update this instance.  Update gets called every frame by the control's owner.
        /// </summary>
        void Update();
    }
}