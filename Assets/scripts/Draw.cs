﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Draw
{
    private static float lineWidth = 0.5f;

    public static void DrawCircle(GameObject node, float radius)
    {
        var segments = 360;
        var line = node.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;
        line.startColor = Color.green;
        line.endColor = Color.green;
        line.material = node.GetComponent<Node>().rangeCircleMaterial;


        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius/4, 1.5f, Mathf.Cos(rad) * radius/4);
        }

        line.SetPositions(points);
    }
}
