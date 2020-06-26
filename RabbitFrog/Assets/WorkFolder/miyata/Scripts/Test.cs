using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject aaa;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(aaa, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
        if(Input.GetMouseButtonUp(0))
        {

        }
    }
}
