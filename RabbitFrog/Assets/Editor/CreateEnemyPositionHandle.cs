using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateEnemyPosition))]
public class CreateEnemyPositionHandle : Editor
{
    void OnSceneGUI()
    {
        CreateEnemyPosition data = (CreateEnemyPosition)target;
        data.pos = data.transform.position;
        data.rot = data.transform.rotation;
        data.scale = data.transform.localScale;

        //Handles.color = new Color(0f, 0f, 1f, 1f);
        //Vector3[] points = new Vector3[data.points.Length];
        //for (var i = 0; i < data.points.Length; i++)
        //{
        //    points[i] = data.points[i].position;
        //}
        //Handles.DrawAAPolyLine(points);
    }

}
