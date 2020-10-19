using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClass
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Chack_Line()
    {
        for (int i = 0; i < LineController.Points.Count - 1; i++)
        {
            if (Mathf.Abs(GetAngle(LineController.Points[i], LineController.Points[i + 1])) <= 80 || Mathf.Abs(GetAngle(LineController.startPos, LineController.endPos)) >= 100)
            {
                return false;
            }
        }
        return true;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }
}
