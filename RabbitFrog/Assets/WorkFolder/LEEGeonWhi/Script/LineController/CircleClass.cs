using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClass
{
    public bool Chack_Circle(List<Vector3> Points_normal)
    {
        bool ChangeDir_X = false;
        bool ChangeDir_Y = false;
        float temp = 0;

        for (int i = 0; i < Points_normal.Count - 1; i++)
        {
            if (Points_normal[i].x < 0 && temp > 0) ChangeDir_X = true;
            if (Points_normal[i].x > 0 && temp < 0) ChangeDir_X = true;
            temp = Points_normal[i].x;  
        }


        for (int i = 0; i < Points_normal.Count - 1; i++)
        {
            if (Points_normal[i].y - Points_normal[i + 1].y < 0 && temp > 0) ChangeDir_Y = true;
            if (Points_normal[i].y - Points_normal[i + 1].y > 0 && temp < 0) ChangeDir_Y = true;
            temp = Points_normal[i].y - Points_normal[i + 1].y;
        }

        if (ChangeDir_X & ChangeDir_Y) return true;
        else return false;
    }
}
