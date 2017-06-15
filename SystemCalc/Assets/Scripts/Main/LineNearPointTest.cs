﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineNearPointTest : MonoBehaviour
{
	[SerializeField]
	private Transform p1;
	[SerializeField]
	private Transform p2;
	[SerializeField]
	private Transform nearPoint;
	[SerializeField]
	private LineRenderer line;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		line.SetPosition(0, p1.position);
		line.SetPosition(1, p2.position);
	}
}
