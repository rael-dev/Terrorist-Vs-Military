﻿using UnityEngine;
using System.Collections;

/*
 * Author: Israel Anthony
 * Purpose: Rotates an object's Y transform.
 * Caveats: None
 */
public class YRotator : MonoBehaviour 
{
	private Vector3 rotation;

	// Use this for initialization
	void Start () 
	{
		rotation.x = gameObject.transform.rotation.x;
		rotation.y = gameObject.transform.rotation.y;
		rotation.z = gameObject.transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		rotation.y += 5;
		gameObject.transform.rotation = Quaternion.Euler (rotation.x, rotation.y, rotation.z);
	}
}