﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public float radius = 1;
	public Vector2 regionSize = Vector2.one;
	public int rejectionSamples = 30;
	public float displayRadius =1;
    public int count = 10;
    public float y = 0;
	List<Vector2> points;

	void OnValidate() {
		points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples, count);
	}

	void OnDrawGizmos() {
		if (points != null) {
			foreach (Vector2 point in points) {
				Gizmos.DrawCube(new Vector3(point.x, y, point.y), new Vector3(1,1,1)*displayRadius);
			}
		}
	}
}