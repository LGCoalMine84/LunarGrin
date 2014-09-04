#region File Header
// File Name:		PrefabUtil.cs
// Author:			John Whitsell
// Creation Date:	
//
// Copyrights:		Copyright 2014
//					Lunar Grin, LLC.
//					All rights reserved.
#endregion

#region Using Directives
using UnityEngine;
using System.Collections;
#endregion

public class PrefabUtil
{
    public static GameObject InstantiateUIPrefab( GameObject prefab, GameObject parent, Vector3 position, Quaternion rotation )
    {
        GameObject newGameObject = (GameObject)GameObject.Instantiate( prefab, position, rotation );
        
        if ( parent != null )
        {
            newGameObject.transform.parent = parent.transform;
        }
        
        newGameObject.transform.localPosition = Vector3.zero;
        newGameObject.transform.localRotation = Quaternion.identity;
        newGameObject.transform.localScale = Vector3.one;
        
        return newGameObject;
    }
}