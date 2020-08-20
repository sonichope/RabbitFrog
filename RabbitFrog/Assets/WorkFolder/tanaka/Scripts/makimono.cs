using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class makimono : MonoBehaviour
{
    public float mSpeed = 0.1f;
    //private Vector3 makipos;
    int counter;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        test();
    }

    private void test()
    {
        Vector2 tmp = transform.localPosition;
        transform.localPosition = new Vector2(tmp.x - 75, tmp.y);
        if (tmp.x >= -75)
        {
            //tmp.x == counter--;
        }
    }
}
