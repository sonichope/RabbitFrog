using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 練習------------
    static void Test()
    {
        System.Random r1 = new System.Random();
        Console.WriteLine(r1.Next(0, 3));

        System.Random r2 = new System.Random();
        Console.WriteLine(r2.Next(1, 4));
    }
}
