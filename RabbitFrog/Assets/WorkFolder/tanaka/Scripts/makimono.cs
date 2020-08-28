using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class makimono : MonoBehaviour
{
    [SerializeField] GameObject Maki;
    [SerializeField] GameObject Peper;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void scalMakimono()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Maki.transform.localScale = new Vector2(0, 550);
            Peper.transform.localScale = new Vector2(0, 550);
        }
    }

    void isCanvasEnable()
    {

    }
}
