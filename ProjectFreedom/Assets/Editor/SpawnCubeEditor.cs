#region File Header

// File Name:		SpawnCubeEditor.cs
// Author:			John Whitsell
// Creation Date:	2014/11/15
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.

#endregion

#region Using Directives

using System;

using UnityEditor;

using UnityEngine;

using LunarGrin.Core;

#endregion

/// <summary>
/// A custom inspector for a SpawnCube object.
/// </summary>
[CustomEditor(typeof(SpawnCube))]
public class SpawnCubeEditor : Editor
{
	#region SpawnCube properties
	
	/// <summary>
	/// The width (x-axis) of the spawn cube.
	/// </summary>
	private Range<Int32> width = new Range<Int32>( 0, 10 );
	
	/// <summary>
	/// The height (y-axis) of the spawn cube.
	/// </summary>
	private Range<Int32> height = new Range<Int32>( 0, 10 );
	
	/// <summary>
	/// The depth (z-axis) of the spawn cube.
	/// </summary>
	private Range<Int32> depth = new Range<Int32>( 0, 10 );

	/// <summary>
	/// The padding width (x-axis) between each object.
	/// </summary>
	private Range<Int32> paddingWidth = new Range<Int32>( 0, 1000 );

	/// <summary>
	/// The padding height (y-axis) between each object.
	/// </summary>
	private Range<Int32> paddingHeight = new Range<Int32>( 0, 1000 );

	/// <summary>
	/// The padding depth (z-axis) between each object.
	/// </summary>
	private Range<Int32> paddingDepth = new Range<Int32>( 0, 1000 );
	
	#endregion
	
	#region Serialization properties
	
	/// <summary>
	/// The serialized SpawnCube object.
	/// </summary>
	private SerializedObject obj = null;
	
	/// <summary>
	/// The serialized width (x-axis) of the spawn cube.
	/// </summary>
	private SerializedProperty serializedWidth = null;
	
	/// <summary>
	/// The serialized height (y-axis) of the spawn cube.
	/// </summary>
	private SerializedProperty serializedHeight = null;
	
	/// <summary>
	/// The serialized depth (z-axis) of the spawn cube.
	/// </summary>
	private SerializedProperty serializedDepth = null;
	
	/// <summary>
	/// The serialized padding width (x-axis) between each object.
	/// </summary>
	private SerializedProperty serializedPaddingWidth = null;
	
	/// <summary>
	/// The serialized padding height (y-axis) between each object.
	/// </summary>
	private SerializedProperty serializedPaddingHeight = null;
	
	/// <summary>
	/// The serialized padding depth (z-axis) between each object.
	/// </summary>
	private SerializedProperty serializedPaddingDepth = null;
	
	#endregion
	
	#region Inspector display flags
	
	/// <summary>
	/// A flag that determines whether or not the SpawnCube has been changed and that the SpawnCube needs to be updated.
	/// </summary>
	private Boolean invalidate = false;
	
	/// <summary>
	/// A flag that determines whether or not the dimension options are displayed in the inspector.
	/// </summary>
	private Boolean showDimensionsOptions = true;
	
	/// <summary>
	/// A flag that determines whether or not the padding options are displayed in the inspector.
	/// </summary>
	private Boolean showPaddingOptions = true;
	
	#endregion
	
	/// <summary>
	/// OnEnable is called when the inspector is initialized for a target.  Target values must be serialized so they can be edited.
	/// </summary>
	public void OnEnable()
	{
		obj = new SerializedObject( target );
		
		serializedWidth = obj.FindProperty( "width" );
		serializedHeight = obj.FindProperty( "height" );
		serializedDepth = obj.FindProperty( "depth" );
		
		serializedPaddingWidth = obj.FindProperty( "paddingWidth" );
		serializedPaddingHeight = obj.FindProperty( "paddingHeight" );
		serializedPaddingDepth = obj.FindProperty( "paddingDepth" );
	}
	
	/// <summary>
	/// OnInspectorGUI is called when the inspector is interacted with.  Target values on the target must be updated.
	/// </summary>
	public override void OnInspectorGUI()
	{
		//	Pull the variables from the Unity runtime and store it in the serialized object.
		obj.Update();
		
		//	Draw the dimension options.
		if ( showDimensionsOptions = EditorGUILayout.Foldout( showDimensionsOptions, "Dimensions" ) )
		{
			DrawIntSlider( serializedWidth, width.minimum, width.maximum, "Width" );
			
			DrawIntSlider( serializedHeight, height.minimum, height.maximum, "Height" );
			
			DrawIntSlider( serializedDepth, depth.minimum, depth.maximum, "Depth" );
		}
		
		EditorGUILayout.Space();
		
		//	Draw the padding options.
		if ( showPaddingOptions = EditorGUILayout.Foldout( showPaddingOptions, "Padding" ) )
		{
			DrawIntSlider( serializedPaddingWidth, paddingWidth.minimum, paddingWidth.maximum, "Width" );
			
			DrawIntSlider( serializedPaddingHeight, paddingHeight.minimum, paddingHeight.maximum, "Height" );
			
			DrawIntSlider( serializedPaddingDepth, paddingDepth.minimum, paddingDepth.maximum, "Depth" );
		}
		
		//	Push the modified properties back to the Unity runtime.
		obj.ApplyModifiedProperties();
		
		//	If a value has been changed, invalidate the object so that it can update itself.
		if ( invalidate )
		{
			SpawnCube spawnCube = (SpawnCube)target;
			
			spawnCube.InvalidateVolume();
			
			invalidate = false;
		}
	}
	
	/// <summary>
	/// Draws an Int32 slider.
	/// </summary>
	/// <param name="property">The SerializedProperty being edited.</param>
	/// <param name="min">The minimum slider value.</param>
	/// <param name="max">The maximum slider value.</param>
	/// <param name="name">The name label displayed in the inspector.</param>
	private void DrawIntSlider( SerializedProperty property, Int32 min, Int32 max, String name )
	{
		Int32 intValidator = property.intValue;
		
		EditorGUILayout.IntSlider( property, min, max, name );
		if ( intValidator != property.intValue )
		{
			invalidate = true;
		}
	}
}