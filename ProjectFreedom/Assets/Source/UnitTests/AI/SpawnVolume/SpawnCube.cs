#region File Header

// File Name:		SpawnCube.cs
// Author:			John Whitsell
// Creation Date:	2014/11/15
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#endregion

/// <summary>
/// A SpawnCube is a cube volume that creates GameObjects of a specified type based on the given width, height, 
///	and depth dimensions.  GameObjects can be separated by modifying a padding value for the width, height, and 
///	depth dimensions as well.
/// </summary>
[Serializable]
[ExecuteInEditMode]
public class SpawnCube : MonoBehaviour
{
	/// <summary>
	/// The width (x-axis) of the spawn cube.
	/// </summary>
	public Int32 width = 2;

	/// <summary>
	/// The height (y-axis) of the spawn cube.
	/// </summary>
	public Int32 height = 2;

	/// <summary>
	/// The depth (z-axis) of the spawn cube.
	/// </summary>
	public Int32 depth = 2;
	
	/// <summary>
	/// The padding width (x-axis) between each object.
	/// </summary>
	public Int32 paddingWidth = 50;
	
	/// <summary>
	/// The padding height (y-axis) between each object.
	/// </summary>
	public Int32 paddingHeight = 50;
	
	/// <summary>
	/// The padding depth (z-axis) between each object.
	/// </summary>
	public Int32 paddingDepth = 50;
	
	/// <summary>
	/// A list of the volume's GameObjects.
	/// </summary>
	[SerializeField]
	private List<GameObject> volumeObjects = new List<GameObject>();
	
	/// <summary>
	/// Destroys all GameObjects in this volume.
	/// </summary>
	public void Empty()
	{
		Int32 numChildren = transform.childCount;
		
		for ( Int32 i=numChildren-1; i >= 0; --i )
		{
			GameObject.DestroyImmediate( transform.GetChild(i).gameObject );
		}
	}
	
	/// <summary>
	/// Invalidates the current state of the volume and updates its values.
	/// </summary>
	public void InvalidateVolume()
	{
		CheckForInvalidState();
		
		UpdateVolume();
	}
	
	/// <summary>
	/// Checks the current state of the volume and attempts to correct any de-synchronization issues between it 
	///	and its GameObjects.
	/// </summary>
	private void CheckForInvalidState()
	{
		if ( volumeObjects == null )
		{
			volumeObjects = new List<GameObject>();
		}
		
		volumeObjects.Clear();
		
		Int32 numChildren = transform.childCount;
		
		if ( volumeObjects.Count < numChildren )
		{
			for ( Int32 i=0; i<numChildren; ++i )
			{
				volumeObjects.Add( transform.GetChild(i).gameObject );
			}
		}
	}
	
	/// <summary>
	/// Gets the position within the volume for the specified GameObject index.
	/// </summary>
	/// <returns>The position.</returns>
	/// <param name="index">The index of a GameObject within the volume.</param>
	private Vector3 GetPositionFor( Int32 index )
	{
		Int32 w = index % width;
		Int32 h = index / width % height;
		Int32 d = index / (width * height);
		
		return new Vector3( ( w * paddingWidth ) - ( (width-1) * paddingWidth * 0.5f ),
		                   ( h * paddingHeight ) - ( (height-1) * paddingHeight * 0.5f ),
		                   ( d * paddingDepth ) - ( (depth-1) * paddingDepth * 0.5f ) );
	}
	
	/// <summary>
	/// Spawn a GameObject using the specified position and rotation.
	/// </summary>
	/// <param name="position">The position of the GameObject.</param>
	/// <param name="rotation">The rotation of the GameObject.</param>
	private GameObject Spawn( Vector3 position, Quaternion rotation )
	{
		GameObject go = GameObject.CreatePrimitive( PrimitiveType.Cube );
		go.transform.position = position;
		go.transform.rotation = rotation;
		go.transform.localScale = new Vector3( 5.0f, 5.0f, 5.0f );
		
		return go;
	}
	
	/// <summary>
	/// Updates the volume.
	/// </summary>
	private void UpdateVolume()
	{
		//	Calculate the size of the volume.
		Int32 newSize = width * height * depth;
		
		GameObject go = null;
		
		//	Destroy any extra GameObjects outside of the volume's dimensions.
		while ( volumeObjects.Count > newSize )
		{
			go = volumeObjects[volumeObjects.Count-1];
			
			volumeObjects.RemoveAt( volumeObjects.Count-1 );

			GameObject.DestroyImmediate( go );
		}
		
		//	Loop through the volume and update its GameObjects.
		for ( Int32 i=0; i<newSize; ++i )
		{
			//	Get the position for the current index.
			Vector3 position = GetPositionFor( i );
			
			//	If a GameObject at this index already exists, reuse it.
			if ( i < volumeObjects.Count )
			{
				go = volumeObjects[i];
			}
			
			//	If a GameObject at this index doesn't exist, create one.
			if ( go == null || i > volumeObjects.Count-1 )
			{
				//	Create a new GameObject at the correct position.
				go = Spawn( position, Quaternion.identity );
				
				//	Cache the GameObject so it can be reused.
				volumeObjects.Add( go );
			}
			else
			{
				//	Update the existing GameObject's position.
				go.transform.position = position;
			}
			
			//	Attach the GameObject to the SpawnCube.
			go.transform.parent = transform;
		}
	}
}