using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimono : MonoBehaviour
{
    [SerializeField] GameObject maki;
    private float mSpeed = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    private void Test()
    {
        //transform.Translate(mSpeed, 0, 0);
        transform.localPosition = new Vector2(275, 0);
        if (localPosition.x >= 275)
            mSpeed* x;
    }
}
