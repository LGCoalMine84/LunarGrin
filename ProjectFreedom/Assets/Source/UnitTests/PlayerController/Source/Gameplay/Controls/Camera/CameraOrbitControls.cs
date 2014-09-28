#region File Header
// File Name:		CameraOrbitControls.cs
// Credit:          http://wiki.unity3d.com/index.php/MouseOrbitImproved
#endregion

#region Using Directives

using Logging;

using LunarGrin.Core;

using System;

using UnityEngine;

#endregion

namespace LunarGrin.UnitTests.PlayerControllerUnitTest
{
	/// <summary>
	/// This is an example camera controls implementation.
	/// </summary>
	public class CameraOrbitControls : IControls
	{
		#if LOGGING
		private static ILogger Log = LogFactory.CreateLogger( typeof( CameraOrbitControls ) );
		#endif
	
	    /// <summary>
	    /// The game camera.
	    /// </summary>
	    private GameCamera gameCamera = null;
	    
	    /// <summary>
	    /// The preferred distance.
	    /// </summary>
	    private float distance = 5.0f;
	    
	    /// <summary>
	    /// The x rotation speed.
	    /// </summary>
	    private float xSpeed = 120.0f;
	    
	    /// <summary>
	    /// The y rotation speed.
	    /// </summary>
	    private float ySpeed = 120.0f;
	    
	    /// <summary>
	    /// The view's y minimum angle limit, in degrees.
	    /// </summary>
	    private float yMinLimit = -20f;
	    
	    /// <summary>
	    /// The view's y max angle limit, in degrees.
	    /// </summary>
	    private float yMaxLimit = 80f;
	    
	    /// <summary>
	    /// The distance minimum.
	    /// </summary>
	    private float distanceMin = .5f;
	    
	    /// <summary>
	    /// The distance max.
	    /// </summary>
	    private float distanceMax = 15f;
	    
	    /// <summary>
	    /// Reusable x used for calculations.
	    /// </summary>
	    private float x = 0.0f;
	    
	    /// <summary>
	    /// Reusable y used for calculations.
	    /// </summary>
	    private float y = 0.0f;
	    
	    /// <summary>
	    /// Initializes a new instance of the <see cref="CameraOrbitControls"/> class.
	    /// </summary>
	    /// <param name="owner">Owner.</param>
	    /// <param name="target">Target.</param>
	    public CameraOrbitControls( GameCamera camera )
	    {
			#if LOGGING
			Log.Trace( "Begin CameraOrbitControls( GameCamera camera )" );
			#endif
	
			#if PARAM_CHECKING
			if( camera == null )
			{
				throw new ArgumentException( "parameter camera is required" );
			}
			#endif
	
	        gameCamera = camera;
	        
	        Vector3 angles = camera.transform.eulerAngles;
	        x = angles.y;
	        y = angles.x;
	
			#if LOGGING
			Log.Trace( "End CameraOrbitControls( GameCamera camera )" );
			#endif
	    }
	    
		/// <summary>
		/// Raises the resume event. OnResume is called every time the owner of the controls is set.
		/// </summary>
		public void OnResume()
		{
			
		}
	
		/// <summary>
		/// Raises the shutdown event. OnShutdown is called once on destruction.
		/// </summary>
		public void OnShutdown()
		{
			
		}
	
	    /// <summary>
	    /// Raises the startup event. OnStartup is called once on initialization.
	    /// </summary>
	    public void OnStartup()
	    {
	        
	    }
	
	    /// <summary>
	    /// Raises the suspend event. OnSuspend is called every time the owner of the controls is cleared.
	    /// </summary>
	    public void OnSuspend()
	    {
	        
	    }
	    
	    /// <summary>
	    /// Update this instance.
	    /// </summary>
	    public void Update()
	    {
	        if ( gameCamera != null && gameCamera.Target != null )
	        {
	            Transform camera = gameCamera.camera.transform;
	            Transform target = gameCamera.Target;
	        
	            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
	            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
	            
	            y = ClampAngle(y, yMinLimit, yMaxLimit);
	            
	            Quaternion rotation = Quaternion.Euler(y, x, 0);
	            
	            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
	            
	            RaycastHit hit;
	            if (Physics.Linecast (target.position, camera.position, out hit)) {
	                distance -=  hit.distance;
	            }
	            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
	            Vector3 position = rotation * negDistance + target.position;
	            
	            camera.rotation = rotation;
	            camera.position = position;
	        } 
	    }
	    
		/// <summary>
		/// Clamps the angle.
		/// </summary>
		/// <returns>The angle.</returns>
		/// <param name="angle">Angle.</param>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public static float ClampAngle( float angle, float min, float max )
		{
			#if LOGGING
			Log.Trace( "Begin float ClampAngle( float angle, float min, float max )" );
			#endif
			
			if (angle < -360F)
			{
				angle += 360F;
			}
			
			if (angle > 360F)
			{
				angle -= 360F;
			}
			
			float result = Mathf.Clamp(angle, min, max);
			
			#if LOGGING
			Log.Trace( "End float ClampAngle( float angle, float min, float max )" );
			#endif
			
			return result;
		}
	}
}