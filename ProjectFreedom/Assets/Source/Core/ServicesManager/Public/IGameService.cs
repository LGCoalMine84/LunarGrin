#region File Header

// File Name:           IGameService.cs
// Author:              Andy Sanchez
// Creation Date:       9/1/2014   5:13 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

#endregion

namespace LunarGrin.Core
{
	/// <summary>
	/// Interface that enables a game manager to be globally available to the entire application. 
	/// </summary>
	public interface IGameService
	{
		#region Properties
	
		/// <summary>
		/// Gets the type of the game service.
		/// </summary>
		/// <value>The type of the game service.</value>
		ServiceType GameServiceType
		{
			get;
		}
		
		#endregion
	}
}
