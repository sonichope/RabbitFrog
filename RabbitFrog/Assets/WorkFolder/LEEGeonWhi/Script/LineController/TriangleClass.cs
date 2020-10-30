using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleClass
{    
    /// <summary>
     /// 三角形を判定
     /// </summary>
     /// <param name="startPos"></param>
     /// <param name="MaxY_Pos"></param>
     /// <param name="endPos"></param>
     /// <returns></returns>
    public bool Chack_Traiangle(Vector2 startPos, Vector2 MaxY_Pos, Vector2 endPos)
    {
        if (MaxY_Pos.y - startPos.y <= 0 && GetAngle(startPos, endPos) > 0) return false;
        Vector3 Dir_Chack = Vector3.Normalize(MaxY_Pos - startPos);
        if (Dir_Chack.y <= 0) return false;

        if (GetAngle(startPos, MaxY_Pos) <= 80 || GetAngle(startPos, MaxY_Pos) >= 100)
        {
            if (GetAngle(startPos, MaxY_Pos) < 0) return false;

            if (GetAngle(MaxY_Pos, endPos) <= -80 || GetAngle(MaxY_Pos, endPos) >= -100)
            {
                if (GetAngle(MaxY_Pos, endPos) > 0) return false;
                return true;
            }
        }
        return false;
    }

    private float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }
}
