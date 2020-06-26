using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject aaa;
    private Vector3 position;
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            position.x = Input.mousePosition.x;
            position.y = Input.mousePosition.y;
            position.z += 10.0f;
            pos = Camera.main.ScreenToWorldPoint(position);
            Instantiate(aaa, pos, Quaternion.identity);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            //if (hit2d)
            //{
            //    aaa = hit2d.transform.gameObject;
            //}

        }
        
    }
}
