using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TestDistance : MonoBehaviour
{
    protected int getDistance(double x, double y,double x2,double y2)
    {
        double distance = Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));

        return (int)distance;
    }
}

